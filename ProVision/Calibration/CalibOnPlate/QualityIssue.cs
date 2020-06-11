using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       QualityIssue
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.Calibration
 * File      Name：       QualityIssue
 * Creating  Time：       5/10/2020 5:13:58 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.Calibration
{
    /// <summary>
    /// This auxiliary class is used to reference the operation 
    /// type for the quality assessment with the achieved score.
    /// 该辅助类用于根据品质评估的分数,进行引用操作类型
    /// </summary>
    public class QualityIssue
    {
        /// <summary>
        /// Constant starting with QUALITY_ISSUE_*, defined in the class
        /// CalibOnPlateAssistant.
        /// 标定图像品质提示
        /// </summary>
        private int _qIssue;
        public int Issue { get { return _qIssue; } }

        /// <summary>
        /// Score obtained from the quality assessment
        /// 标定图像品质评估得分
        /// </summary>
        private double _qualityScore;
        public double Score { get { return _qualityScore; } }

        /// <summary>
        /// Initialize an instance
        /// 初始化品质评估提示类实例
        /// </summary>
        /// <param name="issueType">
        /// Constant starting with QUALITY_ISSUE_*, defined in the class
        /// CalibOnPlateAssistant.
        /// 标定图像品质提示 
        /// </param>
        /// <param name="score">
        /// Score obtained from the quality assessment
        /// 标定图像品质评估得分 
        /// </param>
        public QualityIssue(int issueType, double score)
        {
            _qIssue = issueType;
            _qualityScore = score;
        }
    }
}
