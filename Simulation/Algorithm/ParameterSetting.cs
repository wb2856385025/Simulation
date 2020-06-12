using HalconDotNet;
using ProVision.MatchModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Algorithm
{
    public partial class ParameterSetting : Form
    {

        /// <summary>
        /// 图像
        /// </summary>
        public HObject _Image;

        /// <summary>
        ///   搜索区域
        /// </summary>
        private HObject SearchRegion;

        /// <summary>
        ///    模板句柄
        /// </summary>
        private HTuple ModelFile;

        /// <summary>
        /// 路径
        /// </summary>
        private string _Path;

        /// <summary>
        /// 模板匹配窗口
        /// </summary>
        private FrmMatchModel frmMatch2;

        /// <summary>
        /// 视觉算法数据
        /// </summary>
        public Attribute attri;

        public static ParameterSetting Parameter;

        private string Name;

        public ParameterSetting()
        {
            Parameter =this;
            InitializeComponent();
            ConfigManager.ReadVisionPara(@"F:\桌面S\智显项目\模板");
        }

        public ParameterSetting(string path, string name):this()
        {
            Name = name;
            _Path = path;
            ShowVisionData();
        }
        public ParameterSetting(string path, string name,HObject Image ) : this()
        {
            _Image = Image;
            Name = name;
            _Path = path;
            ShowVisionData();
        }



        private void ParameterSetting_Load(object sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        /// 初始化加载数据
        /// </summary>
        private void ShowVisionData()
        {

            switch (Name)
            {
                case "左边膜":
                    {
                        numericUpDown9.Value = (decimal)attri.LeftAngleStart;
                        numericUpDown8.Value = (decimal)attri.LeftAngleExtent;
                        numericUpDown7.Value = (decimal)attri.LeftMinScore;
                        numericUpDown10.Value = (decimal)attri.LeftRealityX;
                        numericUpDown11.Value = (decimal)attri.LeftRealityY;
                        label15.Text = attri.LeftPixelX.ToString();
                        label16.Text = attri.LeftPixelY.ToString();
                    }
                    break;
                case "右边膜":
                    {
                        numericUpDown9.Value = (decimal)attri.RightAngleStart;
                        numericUpDown8.Value = (decimal)attri.RightAngleExtent;
                        numericUpDown7.Value = (decimal)attri.RightMinScore;
                        numericUpDown10.Value = (decimal)attri.RightRealityX;
                        numericUpDown11.Value = (decimal)attri.RightRealityY;
                        label15.Text = attri.RightPixelX.ToString();
                        label16.Text = attri.RightPixelY.ToString();
                    }
                    break;
                case "玻璃":
                    {
                        numericUpDown9.Value = (decimal)attri.GlassAngleStart;
                        numericUpDown8.Value = (decimal)attri.GlassAngleExtent;
                        numericUpDown7.Value = (decimal)attri.GlassMinScore;
                        numericUpDown10.Value = (decimal)attri.GlassRealityX;
                        numericUpDown11.Value = (decimal)attri.GlassRealityY;
                        label15.Text = attri.GlassPixelX.ToString();
                        label16.Text = attri.GlassPixelY.ToString();

                    }
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// 玻璃创建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(_Path )) System.IO.Directory.CreateDirectory(_Path);//创建该文件夹

            if (_Image != null && _Image.IsInitialized())
            {
                frmMatch2 = new FrmMatchModel(_Image,_Path);
                frmMatch2.ShowDialog();
            }
            else
            {
                frmMatch2 = new FrmMatchModel(_Path);
                frmMatch2.ShowDialog();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown Numeric = (sender as NumericUpDown);

            switch (Numeric.Tag.ToString())
            {                
                case "7":
                    {
                        attri.GlassAngleStart = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "8":
                    {
                        attri.GlassAngleExtent = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "9":
                    {
                        attri.GlassMinScore = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                default:
                    break;
            }

        }
        
        
        /// <summary>
        /// 玻璃匹配测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            HTuple row, col, Angle, Score;
            bool judge = ReadModelFromFile(_Path);
            if (judge == true)
            {
                bool jud = FindModel(_Image, new HTuple(attri.LeftAngleStart), new HTuple(attri.LeftAngleExtent),
                    new HTuple((attri.LeftMinScore / 100)), out row, out col, out Angle, out Score);
                if (jud == true&&row.Length!=0)
                {
                    if (frmMatch2!=null)
                    {
                        attri.GlassRow = frmMatch2.ModelPose[0];
                        attri.GlassCol = frmMatch2.ModelPose[1];
                        attri.GlassAngle = frmMatch2.ModelPose[2];
                    }
                    else
                    {
                        attri.GlassRow = row;
                        attri.GlassCol = col;
                        attri.GlassAngle = Angle;
                    }
                    
                    windowctrlMessage("分数：" + Score.D.ToString("f2"),
                        new HalconDotNet.HTuple("image"),
                        new HalconDotNet.HTuple(1),
                        new HalconDotNet.HTuple(1),
                        new HalconDotNet.HTuple("green"),
                        new HalconDotNet.HTuple("false"));
                    HOperatorSet.DispCross(hWindowControl1.HalconWindow, row, col, 60, Angle);
                }
                else
                {
                    MessageBox.Show("匹配失败！");
                }
            }
            else
            {
                MessageBox.Show("请创建模板");
            }
        }
       
       

        /// <summary>
        /// 加载图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                DialogResult dr = dlg.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    path = dlg.FileName;
                    UpdateHImageFromFile( path);
                    DisplayObject(hWindowControl1,_Image);
                }
            }
        }

        private void ParameterSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigManager.Load(@"F:\桌面S\智显项目\模板");            
        }

        #region  公有方法

        /// <summary>
        /// 从文件中更新当前处理图像
        /// </summary>
        /// <param name="index"></param>
        /// <param name="filename"></param>
        public void UpdateHImageFromFile( string filename)
        {
            HObject img;
            HOperatorSet.ReadImage(out img, filename);
            _Image = img;           

        }

        /// <summary>
        /// 在主界面显示
        /// </summary>
        /// <param name="screenIdx"></param>
        /// <param name="hObj"></param>
        public void DisplayObject(HWindowControl hWindow, HObject hObj)
        {
            if (hObj != null && hWindow != null)
            {
                try
                {
                    HTuple hv_r1, hv_w1;
                    HOperatorSet.GetImageSize(hObj, out hv_r1, out hv_w1);
                    HOperatorSet.SetPart(hWindow.HalconWindow, 0, 0, hv_w1, hv_r1);
                    HOperatorSet.SetColor(hWindow.HalconWindow, "red");                    
                    HOperatorSet.DispObj(hObj, hWindow.HalconWindow);
                }
                catch (HalconDotNet.HalconException hex)
                {
                    Console.WriteLine("Error:" + hex.GetErrorMessage());
                }

            }

        }

        /// <summary>
        /// 加载模板
        /// </summary>
        /// <param name="modelDirectory">路径</param>
        /// /// <param name="Index">下标</param>
        public bool ReadModelFromFile(string modelDirectory)
        {

            HTuple exist ,modelID;
            HObject Region;
            HalconDotNet.HOperatorSet.FileExists(modelDirectory + "\\ModelFile.shm", out exist);
            if ((int)exist != 0)
            {
                HalconDotNet.HOperatorSet.FileExists(modelDirectory + "\\SearchRegion.hobj", out exist);
                if ((int)exist != 0)
                {
                    HalconDotNet.HOperatorSet.ReadRegion(out Region, modelDirectory + "\\SearchRegion.hobj");
                    HOperatorSet.ReadShapeModel(modelDirectory + "\\ModelFile.shm", out modelID);
                    HOperatorSet.SetShapeModelParam(modelID, "timeout", 3000);
                    ModelFile= modelID;
                    SearchRegion = Region;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 像素比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            HTuple width=0,height=0;
            if (_Image != null && _Image.IsInitialized())
            {
                HOperatorSet.GetImageSize(_Image, out width, out height);
            }
            else
            {
                return;
            }
            
            if (Name=="左边膜")
            {                
                attri.LeftRealityX = (double)numericUpDown10.Value;
                
                attri.LeftPixelX = width.D / (double)numericUpDown10.Value;

            }
            else if (Name == "右边膜")
            {
                attri.RightRealityX = (double)numericUpDown10.Value;       
               
                attri.RightPixelX = width.D / (double)numericUpDown10.Value;
            }
            else if(Name=="玻璃")
            {
                attri.GlassRealityX = (double)numericUpDown10.Value;
                
                attri.GlassPixelX = width.D / (double)numericUpDown10.Value;
            }
            label15.Text = (width.D / (double)numericUpDown10.Value).ToString("f2");


        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            HTuple width = 0, height = 0;
            if (_Image != null && _Image.IsInitialized())
            {
                HOperatorSet.GetImageSize(_Image, out width, out height);
            }
            else
            {
                return;
            }

            if (Name == "左边膜")
            {
                attri.LeftRealityY = (double)numericUpDown11.Value;

                attri.LeftPixelY = width.D / (double)numericUpDown11.Value;

            }
            else if (Name == "右边膜")
            {
                attri.RightRealityY = (double)numericUpDown11.Value;

                attri.RightPixelY= width.D / (double)numericUpDown11.Value;
            }
            else if (Name == "玻璃")
            {
                attri.GlassRealityY = (double)numericUpDown11.Value;

                attri.GlassPixelY = width.D / (double)numericUpDown11.Value;
            }
            label16.Text = (height.D / (double)numericUpDown11.Value).ToString("f2");
        }

        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hWindow">窗口句柄</param>
        /// <param name="_hImage">图像</param>
        /// <param name="modelDirectory">路径</param>
        /// <param name="judge">判断有无搜索区域 (true 有  false 无)</param>
        /// <param name="row">模板中心row</param>
        /// <param name="col">模板中心col</param>
        /// <returns></returns>
        public bool FindModel(HObject _hImage,HTuple Start,HTuple Scope,HTuple Scores, out HTuple row, out HTuple col, out HTuple Angle, out HTuple Score)
        {
            if (ModelFile != null && SearchRegion != null&& _hImage != null)
            {
                HalconDotNet.HObject ImageReduced;

                HOperatorSet.ReduceDomain(_hImage, SearchRegion, out ImageReduced);
                try
                {
                    HOperatorSet.FindShapeModel(ImageReduced, ModelFile, Start.TupleRad(),
                        Scope.TupleRad(), Scores, 1, 0.5, "least_squares", (new HTuple(4)).TupleConcat(1), 0.9, out row, out col, out Angle, out Score);
                    return true;

                }
                catch (Exception e)
                {
                    row = 0;
                    col = 0;
                    Angle = 0;
                    Score = 0;
                    return false;
                }
            }
           
            row = 0;
            col = 0;
            Angle = 0;
            Score = 0;
            return false;
        }

        public void windowctrlMessage(HalconDotNet.HTuple hv_String, HalconDotNet.HTuple hv_CoordSystem, HalconDotNet.HTuple hv_Row, HalconDotNet.HTuple hv_Column, HalconDotNet.HTuple hv_Color, HalconDotNet.HTuple hv_Box)
        {
            try
            {
                if (hWindowControl1 != null
                 && hWindowControl1.IsHandleCreated)
                {
                    hWindowControl1.Invoke(new System.Windows.Forms.MethodInvoker(
                    () => {
                        ProVision.Communal.Functions.SetDisplayFont(hWindowControl1.HalconWindow, 26, "mono", "true", "false");
                        ProVision.Communal.Functions.DispMessage(hWindowControl1.HalconWindow,
                                                            hv_String, hv_CoordSystem, hv_Row, hv_Column, hv_Color, hv_Box);
                    }));
                }
            }
            catch (HalconDotNet.HalconException hex)
            {
            }
        }


        #endregion

    }
}
