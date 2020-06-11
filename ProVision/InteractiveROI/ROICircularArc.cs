﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       ROICircularArc
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.InteractiveROI
 * File      Name：       ROICircularArc
 * Creating  Time：       10/8/2019 5:06:19 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.InteractiveROI
{
    public class ROICircularArc : ROI
    {
        private double _locateRow, _locateCol; //圆弧操作柄--圆心--坐标(该点用来定位圆)-0
        private double _startRow, _startCol;   //圆弧操作柄--起点--坐标-1
        private double _sizeRow, _sizeCol;     //圆弧作柄--边点--坐标(该点用来控制圆的大小)-2      
        private double _extentRow, _extentCol; //圆弧操作柄--终点--坐标-3

        private double _radius;
        private double _startPhi, _extentPhi;  //圆弧起始角和角范围

        private HalconDotNet.HObject _circularArc, _arrowHandle;
        private string _circularArcDir;
        private double PI, TwoPI;

        public ROICircularArc()
        {
            NumHandles = 4;        //一个定位中心点+一个缩放角点(在圆弧上)+一个起始点+一个终止点
            ActiveHandleIdx = 0;   //活动操作柄在中点，以便于移动位置
            ROIShape = ProVision.InteractiveROI.ROIShape.ROI_SHAPE_CIRCULARARC;

            _circularArc = new HalconDotNet.HObject();
            _circularArc.GenEmptyObj();
            _circularArcDir = "";

            _arrowHandle = new HalconDotNet.HObject();
            _arrowHandle.GenEmptyObj();

            PI = Math.PI;
            TwoPI = 2 * PI;

        }

        public override void CreateROI(double row, double col)
        {
            _locateRow = row;
            _locateCol = col;
            _radius = 60;

            _sizeRow = _locateRow;
            _sizeCol = _locateCol - _radius;

            _startPhi = PI * 0.25;
            _extentPhi = PI * 1.5;
            _circularArcDir = "positive";

            //计算起点与终点的坐标
            DetermineArcHandles();

            //计算表示弧段方向的箭头
            DetermineArrowHandle();
        }

        public override void Draw(HalconDotNet.HTuple hwndHandle)
        {
            _circularArc.Dispose();
            HalconDotNet.HOperatorSet.GenCircleContourXld(out _circularArc,
                new HalconDotNet.HTuple(_locateRow),
                new HalconDotNet.HTuple(_locateCol),
                new HalconDotNet.HTuple(_radius),
                new HalconDotNet.HTuple(_startPhi),
                new HalconDotNet.HTuple(_startPhi + _extentPhi),
                new HalconDotNet.HTuple(_circularArcDir),
                new HalconDotNet.HTuple(1.0));
            HalconDotNet.HOperatorSet.DispObj(_circularArc, hwndHandle);

            HalconDotNet.HObject rec1, rec2, rec3;

            HalconDotNet.HOperatorSet.GenRectangle2(out rec1,
                new HalconDotNet.HTuple(_sizeRow),
                new HalconDotNet.HTuple(_sizeCol),
                new HalconDotNet.HTuple(0),
                new HalconDotNet.HTuple(5),
                new HalconDotNet.HTuple(5));
            HalconDotNet.HOperatorSet.DispObj(rec1, hwndHandle);

            HalconDotNet.HOperatorSet.GenRectangle2(out rec2,
              new HalconDotNet.HTuple(_locateRow),
              new HalconDotNet.HTuple(_locateCol),
              new HalconDotNet.HTuple(0),
              new HalconDotNet.HTuple(5),
              new HalconDotNet.HTuple(5));
            HalconDotNet.HOperatorSet.DispObj(rec2, hwndHandle);

            HalconDotNet.HOperatorSet.GenRectangle2(out rec3,
             new HalconDotNet.HTuple(_startRow),
             new HalconDotNet.HTuple(_startCol),
             new HalconDotNet.HTuple(_startPhi),
             new HalconDotNet.HTuple(10),
             new HalconDotNet.HTuple(2));
            HalconDotNet.HOperatorSet.DispObj(rec3, hwndHandle);

            if (_arrowHandle != null
                && _arrowHandle.IsInitialized())
                HalconDotNet.HOperatorSet.DispObj(_arrowHandle, hwndHandle);
        }

        public override double GetDistanceFromStartPoint(double row, double col)
        {
            return base.GetDistanceFromStartPoint(row, col);
        }

        public override double DistanceToClosestHandle(double row, double col)
        {
            double[] val = new double[NumHandles];
            HalconDotNet.HTuple dist;
            HalconDotNet.HOperatorSet.DistancePp(new HalconDotNet.HTuple(new double[] { row, row, row, row }),
                new HalconDotNet.HTuple(new double[] { col, col, col, col }),
                new HalconDotNet.HTuple(new double[] { _locateRow, _sizeRow, _startRow, _extentRow }),
                new HalconDotNet.HTuple(new double[] { _locateCol, _sizeCol, _startCol, _extentCol }),
                out dist);
            val[0] = dist[0].D;
            val[1] = dist[1].D;
            val[2] = dist[2].D;
            val[3] = dist[3].D;

            double minvalue = 0.0;
            int idx = 0;
            if (Communal.Functions.MinValueAndIndex(val, out minvalue, out idx))
            {
                this.ActiveHandleIdx = idx;
            }

            return minvalue;
        }

        public override void DisplayActiveHandle(HalconDotNet.HTuple hwndHandle)
        {
            HalconDotNet.HObject rec = new HalconDotNet.HObject();
            rec.Dispose();
            switch (ActiveHandleIdx)
            {
                //定位圆心
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
                //缩放边点
                case 1:
                    {
                        HalconDotNet.HOperatorSet.GenRectangle2(out rec,
                         new HalconDotNet.HTuple(_sizeRow),
                         new HalconDotNet.HTuple(_sizeCol),
                         new HalconDotNet.HTuple(0),
                         new HalconDotNet.HTuple(5),
                         new HalconDotNet.HTuple(5));
                        HalconDotNet.HOperatorSet.DispObj(rec, hwndHandle);
                    }
                    break;
                //弧段起始角点
                case 2:
                    {
                        HalconDotNet.HOperatorSet.GenRectangle2(out rec,
                         new HalconDotNet.HTuple(_startRow),
                         new HalconDotNet.HTuple(_startCol),
                         new HalconDotNet.HTuple(_startPhi),
                         new HalconDotNet.HTuple(10),
                         new HalconDotNet.HTuple(2));
                        HalconDotNet.HOperatorSet.DispObj(rec, hwndHandle);
                    }
                    break;
                //弧段终止角点(箭头)
                case 3:
                    if (_arrowHandle != null
                         && _arrowHandle.IsInitialized())
                        HalconDotNet.HOperatorSet.DispObj(_arrowHandle, hwndHandle);
                    break;
                default:
                    break;
            }
        }

        public override void MoveByHandle(double row, double col)
        {
            //base.MoveByHandle(row, col);
            HalconDotNet.HTuple distance;
            double shiftR, shiftC, dirR, dirC, prior, next, vMax, vMin;
            switch (ActiveHandleIdx)
            {
                // handle at center of circular arc (translate ROI):平移
                case 0:
                    shiftR = row - _locateRow;
                    shiftC = col - _locateCol;

                    //更新定位圆心
                    _locateRow = row;
                    _locateCol = col;

                    //更新缩放边点
                    _sizeRow += shiftR;
                    _sizeCol += shiftC;

                    //规划弧段
                    DetermineArcHandles();
                    break;
                // handle at border of circular arc (scale ROI):缩放
                case 1:
                    _sizeRow = row;
                    _sizeCol = col;
                    HalconDotNet.HOperatorSet.DistancePp(row, col, new HalconDotNet.HTuple(_locateRow), new HalconDotNet.HTuple(_locateCol), out distance);
                    _radius = distance[0].D;
                    DetermineArcHandles();
                    break;
                // handle at start of circular arc (cut ROI):改变弧段长短
                case 2:
                    dirR = row - _locateRow;
                    dirC = col - _locateCol;
                    _startPhi = System.Math.Atan2(-dirR, dirC); //计算起始角点对应向量角，注意得到的角描述范围[-π，π]
                    if (_startPhi < 0)
                        _startPhi += this.TwoPI;                  //起始角点对应的向量角转换描述范围:[0,2π]，以便于计算弧段长度
                    DetermineStartHandle();
                    prior = _extentPhi;                         //前次角度量程
                    _extentPhi = HalconDotNet.HMisc.AngleLl(_locateRow, _locateCol, _startRow, _startCol,
                        _locateRow, _locateCol, _extentRow, _extentCol); //计算向量到角，描述范围[-π,π]

                    #region 待理清楚
                    if (_extentPhi < 0 && prior > this.PI * 0.8)
                        _extentPhi += this.TwoPI;
                    else if (_extentPhi > 0 && prior < (-this.PI * 0.7))
                        _extentPhi -= this.TwoPI;
                    #endregion

                    break;
                // handle at extent of circular arc (cut ROI):改变弧段长短
                case 3:
                    dirR = row - _locateRow;
                    dirC = col - _locateCol;
                    prior = _extentPhi;                    //前次角度量程
                    next = System.Math.Atan2(-dirR, dirC);   //计算终止角点对应向量角，注意得到的角描述范围[-π，π]
                    if (next < 0)
                        next += this.TwoPI;                  //终止角点对应的向量角转换描述范围:[0,2π]，以便于计算弧段长度
                    #region 待理清楚
                    if (_circularArcDir == "positive" && _startPhi >= next)
                        _extentPhi = (next + this.TwoPI) - _startPhi;
                    else if (_circularArcDir == "positive" && _startPhi < next)
                        _extentPhi = next - _startPhi;
                    else if (_circularArcDir == "negative" && _startPhi >= next)
                        _extentPhi = next - _startPhi;
                    else if (_circularArcDir == "negative" && _startPhi < next)
                        _extentPhi = next - (_startPhi + this.TwoPI);
                    vMax = System.Math.Max(System.Math.Abs(prior), System.Math.Abs(_extentPhi)); //最大角量程
                    vMin = System.Math.Min(System.Math.Abs(prior), System.Math.Abs(_extentPhi)); //最小角量程

                    if ((vMax - vMin) >= this.PI)
                        _extentPhi = (_circularArcDir == "positive") ? -1.0 * vMin : vMin;

                    #endregion

                    DetermineExtentHandle();
                    break;
                default:
                    break;
            }

            _circularArcDir = (_extentPhi < 0) ? "negative" : "positive";
            DetermineArrowHandle();
        }

        public override HalconDotNet.HObject GetModelRegion()
        {
            if (_circularArc != null
                 && _circularArc.IsInitialized())
                _circularArc.Dispose();

            HalconDotNet.HOperatorSet.GenCircleContourXld(out _circularArc,
                new HalconDotNet.HTuple(_locateRow),
                new HalconDotNet.HTuple(_locateCol),
                new HalconDotNet.HTuple(_radius),
                new HalconDotNet.HTuple(_startPhi),
                new HalconDotNet.HTuple(_startPhi + _extentPhi),
                new HalconDotNet.HTuple(_circularArcDir),
                new HalconDotNet.HTuple(1.0));
            HalconDotNet.HObject rg = new HalconDotNet.HObject();
            rg.Dispose();
            HalconDotNet.HOperatorSet.GenRegionContourXld(_circularArc, out rg, "margin");
            return rg;
        }

        /// <summary>
        /// 获取圆弧的中心坐标,圆弧半径,起始角,角范围
        /// [注:索引下标,
        /// 0-中心行坐标
        /// 1-中心列坐标
        /// 2-圆弧半径
        /// 3-圆弧起始角(弧度)
        /// 4-圆弧角范围(弧度)]
        /// </summary>
        /// <returns></returns>
        public override HalconDotNet.HTuple GetModelData()
        {
            return new HalconDotNet.HTuple(new double[] { _locateRow, _locateCol, _radius, _startPhi, _extentPhi });
        }

        #region 辅助函数
        private void DetermineArcHandles()
        {
            DetermineStartHandle();
            DetermineExtentHandle();
        }

        /// <summary>
        /// Auxiliary method to determine the positions of 
        /// the StartHandle for CircularArc
        /// 确定起始角点坐标
        /// </summary>
        private void DetermineStartHandle()
        {
            //-------------------注解---------------------------//
            /*
             * 将图像坐标系用右手规则描述，即Row-O-Column顺序描述；
             * 描述角度是以Column轴正方向为起始，逆时针旋转，则相对于
             * Row-O-Column坐标系的起始角参考轴来说，是超前90度，即
             * 描述角在以右手描述的坐标系里，描述角度是Phi+90°的,得到如下：
             *  mStartRow = mLocateRow + mRadius * Math.Cos(mStartPhi+π/2);
             *  mStartCol = mLocateCol + mRadius * Math.Sin(mStartPhi+π/2);
             *  整理后即得
             */
            //--------------------------------------------------//
            _startRow = _locateRow - _radius * Math.Sin(_startPhi);
            _startCol = _locateCol + _radius * Math.Cos(_startPhi);
        }

        /// <summary>
        /// Auxiliary method to determine the positions of 
        /// the ExtentHandle for CircularArc
        /// 确定终止角点坐标
        /// </summary>
        private void DetermineExtentHandle()
        {
            //-------------------注解---------------------------//
            /*
             * 将图像坐标系用右手规则描述，即Row-O-Column顺序描述；
             * 描述角度是以Column轴正方向为起始，逆时针旋转，则相对于
             * Row-O-Column坐标系的起始角参考轴来说，是超前90度，即
             * 描述角在以右手描述的坐标系里，描述角度是Phi+90°的,得到如下：           
             *  mExtentRow = mLocateRow + mRadius * Math.Cos(mStartPhi + mExtentPhi+π/2);
             *  mExtentCol = mLocateCol + mRadius * Math.Sin(mStartPhi + mExtentPhi+π/2);
             *  整理后即得
             */
            //--------------------------------------------------//
            _extentRow = _locateRow - _radius * Math.Sin(_startPhi + _extentPhi);
            _extentCol = _locateCol + _radius * Math.Cos(_startPhi + _extentPhi);
        }

        /// <summary>
        /// Auxiliary method to display an arrow at the extent arc position
        /// 在终止角点位置显示箭头
        /// </summary>
        private void DetermineArrowHandle()
        {
            double row1, col1, row2, col2;
            double rowP1, colP1, rowP2, colP2;
            double lth, dr, dc, halfHeadWidth, sign, angle;
            double headlth = 15, headwth = 15;

            _arrowHandle.Dispose();
            _arrowHandle.GenEmptyObj();

            //终止角点坐标
            row2 = _extentRow;
            col2 = _extentCol;
            //向量A:圆心指向圆弧终止角点;向量B:垂直向量A,且向量B的终点为B
            //向量A角(弧度)：即终止角a,a=(mStartPhi+mExtentPhi)
            //向量B角(弧度):定义为b,逆时针圆弧时,b=a+(π/2);顺时针圆弧时,b=a-(π/2)
            //向量B在图像坐标系中的角(弧度)：定义为c,c=b+(π/2);
            angle = (_startPhi + _extentPhi);

            //* 将图像坐标系用右手规则描述，即Row-O-Column顺序描述；
            //row2-row1=L * Math.Cos(c);col2-col1=L * Math.Sin(c)
            //整理后,即得:
            //逆时针圆弧时:row1=row2+L * Math.Cos(a);col1=col2+L * Math.Sin(a)
            //顺时针圆弧时:row1=row2-L * Math.Cos(a);col1=col2-L * Math.Sin(a)

            sign = (_circularArcDir == "positive") ? 1.0 : -1.0;

            row1 = row2 + sign * 20 * Math.Cos(angle);
            col1 = col2 + sign * 20 * Math.Sin(angle);

            lth = HalconDotNet.HMisc.DistancePp(row1, col1, row2, col2); //lth,即是上式的20

            if (lth == 0)
                lth = -1;

            dr = (row2 - row1) / lth;
            dc = (col2 - col1) / lth;
            halfHeadWidth = headwth / 2.0;

            rowP1 = row1 + (lth - headlth) * dr + halfHeadWidth * dc;
            colP1 = col1 + (lth - headlth) * dc - halfHeadWidth * dr;

            rowP2 = row1 + (lth - headlth) * dr - halfHeadWidth * dc;
            colP2 = col1 + (lth - headlth) * dc + halfHeadWidth * dr;

            if (lth == -1)
            {
                //产生点
                HalconDotNet.HOperatorSet.GenContourPolygonXld(out _arrowHandle, new HalconDotNet.HTuple(row1), new HalconDotNet.HTuple(col1));
            }
            else
            {
                HalconDotNet.HOperatorSet.GenContourPolygonXld(out _arrowHandle,
                   new HalconDotNet.HTuple(new double[] { row1, row2, rowP1, row2, rowP2 }),
                   new HalconDotNet.HTuple(new double[] { col1, col2, colP1, col2, colP2 }));//顺序成组，成线段
            }
        }

        #endregion 

    }
}
