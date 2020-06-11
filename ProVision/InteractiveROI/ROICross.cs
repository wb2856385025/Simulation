using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       ROICross
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.InteractiveROI
 * File      Name：       ROICross
 * Creating  Time：       5/26/2020 11:12:06 AM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.InteractiveROI
{
    public class ROICross : ROI
    {
        private double _locateRow, _locateCol; //中心点-0

        public ROICross()
        {
            NumHandles = 1;       //一个定位中心点
            ActiveHandleIdx = 0;  //活动操作柄在中点，以便于移动位置
            ROIShape = ProVision.InteractiveROI.ROIShape.ROI_SHAPE_CIRCLE;
        }

        public override void CreateROI(double row, double col)
        {
            _locateRow = row;
            _locateCol = col;
        }

        public override void Draw(HalconDotNet.HTuple hwndHandle)
        {
            HalconDotNet.HObject xldCross = new HalconDotNet.HObject();
            xldCross.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out xldCross, new HalconDotNet.HTuple(_locateRow), new HalconDotNet.HTuple(_locateCol), 9999, 0);          
            HalconDotNet.HOperatorSet.DispObj(xldCross, hwndHandle);

            HalconDotNet.HObject rec1 = new HalconDotNet.HObject();
            rec1.Dispose();
            HalconDotNet.HOperatorSet.GenRectangle2(out rec1,
                new HalconDotNet.HTuple(_locateRow),
                new HalconDotNet.HTuple(_locateCol),
                new HalconDotNet.HTuple(0),
                new HalconDotNet.HTuple(5),
                new HalconDotNet.HTuple(5));
            HalconDotNet.HOperatorSet.DispObj(rec1, hwndHandle);           
        }

        public override double GetDistanceFromStartPoint(double row, double col)
        {
            HalconDotNet.HTuple dist = new HalconDotNet.HTuple(0);
            HalconDotNet.HOperatorSet.DistancePp(_locateRow, _locateCol, row, col, out dist);
            return dist;
        }

        public override double DistanceToClosestHandle(double row, double col)
        {
            double[] val = new double[NumHandles];
            HalconDotNet.HTuple dist;
            HalconDotNet.HOperatorSet.DistancePp(new HalconDotNet.HTuple(row),
                new HalconDotNet.HTuple(col),
                new HalconDotNet.HTuple(_locateRow),
                new HalconDotNet.HTuple(_locateCol),
                out dist);
            val[0] = dist[0].D;

            double minvalue = 0.0;
            int idx = 0;
            if (Communal.Functions.MinValueAndIndex(val, out minvalue, out idx))
            {
                ActiveHandleIdx = idx;
            }

            return minvalue;
        }

        public override void DisplayActiveHandle(HalconDotNet.HTuple hwndHandle)
        {
            HalconDotNet.HObject rec = new HalconDotNet.HObject();
            rec.Dispose();
            switch (ActiveHandleIdx)
            {
                case 0:
                    {
                        HalconDotNet.HOperatorSet.GenRectangle2(out rec,
                         new HalconDotNet.HTuple(_locateRow),
                         new HalconDotNet.HTuple(_locateCol),
                         new HalconDotNet.HTuple(0),
                         new HalconDotNet.HTuple(5),
                         new HalconDotNet.HTuple(5));
                        HalconDotNet.HOperatorSet.DispObj(rec, hwndHandle);
                    }
                    break;
                default:
                    break;
            }

        }

        public override void MoveByHandle(double row, double col)
        {
            HalconDotNet.HTuple distance;
            double shiftR, shiftC;
            switch (ActiveHandleIdx)
            {
                // handle at circle center(translate ROI):平移
                case 0:
                    shiftR = row - _locateRow;
                    shiftC = col - _locateCol;

                    _locateRow = row;
                    _locateCol = col;               
                    break;             
                default:
                    break;
            }
        }

        public override HalconDotNet.HObject GetModelRegion()
        {
            HalconDotNet.HObject rg = new HalconDotNet.HObject(); 
            HalconDotNet.HObject crs = new HalconDotNet.HObject();

            crs.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out crs, _locateRow, _locateCol, 9999, 0);
            rg.Dispose();
            HalconDotNet.HOperatorSet.GenRegionContourXld(crs, out rg, new HalconDotNet.HTuple("filled"));

            crs.Dispose();
            HalconDotNet.HOperatorSet.GenRectangle2(out crs, _locateRow, _locateCol, 0, 5, 5);
            HalconDotNet.HOperatorSet.ConcatObj(rg, crs, out rg);          
            return rg;
        }

        /// <summary>
        /// 获取十字中心坐标
        /// [注:索引下标,
        /// 0-中心行坐标
        /// 1-中心列坐标]
        /// </summary>
        /// <returns></returns>
        public override HalconDotNet.HTuple GetModelData()
        {
            return new HalconDotNet.HTuple(new double[] { _locateRow, _locateCol });
        }
    }
}
