using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Tool;

namespace Simulation.Algorithm
{
    public class Attribute
    {
        #region 膜左边定位数据
        /// <summary>
        /// 左边初始角
        /// </summary>
        public int LeftAngleStart { set; get; }
        /// <summary>
        /// 左边旋转角范围
        /// </summary>
        public int LeftAngleExtent { set; get; }
        /// <summary>
        /// 左边最小分数
        /// </summary>
        public double LeftMinScore { set; get; }
        /// <summary>
        /// 创建模板Row
        /// </summary>
        public double LeftRow { set; get; }
        /// <summary>
        /// 创建模板Col
        /// </summary>
        public double LeftCol { set; get; }
        /// <summary>
        /// 创建模板Angle
        /// </summary>
        public double LeftAngle { set; get; }
        /// <summary>
        /// 左边像素比X
        /// </summary>
        public double LeftPixelX { set; get; }
        /// <summary>
        /// 左边像素比Y
        /// </summary>
        public double LeftPixelY { set; get; }

        /// <summary>
        /// 左边像素比实际距离
        /// </summary>
        public double LeftRealityX { set; get; }
        /// <summary>
        /// 左边像素比实际距离
        /// </summary>
        public double LeftRealityY { set; get; }

        #endregion

        #region 膜右边定位数据
        /// <summary>
        /// 右边初始角
        /// </summary>
        public int RightAngleStart { set; get; }
        /// <summary>
        /// 右边旋转角范围
        /// </summary>
        public int RightAngleExtent { set; get; }
        /// <summary>
        /// 右边最小分数
        /// </summary>
        public double RightMinScore { set; get; }
        /// <summary>
        /// 创建模板Row
        /// </summary>
        public double RightRow { set; get; }
        /// <summary>
        /// 创建模板Col
        /// </summary>
        public double RightCol { set; get; }
        /// <summary>
        /// 创建模板Angle
        /// </summary>
        public double RightAngle { set; get; }

        /// <summary>
        /// 右边像素比X
        /// </summary>
        public double RightPixelX { set; get; }
        /// <summary>
        /// 右边像素比Y
        /// </summary>
        public double RightPixelY { set; get; }
        /// <summary>
        /// 右边像素比实际距离
        /// </summary>
        public double RightRealityX { set; get; }
        /// <summary>
        /// 右边像素比实际距离
        /// </summary>
        public double RightRealityY { set; get; }

        #endregion

        #region 玻璃定位数据
        /// <summary>
        /// 玻璃初始角
        /// </summary>
        public int GlassAngleStart { set; get; }
        /// <summary>
        /// 玻璃旋转角范围
        /// </summary>
        public int GlassAngleExtent { set; get; }
        /// <summary>
        /// 玻璃最小分数
        /// </summary>
        public double GlassMinScore { set; get; }

        /// <summary>
        /// 创建模板Row
        /// </summary>
        public double GlassRow { set; get; }
        /// <summary>
        /// 创建模板Col
        /// </summary>
        public double GlassCol { set; get; }
        /// <summary>
        /// 创建模板Angle
        /// </summary>
        public double GlassAngle { set; get; }

        /// <summary>
        /// 玻璃像素比X
        /// </summary>
        public double GlassPixelX { set; get; }
        /// <summary>
        /// 玻璃像素比Y
        /// </summary>
        public double GlassPixelY { set; get; }

        /// <summary>
        /// 玻璃像素比实际距离
        /// </summary>
        public double GlassRealityX { set; get; }
        /// <summary>
        /// 玻璃像素比实际距离
        /// </summary>
        public double GlassRealityY { set; get; }
        #endregion

        #region 基础数据




        #endregion



    }


    public class ConfigManager
    {

        public const string VISIONPARA_CONFIG_FILE_NAME = "VisionPara.config";
        public static Attribute CfgVisionPara = new Attribute();
        public static void Load(string path)
        {
            CfgVisionPara = ParameterSetting.Parameter.attri;
            if (CfgVisionPara == null)
            {
                CfgVisionPara = new Attribute();
            }
            if (CfgVisionPara != null && path != null)
            {

                Serialization.SaveToXml(CfgVisionPara, path + "\\VisionPara.config");
            }
            else
            {
                MessageBox.Show("路径不存在！");
            }

        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="path"></param>
        public static void ReadVisionPara(string path)
        {
            HalconDotNet.HTuple exist = null;
            HalconDotNet.HOperatorSet.FileExists(path + "\\VisionPara.config", out exist);
            if ((int)exist != 0)
            {
                ParameterSetting.Parameter.attri = global::Vision.Tool.Serialization.LoadFromXml(typeof(Attribute), path + "\\VisionPara.config") as Attribute;
                if (ParameterSetting.Parameter.attri == null)
                {
                    ParameterSetting.Parameter.attri = new Attribute();
                }
            }
        }
        

        public static void NumberTestFiles(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dirPath);
                int result = GetFilesCount(dirInfo);
                if (result > 300)
                {
                    deleteDirFiles(dirPath);
                }
            }

        }
        /// <summary>
        /// 删除指定文件夹下所有的文件
        /// </summary>
        /// <param name="strPath"></param>
        private static void deleteDirFiles(string strPath)
        {
            //删除这个目录下的所有子目录
            if (Directory.GetDirectories(strPath).Length > 0)
            {
                foreach (string var in Directory.GetDirectories(strPath))
                {
                    Directory.Delete(var, true);
                }
            }
            //删除这个目录下的所有文件
            if (Directory.GetFiles(strPath).Length > 0)
            {
                foreach (string var in Directory.GetFiles(strPath))
                {
                    File.Delete(var);
                }
            }
        }
        /// <summary>
        /// 返回文件数量
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        private static int GetFilesCount(DirectoryInfo dirInfo)
        {
            int totalFile = 0;
            //totalFile += dirInfo.GetFiles().Length;//获取全部文件
            totalFile += dirInfo.GetFiles("*.bmp").Length;//获取某种格式
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
    }




}
