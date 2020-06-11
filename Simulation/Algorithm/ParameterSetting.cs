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
        /// 0、左边膜  1、右边膜  2、玻璃
        /// </summary>
        private HalconDotNet.HObject[] _Image = new HalconDotNet.HObject[3];

        /// <summary>
        /// 0、左边膜  1、右边膜  2、玻璃    搜索区域
        /// </summary>
        private HObject[] SearchRegion = new HObject[3];

        /// <summary>
        /// 0、左边膜  1、右边膜  2、玻璃    模板句柄
        /// </summary>
        private HTuple[] ModelFile = new HTuple[3];

        /// <summary>
        /// 路径
        /// </summary>
        private string _Path;

        /// <summary>
        /// 0、frmMatch 左边膜,  1、frmMatch1 右边膜,  2、frmMatch2 玻璃
        /// </summary>
        private FrmMatchModel frmMatch,frmMatch1,frmMatch2;

        /// <summary>
        /// 视觉算法数据
        /// </summary>
        public Attribute attri;

        public static ParameterSetting Parameter;

        public ParameterSetting()
        {
            Parameter =this;
            InitializeComponent();
            attri = new Attribute();
           
            _Path = @"F:\桌面S\智显项目\模板";
            ConfigManager.ReadVisionPara(_Path);
        }




        private void ParameterSetting_Load(object sender, EventArgs e)
        {
            ShowVisionData();
        }
        
        private void ShowVisionData()
        {
            numericUpDown1.Value = (decimal)attri.LeftAngleStart;
            numericUpDown2.Value = (decimal)attri.LeftAngleExtent;
            numericUpDown3.Value = (decimal)attri.LeftMinScore;

            numericUpDown6.Value = (decimal)attri.RightAngleStart;
            numericUpDown5.Value = (decimal)attri.RightAngleExtent;
            numericUpDown4.Value = (decimal)attri.RightMinScore;

            numericUpDown9.Value = (decimal)attri.GlassAngleStart;
            numericUpDown8.Value = (decimal)attri.GlassAngleExtent;
            numericUpDown7.Value = (decimal)attri.GlassMinScore;

            numericUpDown10.Value = (decimal)attri.LeftRealityX;
            numericUpDown11.Value = (decimal)attri.LeftRealityY;
            label15.Text = attri.LeftPixelX.ToString();
            label16.Text = attri.LeftPixelY.ToString();

            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

        }

        /// <summary>
        /// 右边膜创建模板
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(_Path + "/右边膜")) System.IO.Directory.CreateDirectory(_Path + "/右边膜");//创建该文件夹

            if (_Image[1] != null && _Image[1].IsInitialized())
            {
                frmMatch1 = new FrmMatchModel(_Image[1],_Path+"/右边膜");
                frmMatch1.ShowDialog();
            }
            else
            {
                frmMatch1 = new FrmMatchModel(_Path + "/右边膜");
                frmMatch1.ShowDialog();
            }
        }
        
        /// <summary>
        /// 玻璃创建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(_Path + "/玻璃")) System.IO.Directory.CreateDirectory(_Path + "/玻璃");//创建该文件夹

            if (_Image[2] != null && _Image[2].IsInitialized())
            {
                frmMatch2 = new FrmMatchModel(_Image[2],_Path+"/玻璃");
                frmMatch2.ShowDialog();
            }
            else
            {
                frmMatch2 = new FrmMatchModel(_Path + "/玻璃");
                frmMatch2.ShowDialog();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown Numeric = (sender as NumericUpDown);

            switch (Numeric.Tag.ToString())
            {
                case "1":
                    {
                        attri.LeftAngleStart = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "2":
                    {
                        attri.LeftAngleExtent = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "3":
                    {
                        attri.LeftMinScore = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "4":
                    {
                        attri.RightAngleStart = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "5":
                    {
                        attri.RightAngleExtent = int.Parse(Numeric.Value.ToString());
                    }
                    break;
                case "6":
                    {
                        attri.RightMinScore = int.Parse(Numeric.Value.ToString());
                    }
                    break;
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
        /// 左边膜匹配测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            HTuple row, col, Angle, Score;
            bool judge= ReadModelFromFile(_Path+"/左边膜",0);
            if (judge==true)
            {
                bool jud = FindModel(_Image[0],0,new HTuple(attri.LeftAngleStart),new HTuple(attri.LeftAngleExtent),
                    new HTuple((attri.LeftMinScore/100)),out row,out col,out Angle,out Score);
                if (jud==true&& row.Length!=0)
                {
                    attri.LeftRow = frmMatch.ModelPose[0];
                    attri.LeftCol = frmMatch.ModelPose[1];
                    attri.LeftAngle = frmMatch.ModelPose[2];
                    windowctrlMessage("分数："+ Score.D.ToString("f2"),
                        new HalconDotNet.HTuple("image"),
                        new HalconDotNet.HTuple(1),
                        new HalconDotNet.HTuple(1),
                        new HalconDotNet.HTuple("green"),
                        new HalconDotNet.HTuple("false"));
                    HOperatorSet.DispCross(hWindowControl1.HalconWindow, row, col,60, Angle);
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
        /// 右边膜匹配测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            HTuple row, col, Angle, Score;
            bool judge = ReadModelFromFile(_Path + "/右边膜", 1);
            if (judge == true)
            {
                bool jud = FindModel(_Image[1], 1, new HTuple(attri.LeftAngleStart), new HTuple(attri.LeftAngleExtent),
                    new HTuple((attri.LeftMinScore / 100)), out row, out col, out Angle, out Score);
                //HOperatorSet.DispObj(_Image[1],hWindowControl1.HalconWindow);
                //HOperatorSet.DispObj(SearchRegion[1],hWindowControl1.HalconWindow);
                if (jud == true&&row.Length!=0)
                {
                    attri.RightRow = frmMatch1.ModelPose[0];
                    attri.RightCol = frmMatch1.ModelPose[1];
                    attri.RightAngle = frmMatch1.ModelPose[2];
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
        /// 玻璃匹配测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            HTuple row, col, Angle, Score;
            bool judge = ReadModelFromFile(_Path + "/玻璃", 2);
            if (judge == true)
            {
                bool jud = FindModel(_Image[2], 2, new HTuple(attri.LeftAngleStart), new HTuple(attri.LeftAngleExtent),
                    new HTuple((attri.LeftMinScore / 100)), out row, out col, out Angle, out Score);
                if (jud == true&&row.Length!=0)
                {
                    attri.GlassRow = frmMatch2.ModelPose[0];
                    attri.GlassCol = frmMatch2.ModelPose[1];
                    attri.GlassAngle = frmMatch2.ModelPose[2];
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
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = comboBox1.SelectedIndex;
            if (_Image[Index]!=null&&_Image[Index].IsInitialized())
            {
                HOperatorSet.DispObj(_Image[Index], hWindowControl1.HalconWindow);
            }
            else
            {
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            }
            switch (Index)
            {
                case 0:
                    {
                        numericUpDown10.Value =(decimal)attri.LeftRealityX;
                        numericUpDown11.Value =(decimal)attri.LeftRealityY;
                        label15.Text = attri.LeftPixelX.ToString();
                        label16.Text = attri.LeftPixelY.ToString();
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = false;
                        groupBox4.Enabled = false;
                        
                    }
                    break;
                case 1:
                    {
                        numericUpDown10.Value = (decimal)attri.RightRealityX;
                        numericUpDown11.Value = (decimal)attri.RightRealityY;
                        label15.Text = attri.RightPixelX.ToString();
                        label16.Text = attri.RightPixelY.ToString();
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = true;
                        groupBox4.Enabled = false;
                    }
                    break;
                case 2:
                    {
                        numericUpDown10.Value = (decimal)attri.GlassRealityX;
                        numericUpDown11.Value = (decimal)attri.GlassRealityY;
                        label15.Text = attri.GlassPixelX.ToString();
                        label16.Text = attri.GlassPixelY.ToString();
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = false;
                        groupBox4.Enabled = true;
                    }
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 左边膜创建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!System.IO.Directory.Exists(_Path+ "/左边膜")) System.IO.Directory.CreateDirectory(_Path + "/左边膜");//创建该文件夹
            if (_Image[0]!=null&&_Image[0].IsInitialized())
            {
                frmMatch = new FrmMatchModel(_Image[0], _Path+"/左边膜");
                frmMatch.ShowDialog();
            }
            else
            {
                frmMatch = new FrmMatchModel(_Path + "/左边膜");
                frmMatch.ShowDialog();
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
                    UpdateHImageFromFile(comboBox1.SelectedIndex, path);
                    DisplayObject(hWindowControl1,_Image[comboBox1.SelectedIndex]);
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
        public void UpdateHImageFromFile(int index, string filename)
        {
            HObject img;
            HOperatorSet.ReadImage(out img, filename);
            _Image[index] = img;           

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
        public bool ReadModelFromFile(string modelDirectory,int Index)
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
                    ModelFile[Index] = modelID;
                    SearchRegion[Index] = Region;
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
            int Index = comboBox1.SelectedIndex;
            if (Index==0)
            {                
                attri.LeftRealityX = (double)numericUpDown10.Value;
                if (_Image[0]!=null&&_Image[0].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[0],out width,out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }
                
                attri.LeftPixelX = width.D / (double)numericUpDown10.Value;

            }
            else if (Index==1)
            {
                attri.RightRealityX = (double)numericUpDown10.Value;
                
                if (_Image[1] != null && _Image[1].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[1], out width, out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }

                attri.RightPixelX = width.D / (double)numericUpDown10.Value;
            }
            else if(Index==2)
            {
                attri.GlassRealityX = (double)numericUpDown10.Value;

                if (_Image[2] != null && _Image[2].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[2], out width, out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }

                attri.GlassPixelX = width.D / (double)numericUpDown10.Value;
            }
            label15.Text = (width.D / (double)numericUpDown10.Value).ToString();


        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            HTuple width = 0, height = 0;
            int Index = comboBox1.SelectedIndex;
            if (Index == 0)
            {
                attri.LeftRealityY = (double)numericUpDown11.Value;
                if (_Image[0] != null && _Image[0].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[0], out width, out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }

                attri.LeftPixelY = height.D / (double)numericUpDown11.Value;

            }
            else if (Index == 1)
            {
                attri.RightRealityY = (double)numericUpDown11.Value;

                if (_Image[1] != null && _Image[1].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[1], out width, out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }

                attri.RightPixelY = height.D / (double)numericUpDown11.Value;
            }
            else if (Index == 2)
            {
                attri.GlassRealityY = (double)numericUpDown11.Value;

                if (_Image[2] != null && _Image[2].IsInitialized())
                {
                    HOperatorSet.GetImageSize(_Image[2], out width, out height);
                }
                else
                {
                    MessageBox.Show("请加载图片！");
                }

                attri.GlassPixelY = height.D / (double)numericUpDown11.Value;
            }
            label16.Text = (height.D / (double)numericUpDown11.Value).ToString();
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
        public bool FindModel(HObject _hImage, int Index,HTuple Start,HTuple Scope,HTuple Scores, out HTuple row, out HTuple col, out HTuple Angle, out HTuple Score)
        {
            if (ModelFile[Index] != null && SearchRegion[Index] != null&& _hImage != null)
            {
                HalconDotNet.HObject ImageReduced;

                HOperatorSet.ReduceDomain(_hImage, SearchRegion[Index], out ImageReduced);
                try
                {
                    HOperatorSet.FindShapeModel(ImageReduced, ModelFile[Index], Start.TupleRad(),
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
