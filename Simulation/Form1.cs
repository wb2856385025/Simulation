using Simulation.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        public static ParameterSetting setting;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"F:\桌面S\智显项目\模板\左边";
            setting = new ParameterSetting(path,"左边膜");
            setting.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"F:\桌面S\智显项目\模板\右边";
            setting = new ParameterSetting(path, "右边膜");
            setting.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"F:\桌面S\智显项目\模板\玻璃";
            setting = new ParameterSetting(path, "玻璃");
            setting.ShowDialog();
        }
    }
}
