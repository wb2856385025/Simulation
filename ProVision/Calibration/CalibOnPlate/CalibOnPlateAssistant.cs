using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       CalibOnPlateAssistant
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.Calibration
 * File      Name：       CalibOnPlateAssistant
 * Creating  Time：       5/10/2020 5:10:53 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.Calibration
{
    /// <summary>
    /// 基于标定板的标定
    /// [注:Halcon标准标定板]
    /// </summary>
    public class CalibOnPlateAssistant
    {

        /// <summary>
        /// Constant indicating the camera model to be of type 
        /// line scan camera.
        /// </summary>
        public const int CAMERA_TYP_LINE_SCAN = 3;
        /// <summary>
        /// Constant indicating the camera model to be of type 
        /// area scan camera with the division 
        /// model to describe the lens distortions
        /// </summary>
        public const int CAMERA_TYP_AREA_SCAN_DIV = 4;
        /// <summary>
        /// Constant indicating the camera model to be of type
        /// area scan camera with the polynomial 
        /// model to describe the lens distortions
        /// </summary>
        public const int CAMERA_TYP_AREA_SCAN_POLY = 5;

        /// <summary>
        /// Constant indicating a change in the set of 
        /// <c>CalibImage</c> instances regarding the parameters 
        /// marks and poses.
        /// </summary>
        public const int UPDATE_MARKS_POSE = 10;
        /// <summary>
        /// Constant indicating a change in the set of
        /// <c>CalibImage</c> instances regarding the 
        /// quality assessment.
        /// </summary>
        public const int UPDATE_QUALITY_TABLE = 12;
        /// <summary>
        /// Constant indicating a change in the evaluation grades 
        /// of the <c>CalibImage</c> set. The grades measure the results 
        /// of the calibration preparations prior to the calibration
        /// process itself.
        /// </summary>
        public const int UPDATE_CALTAB_STATUS = 13;
        /// <summary>
        /// Constant indicating an update of the calibration
        /// results.
        /// </summary>
        public const int UPDATE_CALIBRATION_RESULTS = 14;

        /// <summary>
        /// Constant indicating that the quality measurement
        /// includes all quality assessment operators for 
        /// evaluating the set of calibration images.
        /// </summary>
        public const int QUALITY_ISSUE_TEST_ALL = 0;
        /// <summary>
        /// Constant indicating that the quality measurement uses only the
        /// basic quality assessment operators for speedup purposes.
        /// </summary>
        public const int QUALITY_ISSUE_TEST_QUICK = 1;
        /// <summary>
        /// Constant indicating no quality measurement 
        /// for the set of calibration images.
        /// </summary>
        public const int QUALITY_ISSUE_TEST_NONE = 2;

        /// <summary>
        /// Constant indicating the image quality feature 'exposure'
        /// </summary>
        public const int QUALITY_ISSUE_IMG_EXPOSURE = 20;
        /// <summary>
        /// Constant indicating the image quality feature 'homogeneity'
        /// </summary>
        public const int QUALITY_ISSUE_IMG_HOMOGENEITY = 21;
        /// <summary>
        /// Constant indicating the image quality feature 'contrast'
        /// </summary>
        public const int QUALITY_ISSUE_IMG_CONTRAST = 22;
        /// <summary>
        /// Constant indicating the image quality feature 'sharpness'
        /// </summary>
        public const int QUALITY_ISSUE_IMG_FOCUS = 23;
        /// <summary>
        /// Constant indicating the size of the depicted  
        /// calibration plate in the calibration image, to evaluate
        /// the distance used to the camera
        /// </summary>
        public const int QUALITY_ISSUE_IMG_CALTAB_SIZE = 24;

        /// <summary>
        /// Constant indicating the coverage of the view field.
        /// This is assured only by a sufficient number of 
        /// calibration images and its correct distribution in the space.
        /// </summary>
        public const int QUALITY_ISSUE_SEQ_MARKS_DISTR = 25;
        /// <summary>
        /// Constant indicating the amount of distortions covered,
        /// described by the set of images showing tilted calibration
        /// plates
        /// </summary>
        public const int QUALITY_ISSUE_SEQ_CALTAB_TILT = 26;
        /// <summary>
        /// Constant indicating whether the number of provided calibration
        /// images is sufficient enough to obtain stable calibration results.
        /// </summary>
        public const int QUALITY_ISSUE_SEQ_NUMBER = 27;
        /// <summary>
        /// Constant indicating the all over quality performance,
        /// being best for a value close or equal to 1
        /// </summary>
        public const int QUALITY_ISSUE_SEQ_ALL_OVER = 28;
        /// <summary>
        /// Constant that indicates an error in the calibration
        /// preprocessing step, which has to perform well for the
        /// whole sequence of calibration images in order to start 
        /// the calibration process. 
        /// </summary>
        public const int QUALITY_ISSUE_SEQ_ERROR = 29;
        /// <summary>
        /// Constant indicating an error in the preprocessing step 
        /// for a single calibration image, i.e., that the
        /// marks and pose values might be missing or the region 
        /// plate couldn't be detected
        /// </summary>
        public const int QUALITY_ISSUE_FAILURE = 30;

        /// <summary>
        /// Constant describing an error while reading a 
        /// calibration image from file
        /// </summary>
        public const int ERR_READING_FILE = 31;
        /// <summary>
        /// Constant describing an error exception raised during
        /// the calibration process
        /// </summary>
        public const int ERR_IN_CALIBRATION = 32;
        /// <summary>
        /// Constant indicating an invalid reference index. The
        /// index is needed to define the reference image for
        /// the camera calibration.
        /// </summary>
        public const int ERR_REFINDEX_INVALID = 33;
        /// <summary>
        /// Constant describing an error exception raised 
        /// during quality assessment.
        /// </summary>
        public const int ERR_QUALITY_ISSUES = 34;
        /// <summary>
        /// Constant describing an error that occurred while
        /// writing the calibration parameters into file
        /// </summary>
        public const int ERR_WRITE_CALIB_RESULTS = 35;

        /// <summary>
        /// Constant indicating the result status of the 
        /// calibration preparation step:
        /// Plate region couldn't be detected in the 
        /// calibration image.
        /// </summary>
        public const string PS_NOT_FOUND = "Plate not found";
        /// <summary>
        /// Constant that describes the results of the 
        /// calibration preparation step:
        /// Plate region was detected, but the marks could not
        /// be extracted in the plate region.
        /// </summary>
        public const string PS_MARKS_FAILED = "Marks not found";
        /// <summary>
        /// Constant indicating the result status of the 
        /// calibration preparation step:
        /// Plate region and marks were detected, 
        /// but the quality assessment delivered bad scores.
        /// </summary>
        public const string PS_QUALITY_ISSUES = "Quality issues detected";
        /// <summary>
        /// Constant indicating the result status of the 
        /// calibration preparation step:
        /// The preprocessing step was successful.
        /// </summary>
        public const string PS_OK = "Ok";

        /// <summary>
        /// List of calibration images that are used 
        /// to perform the camera calibration. 
        /// </summary>
        private System.Collections.ArrayList CalibData;

        /// <summary>
        /// Index to the reference image that is used to
        /// determine the initial values for the internal camera 
        /// parameters for the camera calibration
        /// </summary>
        public int ReferenceIndex;

        private ProVision.Calibration.QualityProcedures _qualityProcedure;

        // CALIBRATION RESULTS -----------------------------------------

        /// <summary>
        /// Flag indicating that the calibration was successful and
        /// the present calibration results are up to date
        /// </summary>
        public bool IsCalibValid;
        /// <summary>
        /// The average error give an impression of the accuracy of the
        /// calibration. The error (deviations in x and y coordinates) are 
        /// measured in pixels
        /// </summary>
        public double ErrorMean;

        /// <summary>
        /// Ordered tuple with the external camera parameters for all
        /// calibration images, i.e., the position and orientation of the
        /// calibration plate in camera coordinates.
        /// </summary>
        public HalconDotNet.HTuple Poses;
        /// <summary>
        /// Internal camera parameters
        /// </summary>
        public HalconDotNet.HTuple CameraParams;
        /// <summary>
        /// Error contents that caused an exception 
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// Calibration image at index <c>mReferenceIndex</c>
        /// </summary>
        public HalconDotNet.HObject ReferenceImage { set; get; }
        /// <summary>
        /// Synthetic calibration images with calibrated camera 
        /// parameters to test the quality of the calibration 
        /// algorithm
        /// </summary>
        public HalconDotNet.HObject SimulatedImage { set; get; }
        /// <summary>
        ///  Reference world coordinate system, based on 
        ///  <c>mPose</c> and the calibrated camera parameters 
        /// </summary>
        public HalconDotNet.HObject ReferenceWCS { set; get; }

        /// <summary>
        /// Flag describing whether all calibration images
        /// have a sufficient quality, i.e. whether  the region plate and
        /// marks have been detected in all calibration images,
        /// so that a camera calibration can be invoked
        /// </summary>
        public bool CanCalib { set; get; }

        private bool _atImgCoord;
        /// <summary>
        /// Flag indicating that the origin of the reference world coordinate
        /// system <c>mReferenceWCS</c> is mapped to the origin of the image
        /// coordinate system.
        /// 参考位姿标定板所在世界坐标系的原点是否平移到图像原点
        /// </summary>
        public bool AtImgCoord
        {
            set
            {
                _atImgCoord = value;
                UpdateResultVisualization();
            }
            get
            {
                return _atImgCoord;
            }
        }


        // FIRST TAB  -----------------------------------------------
        /// <summary>
        /// Name of the calibration plate description file to read
        /// the mark center points from
        /// </summary>
        private string _descrpFile;
        public string DescrpFile
        {
            get { return _descrpFile; }
            set
            {
                _descrpFile = value;
                Update();
            }
        }

        private double _thickness;
        /// <summary>
        /// Thickness of the calibration plate that was used in the 
        /// calibration images
        /// </summary>
        public double Thickness
        {
            set
            {
                _thickness = value;
                UpdateResultVisualization();
            }
            get { return _thickness; }
        }     

        private int _cameraType;
        /// <summary>
        /// Camera type, which can either be an area scan camera 
        /// (using the division or polynomial model) or a linescan camera
        /// </summary>
        public int CameraType
        {
            set
            { _cameraType = value;
                Update(true);
            }
            get { return _cameraType; }
        }

        /// <summary>
        /// Auxiliary method prior to the actual update 
        /// routine. Calls the actual update method 
        /// omitting the quality assessment for the 
        /// set of calibration image models.
        /// </summary>
        private void Update()
        {
            bool doQuality = false;
            Update(doQuality);
        }

        /// <summary>
        /// Updates the data of the calibration images
        /// if a change occurred in the calibration parameters.
        /// The quality assessment is performed if the 
        /// supplied value is positive; otherwise, it is omited.
        /// </summary>
        /// <param name="doQuality">
        /// If the flag is positive, an update of the 
        /// quality assessment is invoked, otherwise not.
        /// </param>
        private void Update(bool doQuality)
        {
            int count;
            if ((count = CalibData.Count) == 0)
                return;
            try
            {
                for (int i = 0; i < count; i++)
                    ((ProVision.Calibration.CalibImage)CalibData[i]).UpdateCaltab(doQuality);
                if (doQuality)
                    UpdateImageSetQualityIssues();

                CanCalib = this.GetCanCalibrate();
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALTAB_STATUS);
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_MARKS_POSE);

                if (doQuality)
                    NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_QUALITY_TABLE);
            }
            catch(HalconDotNet.HalconException hex)
            {
                ErrorMessage = hex.Message;
                CanCalib = false;
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_QUALITY_ISSUES);
            }

            if(IsCalibValid)
            {
                IsCalibValid = false;
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS);
            }
        }       

        private double _cellWidth;
        /// <summary>
        /// Horizontal distance between two neighboring CCD 
        /// sensor cells 
        /// </summary>
        public double CellWidth
        {
            set
            { _cellWidth = value;
                Update();
            }
            get { return _cellWidth; }
        }

        private double _cellHeight;
        /// <summary>
        /// Vertical distance between two neighboring CCD 
        /// sensor cells 
        /// </summary>
        public double CellHeight
        {
            set
            {
                _cellHeight = value;
                Update();
            }
            get { return _cellHeight; }
        }

        private double _focalLength;
        /// <summary>
        /// Nominal focal length of the camera lense
        /// </summary>
        public double FocalLength
        {
            set
            {
                _focalLength = value;
                Update();
            }
            get { return _focalLength; }
        }

        /// <summary>
        /// Parameter to model the radial distortion described by 
        /// the division model
        /// </summary>
        public double Kappa;
        /// <summary>
        /// First parameter to model the radial distortion described by 
        /// the polynomial model
        /// </summary>
        public double K1;
        /// <summary>
        /// Second parameter to model the radial distortion described by 
        /// the polynomial model
        /// </summary>
        public double K2;
        /// <summary>
        /// Third parameter to model the radial distortion described by 
        /// the polynomial model
        /// </summary>
        public double K3;
        /// <summary>
        /// First parameter to model the decentering distortion described by 
        /// the polynomial model
        /// </summary>
        public double P1;
        /// <summary>
        /// Second parameter to model the decentering distortion described by 
        /// the polynomial model
        /// </summary>
        public double P2;

        private bool _isTelecentric;
        /// <summary>
        /// Flag indicating the type of camera lense used:
        /// telecentric, which means a parallel projection with the focal 
        /// length equal to 0, or  a perspective projection
        /// </summary>
        public bool IsTelecentric
        {
            set
            {
                _isTelecentric = value;
                Update();
            }
            get { return _isTelecentric; }
        }

        private double _motionVx;
        /// <summary>
        /// X component of the motion vector, which describes the motion
        /// between the linescan camera and the object.
        /// </summary>
        public double MotionVx
        {
            set
            {
                _motionVx = value;
                Update();
            }
            get { return _motionVx; }
        }

        private double _motionVy;
        /// <summary>
        /// Y component of the motion vector, which describes the motion
        /// between the linescan camera and the object.
        /// </summary>
        public double MotionVy
        {
            set
            {
                _motionVy = value;
                Update();
            }
            get { return _motionVy; }
        }

        private double _motionVz;
        /// <summary>
        /// Z component of the motion vector, which describes the motion
        /// between the linescan camera and the object.
        /// </summary>
        public double MotionVz
        {
            set
            {
                _motionVz = value;
                Update();
            }
            get { return _motionVz; }
        }

        // SECOND TAB ---------------------------------------------
        private int _warnLevel;
        public int WarnLevel
        {
            set
            {
                _warnLevel = value;
                Update(true);
            }
            get { return _warnLevel; }
        }

        private int _imageAccuracyMode;
        /// <summary>
        /// Sets or get the parameter that define the mode (accuracy) of
        /// the quality assessment for single calibration images.
        /// 单个标定图像封装类实例的品质评估模式(精度)
        /// (accuracy) one of the constants starting with QUALITY_ISSUE_TEST_*.
        /// </summary>
        public int ImageAccuracyMode
        {
            set
            {
                _imageAccuracyMode = value;
                Update(true);
            }
            get { return _imageAccuracyMode; }
        }

        private int _imageSetAccuracyMode;
        /// <summary>
        /// Sets or get the parameter that define the mode (accuracy) of
        /// the quality assessment for the whole sequence of calibration images.
        /// (accuracy) one of the constants starting with QUALITY_ISSUE_TEST_*.
        /// 标定图像封装类实例集的品质评估模式(精度)
        /// </summary>
        public int ImageSetAccuracyMode
        {
            set
            {
                _imageSetAccuracyMode = value;
                Update(true);
            }
            get { return _imageSetAccuracyMode; }
        }

        /// <summary>
        /// List of quality assessment scores of the whole set of calibration
        /// images.
        /// 整个标定图像集的品质评估得分列表
        /// </summary>
        public System.Collections.ArrayList ImageSetQualityList;

        private int _filterSize;
        /// <summary>
        /// Size of the filter mask that is used to smooth the 
        /// image before determining the region plate in the
        /// calibration image
        /// 滤波掩膜尺寸,在提取标定板区域之前用于平滑图像
        /// </summary>
        public int FilterSize
        {
            set
            {
                _filterSize = value;
                Update();
            }
            get { return _filterSize; }
        }

        private double _markThresh;
        /// <summary>
        /// Threshold value for mark extraction
        /// 提取特征点时的灰度阈值
        /// </summary>
        public double MarkThresh
        {
            set
            {
                _markThresh = value;
                Update();
            }
            get { return _markThresh; }
        }

        private double _markMinDiameter;
        /// <summary>
        /// Expected minimum diameter of the marks on the 
        /// calibration plate
        /// 标定板上特征点的预期直径最小值
        /// [注:单位米]
        /// </summary>
        public double MarkMinDiameter
        {
            set
            {
                _markMinDiameter = value;
                Update();
            }
            get { return _markMinDiameter; }
        }

        private double _startThresh;
        /// <summary>
        /// Initial threshold value for contour detection
        /// 标定板特征点初始灰度值
        /// </summary>
        public double StartThresh
        {
            set
            {
                _startThresh = value;
                Update();
            }
            get { return _startThresh; }
        }

        private double _deltaThresh;
        /// <summary>
        /// Loop value for successive reduction of 
        /// the initial threshold <c>StartThresh</c>
        /// 从初始灰度阈值迭代递减的步长
        /// </summary>
        public double DeltaThresh
        {
            set
            {
                _deltaThresh = value;
                Update();
            }
            get { return _deltaThresh; }
        }

        private double _minThresh;
        /// <summary>
        /// Minimum threshold for contour detection
        /// 提取标定板上特征点轮廓时的最小灰度值
        /// </summary>
        public double MinThresh
        {
            set
            {
                _minThresh = value;
                Update();
            }
            get { return _minThresh; }
        }

        private double _alpha;
        /// <summary>
        /// Filter parameter for contour detection
        /// 提取标定板上特征点轮廓时边缘提取参数
        /// </summary>
        public double Alpha
        {
            set
            {
                _alpha = value;
                Update();
            }
            get { return _alpha; }
        }

        private double _minContLength;
        /// <summary>
        /// Minimum length of the contours of the marks
        /// 提取标定板上特征点时特征点轮廓最小长度
        /// [注:单个特征点的轮廓长度]
        /// </summary>
        public double MinContLength
        {
            set
            {
                _minContLength = value;
                Update();
            }
            get { return _minContLength; }
        }

        private double _markMaxDiameter;
        /// <summary>
        /// Expected maximum diameter of the marks on the 
        /// calibration plate
        /// 标定板上特征点的预期直径最大值
        /// [注:单位米]
        /// </summary>
        public double MarkMaxDiameter
        {
            set
            {
                _markMaxDiameter = value;
                Update();
            }
            get { return _markMaxDiameter; }
        }


        //Reset Vals[重置默认值]
        public int ResetFilterSize;
        public int ResetMarkThresh;
        public int ResetMarkMinDiam;
        public int ResetStartThresh;
        public int ResetDeltaThresh;
        public int ResetMinThresh;
        public double ResetAlpha;
        public int ResetMinContLength;
        public int ResetMarkMaxDiam;

        /// <summary>
        /// Delegate to notify the GUI about changes in the data models
        /// </summary>
        public ProVision.Calibration.CalibOnPlateDelegate NotifyCaliObserver;

        private void ResetValues()
        {
            ResetFilterSize = 3;
            ResetMarkThresh = 112;
            ResetMarkMinDiam = 5;
            ResetStartThresh = 128;
            ResetDeltaThresh = 10;
            ResetMinThresh = 18;
            ResetAlpha = 0.9; /* 90*0.1 */
            ResetMinContLength = 15;
            ResetMarkMaxDiam = 100;
        }

        public CalibOnPlateAssistant()
        {
            CalibData = new System.Collections.ArrayList(15);
            ReferenceIndex = -1;
            _descrpFile = "caltab_30mm.descr";
            IsCalibValid = false;
            CanCalib = true;
            AtImgCoord = false;

            ReferenceImage = new HalconDotNet.HImage();
            SimulatedImage = new HalconDotNet.HImage();

            ResetValues();

            FilterSize = ResetFilterSize;
            MarkThresh = ResetMarkThresh;
            MarkMinDiameter = ResetMarkMinDiam;
            StartThresh = ResetStartThresh;
            DeltaThresh = ResetDeltaThresh;
            MinThresh = ResetMinThresh;
            Alpha = ResetAlpha;
            MinContLength = ResetMinContLength;
            MarkMaxDiameter = ResetMarkMaxDiam;

            _warnLevel = 70;
            _imageAccuracyMode = ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_ALL;
            _imageSetAccuracyMode = ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_ALL;
            ImageSetQualityList = new System.Collections.ArrayList(15);
            _qualityProcedure = new ProVision.Calibration.QualityProcedures();

            Thickness = 1.00; //milimeter,毫米
            CameraType = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_DIV;
            CellWidth = 8.300; //micrometer,微米
            CellHeight = 8.300;
            FocalLength = 8.000; //millimeter,毫米
            IsTelecentric = false;
            Kappa = 0.0;
            K1 = 0.0;
            K2 = 0.0;
            K3 = 0.0;
            P1 = 0.0;
            P2 = 0.0;
            MotionVx = 0.0;
            MotionVy = 500.0;
            MotionVz = 0.0;

            NotifyCaliObserver = new CalibOnPlateDelegate(Dumpy);
        }

        private void Dumpy(int val)
        {
           
        }

        /// <summary>
        /// Gets the calibration image for the index <c>i</c>
        /// from the list <c>CalibData</c>
        /// </summary>
        public ProVision.Calibration.CalibImage GetCalibDataAt(int idx)
        {
            if(CalibData!=null)
            {
                int cnt = CalibData.Count;
                if(idx>=0
                    && idx<cnt)
                {
                    return (ProVision.Calibration.CalibImage)CalibData[idx];
                }
            }

            return null;
        }

        /// <summary>
        /// Add a new calibration image to the list <c>CalibData</c>.
        /// The image is read from the location <c>filename</c>
        /// and a new calibration image instance is then 
        /// generated, embedding this image.
        /// As a preparation step prior to the calibration process, the 
        /// basic information for the calibration image are determined,
        /// in terms of: detection of the region plate and the marks
        /// and pose.
        /// 添加新的标定图像到标定数据表<c>CalibData</c>c>.
        /// 图像从指定地址加载，然后创建一个标定图像实例,并将加载的图像嵌入到标定图像实例.
        /// 作为标定相机前的优先步骤,标定图像的基本信息需要进行计算,如：
        /// 标定板区域,标志点和评估位姿
        /// </summary>
        /// <returns>
        /// Instance of a calibration image model created for 
        /// the calibration image, supplied by <c>filename</c>
        /// </returns>
        public ProVision.Calibration.CalibImage AddImage(string fileName)
        {
            HalconDotNet.HObject img = null;
           
            ProVision.Calibration.CalibImage data = null;
            try
            {
                HalconDotNet.HOperatorSet.ReadImage(out img, new HalconDotNet.HTuple(fileName));
                data = new CalibImage(img,this);
                CalibData.Add(data);
                data.UpdateCaltab(true);
                CanCalib = (CanCalib) && (data.CanCalib==0);
                IsCalibValid = false;
            }catch(HalconDotNet.HalconException hex)
            {
                ErrorMessage = hex.Message;
                //读取图像异常
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_READING_FILE);
            }

            return data;
        }

        /// <summary>
        /// Removes the instance of the calibration images
        /// at the index <c>index</c> from the list <c>CalibData</c>
        /// 移除指定索引位置的标定图像封装类实例
        /// </summary>
        public void RemoveImage(int idx)
        {
            if(CalibData!=null)
            {
                int cnt = CalibData.Count;
                if (idx >= 0
                    && idx < cnt)
                {
                    ((ProVision.Calibration.CalibImage)CalibData[idx]).Clear();
                    CalibData.RemoveAt(idx);
                    IsCalibValid = false;
                    GetCanCalibrate();
                    NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS);
                }
            }
        }

        /// <summary>
        /// Removes all instances of the calibration images
        /// from the list <c>CalibData</c>
        /// 移除所有标定图像封装类实例<c>CalibData</c>c>
        /// </summary>
        public void RemoveImage()
        {
            if (CalibData != null)
            {
                int cnt = CalibData.Count;
                for(int i=0;i<cnt;i++)
                    ((ProVision.Calibration.CalibImage)CalibData[i]).Clear();

                CalibData.Clear();
                CanCalib = false;
                IsCalibValid = false;
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS);
            }
        }

        /// <summary>
        /// Gets the HALCON image with the index <c>index</c> in the list of
        /// calibration images <c>CalibData</c>.
        /// </summary>
        public HalconDotNet.HObject GetImageAt(int idx)
        {
            if (CalibData != null)
            {
                int cnt = CalibData.Count;
                if (idx >= 0
                    && idx < cnt)
                {
                    return ((ProVision.Calibration.CalibImage)CalibData[idx]).Image;
                }
            }

            return null;
        }


        /// <summary>
        /// Checks the whole set of calibration image models for
        /// the quality of the preprocessing step. If the basic
        /// information, i.e. the region plate and the marks
        /// and pose, was extracted in all images, then the
        /// flag <c>mCanCalib</c> is positive, which means
        /// the actual calibration process can be initiated 
        /// </summary>
        /// <returns>
        /// Flag indicating the feasibility of the calibration
        /// process
        /// 检测标定图像封装类实例集的预处理步骤中品质.
        /// 若基本信息如:标定板区域,标志点区域以及标定板评估位姿
        /// 在全部图像中都提取得到,那么标记<c>CanCaib</CanCaib>c>
        /// 为正值,即表示可以执行标定
        /// </returns>
        public bool GetCanCalibrate()
        {
            CanCalib = false;
            if (CalibData != null)
            {
                int cnt = CalibData.Count;
                int val = 0;
                for (int i=0;i<cnt;i++)
                    val += ((ProVision.Calibration.CalibImage)CalibData[i]).CanCalib;
                if (val == 0
                    && cnt > 0)
                    CanCalib = true;
            }

            return CanCalib;
        }

        /// <summary>
        /// Gets the mark centers and the poses extracted from
        /// the set of calibration images 
        /// 从标定图像封装类实例集合中提取标志点坐标已经标定板位姿
        /// </summary>
        /// <param name="rows">
        /// Tuple of row coordinates of all marks from
        /// the entire set of calibration images
        /// 标志点行坐标
        /// </param>
        /// <param name="cols">
        /// Tuple of column coordinates of all marks from 
        /// the entire set of calibration images
        /// 标志点列坐标
        /// </param>
        /// <returns>
        /// Tuple of estimated poses for the entire set
        /// of calibration images
        /// 标定板位姿
        /// </returns>
        public HalconDotNet.HTuple GetCalibrationData(out HalconDotNet.HTuple rows,out HalconDotNet.HTuple cols)
        {
            HalconDotNet.HTuple pose = new HalconDotNet.HTuple();
            rows = new HalconDotNet.HTuple();
            cols = new HalconDotNet.HTuple();
            ProVision.Calibration.CalibImage image;

            if (CalibData != null)
            {
                int cnt = CalibData.Count;

                for (int i = 0; i < cnt; i++)
                {
                    image = ((ProVision.Calibration.CalibImage)CalibData[i]);
                    pose = pose.TupleConcat(image.PlateEstimatedPose);
                    rows = rows.TupleConcat(image.MarkCenterRows);
                    cols = cols.TupleConcat(image.MarkCenterColumns);
                }              
            }

            return pose;
        }

        /// <summary>
        /// Gets the camera parameters corresponding to
        /// the supplied calibration image.
        /// 获取指定标定图像封装类实例中的相机内参
        /// </summary>
        /// <returns>Camera parameters</returns>
        public HalconDotNet.HTuple GetCameraParams(ProVision.Calibration.CalibImage image)
        {
            HalconDotNet.HTuple campar;
            int paramsListSize = 8;
            int offset = 0;
            bool areaScanPoly = false;

            if(CameraType==ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_POLY)
            {
                paramsListSize = 12;
                offset = 4;
                areaScanPoly = true;
            }

            paramsListSize += (CameraType == ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_LINE_SCAN) ? 3 : 0;

            campar = new HalconDotNet.HTuple(paramsListSize);
            campar[0] = IsTelecentric ? 0.0 : (double)FocalLength / 1000.0;

            if (areaScanPoly)
            {
                campar[1] = K1;
                campar[2] = K2;
                campar[3] = K3;
                campar[4] = P1;
                campar[5] = P2;
            }
            else
            {
                campar[1] = Kappa;
            }

            campar[2 + offset] = (double)CellWidth / 1000000.0;   // Sx -width   -> * 10^ -6 
            campar[3 + offset] = (double)CellHeight / 1000000.0;  // Sy -height  -> * 10^ -6 
            campar[4 + offset] = (double)image.ImageWidth * 0.5;                  // x -principal point 
            campar[5 + offset] = (double)image.ImageHeight * 0.5;                 // y -principal point 
            campar[6 + offset] = image.ImageWidth;                      // imagewidth 
            campar[7 + offset] = image.ImageHeight;                     // imageheight 

            if (paramsListSize == 11)
            {
                campar[8] = MotionVx / 1000000.0;
                campar[9] = MotionVy / 1000000.0;
                campar[10] = MotionVz / 1000000.0;

                campar[5 + offset] = 0;     // y -principal point = 0 for line scan camera 
            }

            return campar;
        }

        /// <summary>
        /// Tests different quality features for the calibration image 
        /// <c>cImg</c>
        /// 计算标定图像的不同品质
        /// </summary>
        /// <returns>
        /// Returns a value indicating the success or failure
        /// of the quality assessment
        /// 返回是否失败的标记
        /// </returns>
        public bool TestQualityIssues(ProVision.Calibration.CalibImage calibImage)
        {
            System.Collections.ArrayList qList;
            HalconDotNet.HObject markContours;
            HalconDotNet.HObject plateRegion;
            HalconDotNet.HObject img;
            HalconDotNet.HTuple score, score2, contrast;

            int numRegions, numContours;
            bool qualityFailure;

            img = calibImage.Image;
            qList = calibImage.QualityIssueList;
            _qualityProcedure = new QualityProcedures();
            contrast = new HalconDotNet.HTuple();
            qualityFailure = false;

            try
            {
                _qualityProcedure.Find_Caltab_Edges(img, out plateRegion,
                    out markContours, DescrpFile);

                numRegions = plateRegion.CountObj();
                numContours = markContours.CountObj();

                if (ImageAccuracyMode < ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_NONE)
                {
                    if (numRegions == 0)
                    {
                        qualityFailure = true;
                    }
                    else
                    {
                        //计算曝光品质-1
                        _qualityProcedure.Evaluate_Caltab_OverExposure(img, plateRegion, out score);
                        AddQualityIssue(qList, QUALITY_ISSUE_IMG_EXPOSURE, score.D);
                    }

                    if (numContours == 0)
                    {
                        qualityFailure = true;
                    }
                    else
                    {
                        //计算对比度品质-2,亮度均匀分布品质-3,标定板覆盖图像比例品质-4
                        _qualityProcedure.Evaluate_Caltab_Contrast_Homogeneity(img, markContours,
                            out contrast, out score, out score2);
                        AddQualityIssue(qList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_CONTRAST, score.D);
                        AddQualityIssue(qList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_HOMOGENEITY, score2.D);

                        _qualityProcedure.Evaluate_Caltab_Size(img, plateRegion, markContours, out score);
                        AddQualityIssue(qList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_CALTAB_SIZE, score.D);
                    }

                    //计算全部品质模式下:计算标定板锐度(对焦)品质-5
                    if (ImageAccuracyMode == ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_ALL)
                    {
                        _qualityProcedure.Evaluate_Caltab_Focus(img, markContours, contrast, out score);
                        AddQualityIssue(qList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_FOCUS, score.D);
                    }
                }
            }
            catch (HalconDotNet.HOperatorException e)
            {
                throw (e);
            }

            return qualityFailure;
        }

        /// <summary>
        /// Calls the actual <c>addQualityIssue</c>
        /// method, with the feature list obtained from the
        /// calibration image <c>cImg</c>
        /// 添加标定图像中获取到的品质信息
        /// </summary>
        /// <param name="cImg">
        /// Calibration image model, which has been tested for
        /// the quality feature defined with <c>type</c>
        /// </param>
        /// <param name="type">
        /// Constant starting with QUALITY_* describing one of the quality 
        /// features
        /// </param>
        /// <param name="score">
        /// Score determined for the quality feature
        /// </param>
        public void AddQualityIssue(ProVision.Calibration.CalibImage calibImage, int issueType, double issueValue)
        {
            if(calibImage!=null)
            {
                System.Collections.ArrayList qlist = calibImage.QualityIssueList;
                AddQualityIssue(qlist, issueType, issueValue);
            }
        }

        /// <summary>
        /// Adds the calculated score <c>score</c> for the quality feature 
        /// <c>type</c> to the supplied feature list <c>qList</c>
        /// 添加品质信息
        /// </summary>
        /// <param name="qList">
        /// Quality feature list
        /// </param>
        /// <param name="type">
        /// Constant starting with QUALITY_*, describing one of the quality 
        /// features
        /// </param>
        /// <param name="score">
        /// Score determined for the quality feature
        /// </param>
        public void AddQualityIssue(System.Collections.ArrayList qlist, int issueType, double issueValue)
        {
            if(qlist!=null)
            {
                int score = Convert.ToInt32(issueValue) * 100;
                if (score <= WarnLevel)
                    qlist.Add(new ProVision.Calibration.QualityIssue(issueType, issueValue));
            }
        }

        /// <summary>
        /// Tests for quality features concerning the performance 
        /// of the entire sequence of calibration images provided by
        /// the list <c>CalibData</c>
        /// 测试与列表提供的整个标定图像集的性能相关的品质特征
        /// </summary>
        public void UpdateImageSetQualityIssues()
        {
            HalconDotNet.HTuple markRows, marksCols, startPose, width, height, hScore;
            bool hasIssue;
            bool hasError;
            double minScore, score;
            int count, countL;
            ProVision.Calibration.CalibImage imgC;
            System.Collections.ArrayList qList;

            ImageSetQualityList.Clear();

            try
            {
                if (ImageSetAccuracyMode < ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_NONE)
                {
                    hasIssue = false;
                    hasError = false;
                    minScore = 1.0;

                    if ((count = CalibData.Count) == 0)
                        return;

                    for (int i = 0; i < count; i++)
                    {
                        imgC = (ProVision.Calibration.CalibImage)CalibData[i];

                        if (imgC.PlateStatus == ProVision.Calibration.CalibOnPlateAssistant.PS_QUALITY_ISSUES)
                        {
                            hasIssue = true;
                            qList = imgC.QualityIssueList;
                            countL = qList.Count;

                            for (int j = 0; j < countL; j++)
                            {
                                score = ((ProVision.Calibration.QualityIssue)qList[j]).Score;

                                if (score < minScore)
                                    minScore = score;
                            }
                        }
                        else if (imgC.PlateStatus!= ProVision.Calibration.CalibOnPlateAssistant.PS_OK)
                        {
                            hasError = true;
                        }
                    }

                    //标定图像集中有品质异常
                    if (hasError)
                    {
                        //全图品质--标定图像集中有品质异常
                        AddQualityIssue(ImageSetQualityList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_ERROR, 0.0);
                    }
                    else if (hasIssue)
                    {
                        //全图品质--标定图像集中某图像某品质较低
                        AddQualityIssue(ImageSetQualityList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_ALL_OVER, minScore);
                    }

                    if (count < 20)
                    {
                        //全图品质--标定图像集中图像数量不足
                        score = (count <= 10) ? 0.0 : (0.1 * ((double)count - 10.0));
                        AddQualityIssue(ImageSetQualityList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_NUMBER, score);
                    }

                    if (ImageSetAccuracyMode == ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_TEST_ALL 
                        && count > 0)
                    {
                        startPose = GetCalibrationData(out markRows, out marksCols);
                        width = new HalconDotNet.HTuple(((CalibImage)CalibData[0]).ImageWidth);
                        height = new HalconDotNet.HTuple(((CalibImage)CalibData[0]).ImageHeight);

                        _qualityProcedure.Evaluate_Marks_Distribution(markRows, marksCols, width, height, out hScore);
                        //全图品质--标定板图像覆盖视野的比例
                        AddQualityIssue(ImageSetQualityList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_MARKS_DISTR, hScore[0].D);

                        _qualityProcedure.Evaluate_Caltab_Tilt(startPose, out hScore);
                        //全图品质--倾斜标定板图像数量
                        AddQualityIssue(ImageSetQualityList, ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_CALTAB_TILT, hScore[0].D);
                    }
                }
            }
            catch (HalconDotNet.HOperatorException e)
            {
                ErrorMessage = e.Message;
            }
        }

        /// <summary>
        /// Applies the calibration on the set of calibration
        /// images <c>CalibData</c>
        /// 在标定图像封装集合<c>CalibData</c>上应用标定
        /// </summary>
        public void ApplyCalibration()
        {
            HalconDotNet.HTuple x, y, z, markR, markC;
            HalconDotNet.HTuple error, startPoses, startCampar, parameters;
            ProVision.Calibration.CalibImage refImg;

            IsCalibValid = false;
            ErrorMean = -1;
            //若已设置参考标定图像索引
            if(ReferenceIndex>=0)
            {
                try
                {
                    refImg = (ProVision.Calibration.CalibImage)CalibData[ReferenceIndex];
                    HalconDotNet.HOperatorSet.CaltabPoints(DescrpFile, out x, out y, out z);

                    startPoses = GetCalibrationData(out markR, out markC);
                    startCampar = GetCameraParams(refImg);
                    parameters = new HalconDotNet.HTuple("all");

                    HalconDotNet.HOperatorSet.CameraCalibration(x, y, z,
                        markR, markC,
                        startCampar,
                        startPoses,
                        parameters,
                        out CameraParams,
                        out Poses,
                        out error);
                    ErrorMean = error.D;
                    IsCalibValid = true;
                    UpdateResultVisualization();

                }catch(HalconDotNet.HalconException hex)
                {
                    ErrorMessage = hex.Message;
                    NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_IN_CALIBRATION);
                }
            }
            else
            {
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_REFINDEX_INVALID);
            }
        }

        /// <summary>
        /// Generate the iconic objects of the calibration results
        /// for display.
        /// </summary>
        private void UpdateResultVisualization()
        {
            HalconDotNet.HTuple correctedPose, refPose = null;
            double axisLen;

            HalconDotNet.HObject obj1,obj2;

            if (!CanCalib)
                return;

            if(ReferenceIndex>-1)
            {
                if (SimulatedImage != null
               && SimulatedImage.IsInitialized())
                    SimulatedImage.Dispose();

                ReferenceImage = ((ProVision.Calibration.CalibImage)CalibData[ReferenceIndex]).Image;
                refPose = GetCalibratedPose(false);

                HalconDotNet.HOperatorSet.SimCaltab(out obj1, new HalconDotNet.HTuple(DescrpFile),
                    CameraParams,
                    refPose,
                    new HalconDotNet.HTuple(128),
                    new HalconDotNet.HTuple(220),
                    new HalconDotNet.HTuple(80),
                    new HalconDotNet.HTuple(1));

                SimulatedImage = obj1;
                correctedPose = GetCalibratedPose(true);
                axisLen = ((ProVision.Calibration.CalibImage)CalibData[ReferenceIndex]).EstimatedPlateSize;

                _qualityProcedure.Get_3D_Coord_System(ReferenceImage,
                    out obj2,
                    CameraParams,
                    correctedPose,
                    new HalconDotNet.HTuple(axisLen / 2));

                ReferenceWCS = obj2;

                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS);
            }
        }

        /// <summary>
        /// Saves the calibrated camera parameters in the file
        /// defined by <c>filename</c>
        /// 保存相机内参到指定路径文件
        /// </summary>
        public void SaveCameraParams(string fileName)
        {
            if(IsCalibValid)
            {
                try
                {
                    HalconDotNet.HOperatorSet.WriteCamPar(CameraParams,new HalconDotNet.HTuple(fileName));
                }catch(HalconDotNet.HalconException hex)
                {
                    ErrorMessage = hex.Message;
                    NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_WRITE_CALIB_RESULTS);
                }
            }
        }      

        /// <summary>
        /// Saves the pose obtained from the camera calibration
        /// in the file, defined by <c>filename</c>
        /// 保存相机外参到指定路径文件
        /// [注:标定板原点平移至图像原点位置]
        /// </summary>
        public void SaveCameraPose(string fileName)
        {
            if (IsCalibValid)
            {
                try
                {
                    HalconDotNet.HTuple pose = GetCalibratedPose(true);
                    HalconDotNet.HOperatorSet.WritePose(pose, new HalconDotNet.HTuple(fileName));
                }
                catch (HalconDotNet.HalconException hex)
                {
                    ErrorMessage = hex.Message;
                    NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_WRITE_CALIB_RESULTS);
                }
            }
        }

        /// <summary>
        /// Returns calibration results
        /// </summary>
        /// <param name="camParams">
        /// Calibrated internal camera parameters 
        /// </param>
        /// <param name="refPose">
        /// Calibrated external camera parameters
        /// </param>
        public void GetCalibratedResult(out HalconDotNet.HTuple camParams,out HalconDotNet.HTuple refPose)
        {
            camParams = CameraParams;
            refPose = GetCalibratedPose(true);
        }

        /// <summary>
        /// Returns the calibrated reference pose
        /// 获取参考位姿
        /// </summary>
        /// <param name="corrected">是否校正到图像原点</param>
        /// <returns></returns>
        public HalconDotNet.HTuple GetCalibratedPose(bool corrected)
        {
            HalconDotNet.HTuple tX, tY, tZ, correctedPose, refPose = null;
            if (!IsCalibValid)
                return new HalconDotNet.HTuple(1.0,-1.0,0.0);
            //每一组位姿7个元素,Poses是多组位姿集合
            if (Poses.Length >= 7 * (ReferenceIndex + 1))
                refPose = Poses.TupleSelectRange(new HalconDotNet.HTuple(7*ReferenceIndex),
                    new HalconDotNet.HTuple(7 * ReferenceIndex+6));
            if (!corrected)
                return refPose;
            tX = new HalconDotNet.HTuple(0);
            tY = new HalconDotNet.HTuple(0);
            tZ = new HalconDotNet.HTuple(Thickness/1000.0);//毫米转成米

            if (AtImgCoord)
                HalconDotNet.HOperatorSet.ImagePointsToWorldPlane(CameraParams, refPose,
                    new HalconDotNet.HTuple(0), new HalconDotNet.HTuple(0),
                    new HalconDotNet.HTuple("m"), out tX, out tY);
            HalconDotNet.HOperatorSet.SetOriginPose(refPose, tX, tY, tZ, out correctedPose);
            return correctedPose;
        }

        /// <summary>
        /// Loads camera parameters from file
        /// 导入相机内参
        /// </summary>
        /// <param name="camParFile">File name</param>
        /// <returns>Success or failure of load process</returns>
        public bool ImportCameraParams(string camParFile)
        {
            HalconDotNet.HTuple campar;
            int offset = 0;
            bool areaScanPoly = false;

            try
            {
                HalconDotNet.HOperatorSet.ReadCamPar(new HalconDotNet.HTuple(camParFile), out campar);
                // -- load camera parameters --
                switch (campar.Length)
                {
                    case 8:
                        CameraType = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_DIV;
                        break;
                    case 11:
                        CameraType = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_LINE_SCAN;
                        break;
                    case 12:
                        CameraType = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_POLY;
                        offset = 4;
                        areaScanPoly = true;
                        break;
                    default:
                        CameraType = -1;
                        break;
                }

                FocalLength = campar[0] * 1000;
                if (FocalLength == 0.0)
                    IsTelecentric = true;
                else IsTelecentric = false;

                if (areaScanPoly)
                {
                    K1 = campar[1];
                    K2 = campar[2];
                    K3 = campar[3];
                    P1 = campar[4];
                    P2 = campar[5];
                }
                else
                {
                    Kappa = campar[1];
                }

                CellWidth = campar[2 + offset] * 1000000.0;
                CellHeight = campar[3 + offset] * 1000000.0;

                // line scan camera
                if (campar.Length == 11)
                {
                    MotionVx = campar[8].D * 1000000.0;
                    MotionVy = campar[9].D * 1000000.0;
                    MotionVz = campar[10].D * 1000000.0;
                }

                Update(true);
            }
            catch(HalconDotNet.HalconException hex)
            {
                ErrorMessage = hex.Message;
                NotifyCaliObserver(ProVision.Calibration.CalibOnPlateAssistant.ERR_READING_FILE);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 重置相机参数
        /// </summary>
        /// <param name="camTypeDefault">是否使用默认相机模型</param>
        public void ResetCameraSetup(bool camTypeDefault)
        {
            if (camTypeDefault)
                CameraType = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_DIV;
            Thickness = 1.00;
            CellWidth = 8.300;
            CellHeight = 8.300;
            FocalLength = 8.000;
            IsTelecentric = false;
            Kappa = 0.0;
            K1 = 0.0;
            K2 = 0.0;
            K3 = 0.0;
            P1 = 0.0;
            P2 = 0.0;
            MotionVx = 0.0;
            MotionVy = 500.0;
            MotionVz = 0.0;

            Update(true);
        }
    }

    public delegate void CalibOnPlateDelegate(int val);
}
