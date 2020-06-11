using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       CalibImage
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.Calibration
 * File      Name：       CalibImage
 * Creating  Time：       5/10/2020 5:09:26 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.Calibration
{
    /// <summary>
    /// This class contains all 
    /// information about its calibration image. 
    /// Besides the basic information for the calibration process, like
    /// the plate region and the marks, the calibration results are also 
    /// stored here. 
    /// 
    /// 该类包含标定图像的所有信息.除了标定过程的基本信息,其他如标定板区域,
    /// 特征点区域,标定结果也存储在该类中.
    /// 
    /// Please note that the HALCON Codelets does not support the 
    /// new HALCON calibration plate with hexagonally arranged marks.
    /// Only calibration plates with rectangularly
    /// arranged marks are supported for the Calibration Codelet.
    /// 
    /// 请注意:HALCON的代码集不支持新的特征点按六角形分布的标定板,只支持
    /// 特征点按矩形分布的标定板.
    ///
    /// Each CalibImage instance has a status <c>mCanCalib</c>, which 
    /// describes the mode of  "being ready for a calibration", depending 
    /// on the validity and completeness of the parameters marks, pose 
    /// and the plate region. 
    /// 
    /// 每个CalibImage类实例有一个状态标记"mCanCalib",该标记描述"准备好标定"的模式,
    /// "准备好标定"基于特征点的参数、位姿、标定板区域的有效性和完整性.
    /// 
    /// If these basics can not be extracted from the calibration image
    /// <c>mImage</c> using the current set of calibration parameters, 
    /// the flag <c>mCanCalib</c> remains 1 and indicates that a calibration 
    /// process is not feasible using this calibration image.
    /// 若不能从标定图像提取到上述信息,则使用当前标定参数集,且"准备好标定"的模式标记
    /// 保持为1,表示用当前标定图像时标定过程不可行.
    /// </summary>
    public class CalibImage
    {
        /// <summary>
        /// Reference to the controller class that performs all 
        /// calibration operations and interacts with the GUI.
        /// 执行所有标定操作并与GUI交互的控制类的引用,即基于标定板的标定助手
        /// </summary>
        private ProVision.Calibration.CalibOnPlateAssistant _assistant;

        /// <summary>
        /// Width of calibration image
        /// 标定用图像的宽度
        /// </summary>
        public int ImageWidth;

        /// <summary>
        /// Height of calibration image
        /// 标定用图像的高度
        /// </summary>
        public int ImageHeight;

        /// <summary>
        /// HALCON error message that occurs when calculating the 
        /// basic information for the calibration image 
        /// (plate region, marks and pose).
        /// 计算标定图像的基本信息时HALCON抛出的异常信息
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// Flag that permits or forbids this calibration image
        /// to be part of the calibration process
        /// 准备好标定标记:允许或禁止当前标定图像添加到标定过程
        /// </summary>
        public int CanCalib;

        public CalibImage(HalconDotNet.HObject hImg, ProVision.Calibration.CalibOnPlateAssistant assistant)
        {
            HalconDotNet.HTuple width, height;
            _hImage = hImg;
            _assistant = assistant;
            CanCalib = 1; //标记:未准备好标定
            _plateStatus = ProVision.Calibration.CalibOnPlateAssistant.PS_NOT_FOUND;
            HalconDotNet.HOperatorSet.GetImageSize(_hImage, out width, out height);
            ImageWidth = width.I;
            ImageHeight = height.I;
            _estimatedPlateSize = 0;
            ErrorMessage = string.Empty;

            _caltabRegion = new HalconDotNet.HRegion();
            _markCenterXLD = new HalconDotNet.HXLDCont();
            _estimatedWorldCoordinateSystem = new HalconDotNet.HObject();
            _qualityIssueList = new System.Collections.ArrayList(15);

            _markCenterRows = new HalconDotNet.HTuple();
            _markCenterCols = new HalconDotNet.HTuple();
            _plateEstimatedPose = new HalconDotNet.HPose();
        }

       
        private HalconDotNet.HObject _hImage;
        /// <summary>
        /// Calibration image
        /// 标定用的图像
        /// </summary>
        public HalconDotNet.HObject Image { get { return _hImage; } }
              
        private HalconDotNet.HTuple _markCenterRows;
        /// <summary>
        /// Tuple with row coordinates of the detected marks
        /// 特征点中心Row坐标
        /// </summary>
        public HalconDotNet.HTuple MarkCenterRows { get { return _markCenterRows; } }
     
        private HalconDotNet.HTuple _markCenterCols;
        /// <summary>
        /// Tuple with column coordinates of the detected marks
        /// 特征点中心Column坐标
        /// </summary>
        public HalconDotNet.HTuple MarkCenterColumns { get { return _markCenterCols; } }
     
        private HalconDotNet.HObject _markCenterXLD;
        /// <summary>
        /// XLD contour points of the marks detected in 
        /// the calibration image, generated from the row and 
        /// column values <c>mMarkCenterRows</c> and 
        /// <c>mMarkCenterCols</c> 
        /// 在标定图像中找到的特征点,由其中心坐标生成的XLD轮廓
        /// </summary>
        public HalconDotNet.HObject MarkCenterXLD { get { return _markCenterXLD; } }
      
        private HalconDotNet.HTuple _plateEstimatedPose;
        /// <summary>
        /// Estimation for the external camera parameters (position and
        /// orientation)
        /// 相机的评估外参(位置和方向)
        /// </summary>
        public HalconDotNet.HTuple PlateEstimatedPose { get { return _plateEstimatedPose; } }
     
        private HalconDotNet.HObject _estimatedWorldCoordinateSystem;
        /// <summary>
        /// Estimated world coordinate system (pose of the calibration plate
        /// in camera coordinates), based on the
        /// <c>mEstimatedPose</c> and the camera parameters 
        /// for this calibration image
        /// 评估的世界坐标系(即标定板坐标系在相机坐标系中的位姿),
        /// 基于标定板的评估位姿(相机外参)和相机内参来生成
        /// </summary>
        public HalconDotNet.HObject EstimatedWorldCoordinateSystem { get { return _estimatedWorldCoordinateSystem; } }
      
        private double _estimatedPlateSize;
        /// <summary>
        /// 标定板的相邻特征点的世界坐标系内点间距
        /// </summary>
        public double EstimatedPlateSize { get { return _estimatedPlateSize; } }

        /// <summary>
        /// Region of the plane calibration plate in the calibration image
        /// 平面标定板在标定图像中的区域
        /// </summary>
        private HalconDotNet.HObject _caltabRegion;
        public HalconDotNet.HObject CaltabRegion { get { return _caltabRegion; } }
     
        private System.Collections.ArrayList _qualityIssueList;
        /// <summary>
        /// 标定图像品质值列表
        /// </summary>
        public System.Collections.ArrayList QualityIssueList { get { return _qualityIssueList; } }

     
        private string _plateStatus;
        /// <summary>
        /// Flag that describes the degree of success or failure 
        /// after an update of the basic information.
        /// 标定图像中标定板提取状态标记:更新标定图像基本信息后成功或失败的描述
        /// </summary>
        public string PlateStatus { get { return _plateStatus; } }

        /// <summary>
        /// Determines(or updates) the basic information for this 
        /// calibration image, which are the values for the region 
        /// plate, the center marks, and the estimated pose. 
        /// The flag <c>mPlateStatus</c> describes the evaluation 
        /// of the computation process.
        /// If desired the quality assessment can be recalculated 
        /// as well. 
        /// 计算或更新标定图像的基本信息,包括标定板区域,特征点中心坐标
        /// 以及标定板的评估位置(相机外参).
        /// "标定板状态"标记描述标定计算过程的评估值,若希望获取品质也可以
        /// 重新计算
        /// </summary>
        /// <param name="isUpdateQuality">
        /// Triggers the recalculation of the quality assessment for
        /// this calibration image 
        /// 触发重计算标定图像品质任务
        /// </param>
        public void UpdateCaltab(bool isUpdateQuality)
        {
            HalconDotNet.HTuple worldX, worldY;
            HalconDotNet.HTuple unit = new HalconDotNet.HTuple("m");
            bool failed = false;
            ProVision.Calibration.QualityProcedures proc =
                new ProVision.Calibration.QualityProcedures();
            string descriptionFile;
            HalconDotNet.HTuple startCamPara;
            ErrorMessage = "";

            _caltabRegion.Dispose();
            _markCenterXLD.Dispose();
            _estimatedWorldCoordinateSystem.Dispose();

            _markCenterRows = new HalconDotNet.HTuple();
            _markCenterCols = new HalconDotNet.HTuple();

            _plateStatus = ProVision.Calibration.CalibOnPlateAssistant.PS_NOT_FOUND;
            descriptionFile = _assistant.DescrpFile;
            try
            {
                //注意:FindCaltab算子的控制参数2(从1开始计数),数据类型为整型,非整型则异常(非整型用HTuple封装亦异常)
                HalconDotNet.HOperatorSet.FindCaltab(_hImage, out _caltabRegion,
                    descriptionFile,
                    _assistant.FilterSize,
                    _assistant.MarkThresh,
                    _assistant.MarkMinDiameter); 

                _plateStatus = ProVision.Calibration.CalibOnPlateAssistant.PS_MARKS_FAILED;

                //--Quality issue measurements,标定图像品质计算
                if (isUpdateQuality)
                {
                    _qualityIssueList.Clear();
                    failed = _assistant.TestQualityIssues(this);
                }

                startCamPara = _assistant.GetCameraParams(this);

                HalconDotNet.HOperatorSet.FindMarksAndPose(_hImage, _caltabRegion, descriptionFile, startCamPara,
                    _assistant.StartThresh, _assistant.DeltaThresh, _assistant.MinThresh, _assistant.Alpha,
                    _assistant.MinContLength, _assistant.MarkMaxDiameter, out _markCenterRows,
                    out _markCenterCols, out _plateEstimatedPose);

                HalconDotNet.HOperatorSet.GenCrossContourXld(out _markCenterXLD, _markCenterRows, _markCenterCols,
                    new HalconDotNet.HTuple(10), new HalconDotNet.HTuple(0));

                //品质异常:可能无法提取到标定板区域或标志点
                if (failed)
                    _assistant.AddQualityIssue(this, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_FAILURE, 0.0);

                //标定板上特征点的中心像素坐标转换为对应的世界坐标系坐标
                HalconDotNet.HOperatorSet.ImagePointsToWorldPlane(startCamPara, _plateEstimatedPose, _markCenterRows, _markCenterCols, unit,
                    out worldX, out worldY);

                //标定板相邻世界坐标点的点间距(米)
                HalconDotNet.HTuple distance;
                HalconDotNet.HOperatorSet.DistancePp(worldX[0].D, worldY[0].D, worldX[1].D, worldY[1].D, out distance);
                _estimatedPlateSize = distance.D;
                _estimatedPlateSize *= 10.0;

                proc.Get_3D_Coord_System(_hImage, out _estimatedWorldCoordinateSystem,
                    startCamPara, _plateEstimatedPose, new HalconDotNet.HTuple(_estimatedPlateSize / 2.0));

                _plateStatus = _qualityIssueList.Count > 0 ? ProVision.Calibration.CalibOnPlateAssistant.PS_QUALITY_ISSUES :
                    ProVision.Calibration.CalibOnPlateAssistant.PS_OK;
                CanCalib = 0; //准备好标定标记:允许当前标定图像加入标定过程
            }
            catch (HalconDotNet.HalconException hex)
            {
                ErrorMessage = hex.Message;
                string str = hex.GetErrorMessage();

                /* if exception was raised due to lack of memory, 
                 * forward the error to the calling method 
                 * 若由于内存不足抛出异常,则将异常传递给调用者 */
                if (hex.Message.IndexOf("not enough") != -1)
                    throw (hex);
            }
        }

        /// <summary>
        /// Releases the memory for all iconic HALCON objects contained in
        /// this instance.
        /// 释放包含在该类中的图形对象
        /// </summary>
        public void Clear()
        {
            _hImage.Dispose();
            _caltabRegion.Dispose();

            if (_caltabRegion != null
              && _caltabRegion.IsInitialized())
                _caltabRegion.Dispose();

            if (_markCenterXLD != null
                && _markCenterXLD.IsInitialized())
                _markCenterXLD.Dispose();

            if (_estimatedWorldCoordinateSystem != null
              && _estimatedWorldCoordinateSystem.IsInitialized())
                _estimatedWorldCoordinateSystem.Dispose();
        }
    }
}
