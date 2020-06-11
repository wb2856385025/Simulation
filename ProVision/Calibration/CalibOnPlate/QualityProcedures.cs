using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       QualityProcedures
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProVision.Calibration
 * File      Name：       QualityProcedures
 * Creating  Time：       5/10/2020 5:16:15 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProVision.Calibration
{
    /// <summary>
    /// This class contains all procedures computing the quality of the 
    /// calibration images. At first the region plate and the marks must
    /// be determined using the procedure call <c>find_caltab_edges</c>.
    /// If a plate region and marks were detected in the calibration image,
    /// the quality of the specified calibration plate can be measured for 
    /// each image in terms of:
    /// - homogeneity of illumination
    /// - contrast and homogeneity of the marks
    /// - the area covered by the plate in the image
    /// - the sharpness of the plate
    /// 
    /// 该类包含计算标定图像品质的所有方法.首先标定板和特征点的区域必须用
    /// "Find_Caltab_Edges"方法进行提取;若在标定图像提取到标定板和特征点的区域
    /// 每幅图像可以从以下几点来计算指定标定板(图像)的品质:
    /// --图像亮度的均匀性
    /// --标定图像中特征点的对比度和均匀性
    /// --标定图像中标定板覆盖的区域
    /// --标定图像中标定板的锐度
    /// 
    /// And all over quality of the sequence of calibration images
    /// can also be determined using the following properties:
    /// - number of calibration images used 
    /// - distribution of the calibration marks in the volume
    ///   determined by the camera
    /// - amount of tilt used for the calibration plates
    /// - all over quality performance described by the
    ///   lowest quality score of the image set
    ///   
    ///   上述关于标定图像品质的几点同样可以通过以下几个属性计算得到:
    ///   --标定图像的数量
    ///   --标定板上特征点在相机视野内的分布
    ///   --标定板的倾斜程度
    ///   --标定图像的所有品质描述值以图像集内该品质最低值来描述
    /// </summary>
    public class QualityProcedures
    {
        /// <summary>
        /// Evaluates the sharpness of the calibration plate in the calibration
        /// image.
        /// 评估标定图像中标定板的锐度
        /// </summary>
        public void Evaluate_Caltab_Focus(HalconDotNet.HObject ho_Image, HalconDotNet.HObject ho_Marks,
            HalconDotNet.HTuple hv_Contrast, out HalconDotNet.HTuple hv_FocusScore)
        {
            // Local iconic variables 

            HalconDotNet.HObject ho_Region, ho_RegionUnion, ho_ImageReduced;
            HalconDotNet.HObject ho_DerivGauss;

            // Local control variables 

            HalconDotNet.HTuple hv_Number, hv_MeanGradient, hv_Deviation;
            HalconDotNet.HTuple hv_MinScore, hv_RawResult;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Region);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_DerivGauss);

            hv_FocusScore = 0.0;

            //对比度为零,返回
            if ((int)(new HalconDotNet.HTuple(hv_Contrast.TupleEqual(0))) != 0)
            {
                ho_Region.Dispose();
                ho_RegionUnion.Dispose();
                ho_ImageReduced.Dispose();
                ho_DerivGauss.Dispose();

                return;
            }

            //标定板中特征点个数小于3个,返回
            HalconDotNet.HOperatorSet.CountObj(ho_Marks, out hv_Number);
            if ((int)(new HalconDotNet.HTuple(hv_Number.TupleLess(3))) != 0)
            {
                ho_Region.Dispose();
                ho_RegionUnion.Dispose();
                ho_ImageReduced.Dispose();
                ho_DerivGauss.Dispose();

                return;
            }

            //
            ho_Region.Dispose();
            HalconDotNet.HOperatorSet.GenRegionContourXld(ho_Marks, out ho_Region, "margin");
            ho_RegionUnion.Dispose();
            HalconDotNet.HOperatorSet.Union1(ho_Region, out ho_RegionUnion);
            ho_ImageReduced.Dispose();
            HalconDotNet.HOperatorSet.ReduceDomain(ho_Image, ho_RegionUnion, out ho_ImageReduced);
            ho_DerivGauss.Dispose();
            HalconDotNet.HOperatorSet.DerivateGauss(ho_ImageReduced, out ho_DerivGauss, 0.7, "gradient");
            HalconDotNet.HOperatorSet.Intensity(ho_Region, ho_DerivGauss, out hv_MeanGradient, out hv_Deviation);
            hv_MinScore = 0.25;
            //Normalize the Gradient with the contrast
            hv_RawResult = hv_MeanGradient / hv_Contrast;
            hv_FocusScore = (((hv_RawResult * 4.5)).TupleSort())[(new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_RawResult.TupleLength()
                )) / 20.0)).TupleRound()];
            hv_FocusScore = ((((((((hv_FocusScore - hv_MinScore)).TupleConcat(0.0))).TupleMax()
                )).TupleConcat(1.0))).TupleMin();
            ho_Region.Dispose();
            ho_RegionUnion.Dispose();
            ho_ImageReduced.Dispose();
            ho_DerivGauss.Dispose();

            return;
        }

        /// <summary>
        /// Extracts the calibration plate and the marks on this plate
        /// for the supplied image
        /// 提取给定图像中的标定板和特征点
        /// </summary>
        public void Find_Caltab_Edges(HalconDotNet.HObject ho_Image,
            out HalconDotNet.HObject ho_Caltab,
            out HalconDotNet.HObject ho_Marks,
            HalconDotNet.HTuple hv_DescriptionFileName)
        {
            // Stack for temporary objects 
            HalconDotNet.HObject[] OTemp = new HalconDotNet.HObject[20];

            // Local iconic variables 

            HalconDotNet.HObject ho_ImageMean, ho_RegionDynThresh, ho_RegionBorder;
            HalconDotNet.HObject ho_RegionOpening1, ho_ConnectedRegions1, ho_SelectedRegions4;
            HalconDotNet.HObject ho_SelectedRegions5, ho_RegionBorder2, ho_RegionTrans;
            HalconDotNet.HObject ho_RegionErosion, ho_RegionBorder1, ho_RegionDilation2;
            HalconDotNet.HObject ho_RegionDifference1, ho_RegionOpening, ho_ConnectedRegions;
            HalconDotNet.HObject ho_SelectedRegions2, ho_SelectedRegions, ho_RegionFillUp;
            HalconDotNet.HObject ho_SelectedRegions1, ho_RegionIntersection, ho_RegionFillUp1;
            HalconDotNet.HObject ho_RegionDifference, ho_CaltabCandidates, ho_ObjectSelected = null;
            HalconDotNet.HObject ho_ConnectedMarks = null, ho_ObjectSelectedCaltab = null;
            HalconDotNet.HObject ho_RegionFillUpCand, ho_MarksCand, ho_RegionDilation1;
            HalconDotNet.HObject ho_ImageReduced, ho_DefaultEdges, ho_UnionContours;
            HalconDotNet.HObject ho_SelectedXLD, ho_SelectedXLD1;


            // Local control variables 

            HalconDotNet.HTuple hv_Width, hv_Height, hv_EstimatedCaltabSize;
            HalconDotNet.HTuple hv_EstimatedMarkSize, hv_Number, hv_X, hv_Y, hv_Z;
            HalconDotNet.HTuple hv_NumDescrMarks, hv_Index, hv_NumberMarks = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_Anisometry = new HalconDotNet.HTuple(), hv_Bulkiness = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_StructureFactor = new HalconDotNet.HTuple(), hv_AreaMarks = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_Row = new HalconDotNet.HTuple(), hv_Column = new HalconDotNet.HTuple(), hv_Rectangularity;
            HalconDotNet.HTuple hv_SortedIndex, hv_IndexBest, hv_MinContrast, hv_NumberCand;
            HalconDotNet.HTuple hv_Area, hv_Dummy, hv_DummyS, hv_AreaMedian;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Caltab);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Marks);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ImageMean);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionBorder);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionOpening1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ConnectedRegions1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedRegions4);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedRegions5);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionBorder2);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionErosion);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionBorder1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDilation2);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDifference1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedRegions2);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionFillUp);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionIntersection);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionFillUp1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDifference);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CaltabCandidates);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ConnectedMarks);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ObjectSelectedCaltab);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionFillUpCand);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_MarksCand);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDilation1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_DefaultEdges);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_UnionContours);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedXLD);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_SelectedXLD1);

            //
            ho_Marks.Dispose();
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Marks);
            ho_Caltab.Dispose();
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Caltab);
            HalconDotNet.HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            hv_EstimatedCaltabSize = (((((hv_Width.TupleConcat(hv_Height))).TupleMax()) / 2.5)).TupleRound()
                ;
            hv_EstimatedMarkSize = ((hv_EstimatedCaltabSize / 12.0)).TupleRound();
            ho_ImageMean.Dispose();
            HalconDotNet.HOperatorSet.MeanImage(ho_Image, out ho_ImageMean, hv_EstimatedMarkSize * 3, hv_EstimatedMarkSize * 3);
            ho_RegionDynThresh.Dispose();
            HalconDotNet.HOperatorSet.DynThreshold(ho_Image, ho_ImageMean, out ho_RegionDynThresh, 3,
                "light");
            ho_RegionBorder.Dispose();
            HalconDotNet.HOperatorSet.DynThreshold(ho_Image, ho_ImageMean, out ho_RegionBorder, 20, "dark");
            ho_RegionOpening1.Dispose();
            HalconDotNet.HOperatorSet.OpeningCircle(ho_RegionBorder, out ho_RegionOpening1, 1.5);
            ho_ConnectedRegions1.Dispose();
            HalconDotNet.HOperatorSet.Connection(ho_RegionOpening1, out ho_ConnectedRegions1);
            ho_SelectedRegions4.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_ConnectedRegions1, out ho_SelectedRegions4, "compactness",
                "and", 17, 50);
            ho_SelectedRegions5.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_SelectedRegions4, out ho_SelectedRegions5, "anisometry",
                "and", 1, 1.4);
            ho_RegionBorder2.Dispose();
            HalconDotNet.HOperatorSet.Boundary(ho_SelectedRegions5, out ho_RegionBorder2, "outer");
            ho_SelectedRegions5.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_RegionBorder2, out ho_SelectedRegions5, "circularity",
                "and", 0.006, 1);
            ho_RegionTrans.Dispose();
            HalconDotNet.HOperatorSet.ShapeTrans(ho_SelectedRegions5, out ho_RegionTrans, "rectangle2");
            ho_RegionErosion.Dispose();
            HalconDotNet.HOperatorSet.ErosionCircle(ho_RegionTrans, out ho_RegionErosion, (hv_Width / 640.0) * 5.5);
            ho_RegionBorder1.Dispose();
            HalconDotNet.HOperatorSet.Boundary(ho_RegionErosion, out ho_RegionBorder1, "inner");
            ho_RegionDilation2.Dispose();
            HalconDotNet.HOperatorSet.DilationCircle(ho_RegionBorder1, out ho_RegionDilation2, 3.5);
            ho_RegionDifference1.Dispose();
            HalconDotNet.HOperatorSet.Difference(ho_RegionDynThresh, ho_RegionDilation2, out ho_RegionDifference1
                );
            ho_RegionOpening.Dispose();
            HalconDotNet.HOperatorSet.OpeningCircle(ho_RegionDifference1, out ho_RegionOpening, (hv_Width / 640) * 1.5);
            ho_ConnectedRegions.Dispose();
            HalconDotNet.HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions2.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions2, "area",
                "and", (hv_EstimatedCaltabSize.TuplePow(2)) / 10, (hv_EstimatedCaltabSize.TuplePow(
                2)) * 5);
            ho_SelectedRegions.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_SelectedRegions2, out ho_SelectedRegions, "compactness",
                "and", 1.4, 10);
            ho_RegionFillUp.Dispose();
            HalconDotNet.HOperatorSet.FillUp(ho_SelectedRegions, out ho_RegionFillUp);
            ho_SelectedRegions1.Dispose();
            HalconDotNet.HOperatorSet.SelectShape(ho_RegionFillUp, out ho_SelectedRegions1, "rectangularity",
                "and", 0.6, 1);
            ho_RegionIntersection.Dispose();
            HalconDotNet.HOperatorSet.Intersection(ho_SelectedRegions1, ho_RegionDynThresh, out ho_RegionIntersection
                );
            ho_RegionFillUp1.Dispose();
            HalconDotNet.HOperatorSet.FillUp(ho_RegionIntersection, out ho_RegionFillUp1);
            ho_RegionDifference.Dispose();
            HalconDotNet.HOperatorSet.Difference(ho_RegionFillUp1, ho_RegionIntersection, out ho_RegionDifference
                );
            HalconDotNet.HOperatorSet.CountObj(ho_RegionDifference, out hv_Number);
            ho_CaltabCandidates.Dispose();
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CaltabCandidates);
            HalconDotNet.HOperatorSet.CaltabPoints(hv_DescriptionFileName, out hv_X, out hv_Y, out hv_Z);
            hv_NumDescrMarks = new HalconDotNet.HTuple(hv_X.TupleLength());
            for (hv_Index = 1; hv_Index.Continue(hv_Number, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HalconDotNet.HOperatorSet.SelectObj(ho_RegionDifference, out ho_ObjectSelected, hv_Index);
                ho_ConnectedMarks.Dispose();
                HalconDotNet.HOperatorSet.Connection(ho_ObjectSelected, out ho_ConnectedMarks);
                HalconDotNet.HOperatorSet.CountObj(ho_ConnectedMarks, out hv_NumberMarks);
                HalconDotNet.HOperatorSet.Eccentricity(ho_ConnectedMarks, out hv_Anisometry, out hv_Bulkiness,
                    out hv_StructureFactor);
                HalconDotNet.HOperatorSet.AreaCenter(ho_ConnectedMarks, out hv_AreaMarks, out hv_Row, out hv_Column);
                ho_ObjectSelectedCaltab.Dispose();
                HalconDotNet.HOperatorSet.SelectObj(ho_RegionIntersection, out ho_ObjectSelectedCaltab,
                    hv_Index);
                if ((int)((new HalconDotNet.HTuple((new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_NumberMarks.TupleGreaterEqual(
                    10))).TupleAnd(new HalconDotNet.HTuple(hv_NumberMarks.TupleLess(hv_NumDescrMarks + 20))))).TupleAnd(
                    new HalconDotNet.HTuple(((((hv_Anisometry.TupleSort())).TupleSelect((new HalconDotNet.HTuple(hv_Anisometry.TupleLength()
                    )) / 2))).TupleLess(2))))).TupleAnd(new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_AreaMarks.TupleMean()
                    )).TupleGreater(20)))) != 0)
                {
                    HalconDotNet.HOperatorSet.ConcatObj(ho_CaltabCandidates, ho_ObjectSelectedCaltab, out OTemp[0]
                        );
                    ho_CaltabCandidates.Dispose();
                    ho_CaltabCandidates = OTemp[0];
                }
            }
            ho_RegionFillUpCand.Dispose();
            HalconDotNet.HOperatorSet.FillUp(ho_CaltabCandidates, out ho_RegionFillUpCand);
            HalconDotNet.HOperatorSet.Rectangularity(ho_RegionFillUpCand, out hv_Rectangularity);
            if ((int)(new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_Rectangularity.TupleLength())).TupleEqual(
                0))) != 0)
            {
                ho_ImageMean.Dispose();
                ho_RegionDynThresh.Dispose();
                ho_RegionBorder.Dispose();
                ho_RegionOpening1.Dispose();
                ho_ConnectedRegions1.Dispose();
                ho_SelectedRegions4.Dispose();
                ho_SelectedRegions5.Dispose();
                ho_RegionBorder2.Dispose();
                ho_RegionTrans.Dispose();
                ho_RegionErosion.Dispose();
                ho_RegionBorder1.Dispose();
                ho_RegionDilation2.Dispose();
                ho_RegionDifference1.Dispose();
                ho_RegionOpening.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionFillUp.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_RegionIntersection.Dispose();
                ho_RegionFillUp1.Dispose();
                ho_RegionDifference.Dispose();
                ho_CaltabCandidates.Dispose();
                ho_ObjectSelected.Dispose();
                ho_ConnectedMarks.Dispose();
                ho_ObjectSelectedCaltab.Dispose();
                ho_RegionFillUpCand.Dispose();
                ho_MarksCand.Dispose();
                ho_RegionDilation1.Dispose();
                ho_ImageReduced.Dispose();
                ho_DefaultEdges.Dispose();
                ho_UnionContours.Dispose();
                ho_SelectedXLD.Dispose();
                ho_SelectedXLD1.Dispose();

                return;
            }
            hv_SortedIndex = hv_Rectangularity.TupleSortIndex();
            hv_IndexBest = (((hv_SortedIndex.TupleInverse())).TupleSelect(0)) + 1;
            ho_Caltab.Dispose();
            HalconDotNet.HOperatorSet.SelectObj(ho_RegionFillUpCand, out ho_Caltab, hv_IndexBest);
            ho_RegionFillUp.Dispose();
            HalconDotNet.HOperatorSet.FillUp(ho_Caltab, out ho_RegionFillUp);
            ho_MarksCand.Dispose();
            HalconDotNet.HOperatorSet.Difference(ho_RegionFillUp, ho_RegionDynThresh, out ho_MarksCand
                );
            ho_RegionBorder.Dispose();
            HalconDotNet.HOperatorSet.Boundary(ho_MarksCand, out ho_RegionBorder, "inner");
            ho_RegionDilation1.Dispose();
            HalconDotNet.HOperatorSet.DilationCircle(ho_RegionBorder, out ho_RegionDilation1, 9.5);
            ho_ImageReduced.Dispose();
            HalconDotNet.HOperatorSet.ReduceDomain(ho_Image, ho_RegionDilation1, out ho_ImageReduced);
            hv_MinContrast = 10;
            ho_DefaultEdges.Dispose();
            HalconDotNet.HOperatorSet.EdgesSubPix(ho_ImageReduced, out ho_DefaultEdges, "canny", 2, hv_MinContrast / 2,
                hv_MinContrast);
            HalconDotNet.HOperatorSet.CountObj(ho_DefaultEdges, out hv_NumberCand);
            if ((int)(new HalconDotNet.HTuple(hv_NumberCand.TupleLess(10))) != 0)
            {
                ho_ImageMean.Dispose();
                ho_RegionDynThresh.Dispose();
                ho_RegionBorder.Dispose();
                ho_RegionOpening1.Dispose();
                ho_ConnectedRegions1.Dispose();
                ho_SelectedRegions4.Dispose();
                ho_SelectedRegions5.Dispose();
                ho_RegionBorder2.Dispose();
                ho_RegionTrans.Dispose();
                ho_RegionErosion.Dispose();
                ho_RegionBorder1.Dispose();
                ho_RegionDilation2.Dispose();
                ho_RegionDifference1.Dispose();
                ho_RegionOpening.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionFillUp.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_RegionIntersection.Dispose();
                ho_RegionFillUp1.Dispose();
                ho_RegionDifference.Dispose();
                ho_CaltabCandidates.Dispose();
                ho_ObjectSelected.Dispose();
                ho_ConnectedMarks.Dispose();
                ho_ObjectSelectedCaltab.Dispose();
                ho_RegionFillUpCand.Dispose();
                ho_MarksCand.Dispose();
                ho_RegionDilation1.Dispose();
                ho_ImageReduced.Dispose();
                ho_DefaultEdges.Dispose();
                ho_UnionContours.Dispose();
                ho_SelectedXLD.Dispose();
                ho_SelectedXLD1.Dispose();

                return;
            }
            ho_UnionContours.Dispose();
            HalconDotNet.HOperatorSet.UnionCocircularContoursXld(ho_DefaultEdges, out ho_UnionContours,
                0.5, 0.1, 0.2, 30, 10, 10, "true", 1);
            ho_SelectedXLD.Dispose();
            HalconDotNet.HOperatorSet.SelectShapeXld(ho_UnionContours, out ho_SelectedXLD, "area", "and",
                30, 10000);
            ho_SelectedXLD1.Dispose();
            HalconDotNet.HOperatorSet.SelectShapeXld(ho_SelectedXLD, out ho_SelectedXLD1, "circularity",
                "and", 0.4, 1);
            ho_MarksCand.Dispose();
            HalconDotNet.HOperatorSet.SelectShapeXld(ho_SelectedXLD1, out ho_MarksCand, "compactness",
                "and", 1, 1.5);
            HalconDotNet.HOperatorSet.AreaCenterXld(ho_MarksCand, out hv_Area, out hv_Dummy, out hv_Dummy,
                out hv_DummyS);
            HalconDotNet.HOperatorSet.CountObj(ho_MarksCand, out hv_Number);
            if ((int)(new HalconDotNet.HTuple(hv_Number.TupleLess(4))) != 0)
            {
                ho_ImageMean.Dispose();
                ho_RegionDynThresh.Dispose();
                ho_RegionBorder.Dispose();
                ho_RegionOpening1.Dispose();
                ho_ConnectedRegions1.Dispose();
                ho_SelectedRegions4.Dispose();
                ho_SelectedRegions5.Dispose();
                ho_RegionBorder2.Dispose();
                ho_RegionTrans.Dispose();
                ho_RegionErosion.Dispose();
                ho_RegionBorder1.Dispose();
                ho_RegionDilation2.Dispose();
                ho_RegionDifference1.Dispose();
                ho_RegionOpening.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionFillUp.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_RegionIntersection.Dispose();
                ho_RegionFillUp1.Dispose();
                ho_RegionDifference.Dispose();
                ho_CaltabCandidates.Dispose();
                ho_ObjectSelected.Dispose();
                ho_ConnectedMarks.Dispose();
                ho_ObjectSelectedCaltab.Dispose();
                ho_RegionFillUpCand.Dispose();
                ho_MarksCand.Dispose();
                ho_RegionDilation1.Dispose();
                ho_ImageReduced.Dispose();
                ho_DefaultEdges.Dispose();
                ho_UnionContours.Dispose();
                ho_SelectedXLD.Dispose();
                ho_SelectedXLD1.Dispose();

                return;
            }
            hv_AreaMedian = ((hv_Area.TupleSort())).TupleSelect(hv_Number / 2);
            ho_Marks.Dispose();
            HalconDotNet.HOperatorSet.SelectShapeXld(ho_MarksCand, out ho_Marks, "area", "and", hv_AreaMedian - (hv_AreaMedian * 0.5),
                hv_AreaMedian + (hv_AreaMedian * 0.5));
            ho_ImageMean.Dispose();
            ho_RegionDynThresh.Dispose();
            ho_RegionBorder.Dispose();
            ho_RegionOpening1.Dispose();
            ho_ConnectedRegions1.Dispose();
            ho_SelectedRegions4.Dispose();
            ho_SelectedRegions5.Dispose();
            ho_RegionBorder2.Dispose();
            ho_RegionTrans.Dispose();
            ho_RegionErosion.Dispose();
            ho_RegionBorder1.Dispose();
            ho_RegionDilation2.Dispose();
            ho_RegionDifference1.Dispose();
            ho_RegionOpening.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions2.Dispose();
            ho_SelectedRegions.Dispose();
            ho_RegionFillUp.Dispose();
            ho_SelectedRegions1.Dispose();
            ho_RegionIntersection.Dispose();
            ho_RegionFillUp1.Dispose();
            ho_RegionDifference.Dispose();
            ho_CaltabCandidates.Dispose();
            ho_ObjectSelected.Dispose();
            ho_ConnectedMarks.Dispose();
            ho_ObjectSelectedCaltab.Dispose();
            ho_RegionFillUpCand.Dispose();
            ho_MarksCand.Dispose();
            ho_RegionDilation1.Dispose();
            ho_ImageReduced.Dispose();
            ho_DefaultEdges.Dispose();
            ho_UnionContours.Dispose();
            ho_SelectedXLD.Dispose();
            ho_SelectedXLD1.Dispose();

            return;
        }


        /// <summary>
        /// Determines whether the calibration image is overexposed
        /// 计算标定图像是否过曝
        /// </summary>
        public void Evaluate_Caltab_OverExposure(HalconDotNet.HObject ho_Image,
                                              HalconDotNet.HObject ho_Caltab,
                                              out HalconDotNet.HTuple hv_OverexposureScore)
        {

            // Local iconic variables 

            HalconDotNet.HObject ho_ImageReduced, ho_Region;


            // Local control variables 

            HalconDotNet.HTuple hv_AreaCaltab, hv_Row, hv_Column, hv_AreaOverExp;
            HalconDotNet.HTuple hv_Thresh, hv_Ratio;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Region);

            //returns a measure of the amount of saturation of the plate
            hv_OverexposureScore = 0.0;
            HalconDotNet.HOperatorSet.AreaCenter(ho_Caltab, out hv_AreaCaltab, out hv_Row, out hv_Column);
            if ((int)((new HalconDotNet.HTuple(hv_AreaCaltab.TupleEqual(0))).TupleOr(new HalconDotNet.HTuple(hv_AreaCaltab.TupleEqual(
                new HalconDotNet.HTuple())))) != 0)
            {
                ho_ImageReduced.Dispose();
                ho_Region.Dispose();

                return;
            }
            ho_ImageReduced.Dispose();
            HalconDotNet.HOperatorSet.ReduceDomain(ho_Image, ho_Caltab, out ho_ImageReduced);
            ho_Region.Dispose();
            HalconDotNet.HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, 255, 255);
            HalconDotNet.HOperatorSet.AreaCenter(ho_Region, out hv_AreaOverExp, out hv_Row, out hv_Column);
            hv_Thresh = 0.15;
            hv_Ratio = (hv_AreaOverExp.TupleReal()) / hv_AreaCaltab;
            if ((int)(new HalconDotNet.HTuple(hv_Ratio.TupleLess(hv_Thresh))) != 0)
            {
                hv_OverexposureScore = (((new HalconDotNet.HTuple(1.0)).TupleConcat(1 - (hv_Ratio / hv_Thresh)))).TupleMin()
                    ;
            }
            ho_ImageReduced.Dispose();
            ho_Region.Dispose();

            return;
        }

        /// <summary>
        /// Evaluates the gray value contrast between the marks and the calibration 
        /// plate and the homogeneity of the used illumination.
        /// 评估标定图像中标定板区域与特征点区域之间的灰度对比度
        /// 以及亮度的均匀性
        /// </summary>
        public void Evaluate_Caltab_Contrast_Homogeneity(HalconDotNet.HObject ho_Image,
                                                      HalconDotNet.HObject ho_Marks,
                                                      out HalconDotNet.HTuple hv_Contrast,
                                                      out HalconDotNet.HTuple hv_ContrastScore,
                                                      out HalconDotNet.HTuple hv_HomogeneityScore)
        {

            // Local iconic variables 

            HalconDotNet.HObject ho_Region, ho_RegionDilation;


            // Local control variables 

            HalconDotNet.HTuple hv_Number, hv_Min, hv_Max, hv_Range;
            HalconDotNet.HTuple hv_MinContrast, hv_MaxContrast, hv_DeviationMax;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Region);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionDilation);

            hv_ContrastScore = 0.0;
            hv_Contrast = 0.0;
            hv_HomogeneityScore = 0.0;
            HalconDotNet.HOperatorSet.CountObj(ho_Marks, out hv_Number);
            if ((int)(new HalconDotNet.HTuple(hv_Number.TupleLess(4))) != 0)
            {
                ho_Region.Dispose();
                ho_RegionDilation.Dispose();

                return;
            }
            ho_Region.Dispose();
            HalconDotNet.HOperatorSet.GenRegionContourXld(ho_Marks, out ho_Region, "margin");
            ho_RegionDilation.Dispose();
            HalconDotNet.HOperatorSet.DilationCircle(ho_Region, out ho_RegionDilation, 5.5);
            HalconDotNet.HOperatorSet.MinMaxGray(ho_RegionDilation, ho_Image, 3, out hv_Min, out hv_Max,
                out hv_Range);
            //Calculate contrast score
            hv_Contrast = hv_Range.TupleMean();
            hv_MinContrast = 70;
            hv_MaxContrast = 160;
            if ((int)(new HalconDotNet.HTuple(hv_Contrast.TupleGreater(hv_MinContrast))) != 0)
            {
                hv_ContrastScore = (hv_Contrast - hv_MinContrast) / (hv_MaxContrast - hv_MinContrast);
                hv_ContrastScore = ((hv_ContrastScore.TupleConcat(1.0))).TupleMin();
            }
            //Now for the homogeneity score
            HalconDotNet.HOperatorSet.TupleDeviation(hv_Max, out hv_DeviationMax);
            hv_HomogeneityScore = 1.1 - (hv_DeviationMax / 40.0);
            hv_HomogeneityScore = ((((((hv_HomogeneityScore.TupleConcat(1.0))).TupleMin()
                )).TupleConcat(0.0))).TupleMax();
            ho_Region.Dispose();
            ho_RegionDilation.Dispose();

            return;

        }


        /// <summary>
        /// Evaluates the area covered by the calibration plate in the calibration
        /// image.
        /// 评估在标定图像中标定板的覆盖区域比例
        /// </summary>
        public void Evaluate_Caltab_Size(HalconDotNet.HObject ho_Image,
                                      HalconDotNet.HObject ho_Caltab,
                                      HalconDotNet.HObject ho_Marks,
                                      out HalconDotNet.HTuple hv_SizeScore)
        {


            // Local iconic variables 

            HalconDotNet.HObject ho_Region = null, ho_RegionUnion = null;


            // Local control variables 

            HalconDotNet.HTuple hv_Width, hv_Height, hv_Number, hv_Row1 = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_Column1 = new HalconDotNet.HTuple(), hv_Phi1 = new HalconDotNet.HTuple(), hv_Length1 = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_Length2 = new HalconDotNet.HTuple(), hv_Area = new HalconDotNet.HTuple(), hv_Row = new HalconDotNet.HTuple();
            HalconDotNet.HTuple hv_Column = new HalconDotNet.HTuple(), hv_MinRatio, hv_MaxRatio;
            HalconDotNet.HTuple hv_Ratio;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Region);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_RegionUnion);

            hv_SizeScore = 0.0;
            HalconDotNet.HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            HalconDotNet.HOperatorSet.CountObj(ho_Marks, out hv_Number);
            if ((int)(new HalconDotNet.HTuple(hv_Number.TupleGreaterEqual(4))) != 0)
            {
                //Best approach: Use the surrounding box of the marks as reference size
                ho_Region.Dispose();
                HalconDotNet.HOperatorSet.GenRegionContourXld(ho_Marks, out ho_Region, "filled");
                ho_RegionUnion.Dispose();
                HalconDotNet.HOperatorSet.Union1(ho_Region, out ho_RegionUnion);
                HalconDotNet.HOperatorSet.SmallestRectangle2(ho_RegionUnion, out hv_Row1, out hv_Column1,
                    out hv_Phi1, out hv_Length1, out hv_Length2);
                hv_Area = (hv_Length2 * hv_Length1) * 4;
            }
            else
            {
                //If no marks could be found: use the caltab as reference size
                HalconDotNet.HOperatorSet.AreaCenter(ho_Caltab, out hv_Area, out hv_Row, out hv_Column);
                if ((int)((new HalconDotNet.HTuple(hv_Area.TupleEqual(0))).TupleOr(new HalconDotNet.HTuple(hv_Area.TupleEqual(
                    new HalconDotNet.HTuple())))) != 0)
                {
                    ho_Region.Dispose();
                    ho_RegionUnion.Dispose();

                    return;
                }
            }
            hv_MinRatio = 0.015;
            hv_MaxRatio = 0.075;
            hv_Ratio = (hv_Area.TupleReal()) / (hv_Width * hv_Height);
            if ((int)(new HalconDotNet.HTuple(hv_Ratio.TupleGreater(hv_MinRatio))) != 0)
            {
                hv_SizeScore = (hv_Ratio - hv_MinRatio) / (hv_MaxRatio - hv_MinRatio);
                hv_SizeScore = (((new HalconDotNet.HTuple(1.0)).TupleConcat(hv_SizeScore))).TupleMin();
            }
            ho_Region.Dispose();
            ho_RegionUnion.Dispose();

            return;
        }

        /// <summary>
        /// Measures the tilt that is used for the plates in the set
        /// of calibration images. The more tilted plates are used
        /// in the image set, the better you can correct the radial 
        /// distortion of the lense by performing the calibration.
        /// 计算标定图像集中使用的标定图像对应的标定的倾斜角.
        /// 标定图像集中包含倾斜标定板的图像越多,在标定过程中
        /// 对径向畸变的纠正效果越好
        /// </summary>
        public void Evaluate_Caltab_Tilt(HalconDotNet.HTuple hv_FinalPoses,
                                      out HalconDotNet.HTuple hv_TiltScore)
        {

            // Local control variables 

            HalconDotNet.HTuple hv_NImages, hv_Ones, hv_Index, hv_Slant;
            HalconDotNet.HTuple hv_Pan, hv_FuzzyFunct, hv_SlantWeight, hv_PanWeight;
            HalconDotNet.HTuple hv_TmpPan, hv_TmpSlant;

            // Initialize local and output iconic variables 

            hv_NImages = (new HalconDotNet.HTuple(hv_FinalPoses.TupleLength())) / 7;
            HalconDotNet.HOperatorSet.TupleGenConst(hv_NImages, 1, out hv_Ones);
            hv_Index = (hv_Ones.TupleCumul()) - 1;
            HalconDotNet.HOperatorSet.TupleSelect(hv_FinalPoses, (7 * hv_Index) + 3, out hv_Slant);
            HalconDotNet.HOperatorSet.TupleSelect(hv_FinalPoses, (7 * hv_Index) + 4, out hv_Pan);
            for (hv_Index = 0; (int)hv_Index <= (int)((new HalconDotNet.HTuple(hv_Slant.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HalconDotNet.HTuple(((hv_Slant.TupleSelect(hv_Index))).TupleGreater(180))) != 0)
                {
                    if (hv_Slant == null)
                        hv_Slant = new HalconDotNet.HTuple();
                    hv_Slant[hv_Index] = 360 - (hv_Slant.TupleSelect(hv_Index));
                }
            }
            for (hv_Index = 0; (int)hv_Index <= (int)((new HalconDotNet.HTuple(hv_Pan.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HalconDotNet.HTuple(((hv_Pan.TupleSelect(hv_Index))).TupleGreater(180))) != 0)
                {
                    if (hv_Pan == null)
                        hv_Pan = new HalconDotNet.HTuple();
                    hv_Pan[hv_Index] = 360 - (hv_Pan.TupleSelect(hv_Index));
                }
            }
            hv_Pan = hv_Pan.TupleRad();
            hv_Slant = hv_Slant.TupleRad();
            //function acting as a fuzzy weighting
            gen_fuzzy_weight_funct(256, (new HalconDotNet.HTuple(0.0)).TupleRad(), (new HalconDotNet.HTuple(90.0)).TupleRad()
                , (new HalconDotNet.HTuple(15.0)).TupleRad(), (new HalconDotNet.HTuple(40.0)).TupleRad(), out hv_FuzzyFunct);
            HalconDotNet.HOperatorSet.GetYValueFunct1d(hv_FuzzyFunct, hv_Slant, "constant", out hv_SlantWeight);
            HalconDotNet.HOperatorSet.GetYValueFunct1d(hv_FuzzyFunct, hv_Pan, "constant", out hv_PanWeight);
            //Calculate score value
            hv_TmpPan = (hv_PanWeight.TupleSum()) / 6;
            hv_TmpPan = ((hv_TmpPan.TupleConcat(0.5))).TupleMin();
            hv_TmpSlant = (hv_SlantWeight.TupleSum()) / 6;
            hv_TmpSlant = ((hv_TmpSlant.TupleConcat(0.5))).TupleMin();
            hv_TiltScore = hv_TmpSlant + hv_TmpPan;

            return;
        }

        /// <summary>
        /// Evaluates the distribution of the marks and hence the plates
        /// used for the calibration images. Precise measurements can only be
        /// achieved if the field view of the camera is covered well by the
        /// calibration plate in the images.
        /// 评估标定图像中特征点的分布,从而评估标定板.只有标定图像中标定板很好地
        /// 覆盖相机视野,才能获取到精确的测量结果.
        /// </summary>
        public void Evaluate_Marks_Distribution(HalconDotNet.HTuple hv_NRCoord,
                                             HalconDotNet.HTuple hv_NCCoord,
                                             HalconDotNet.HTuple hv_Width,
                                             HalconDotNet.HTuple hv_Height,
                                             out HalconDotNet.HTuple hv_MarksDistributionScore)
        {
            // Local iconic variables 

            HalconDotNet.HObject ho_Region, ho_DistanceImage, ho_Mask;


            // Local control variables 

            HalconDotNet.HTuple hv_Border, hv_Min, hv_Max, hv_Range;
            HalconDotNet.HTuple hv_ImageDiagonal, hv_MinThresh, hv_MaxThresh, hv_Ratio;
            HalconDotNet.HTuple hv_Tmp1, hv_Tmp2;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Region);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_DistanceImage);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Mask);

            //Determine the distances between the marks centers
            ho_Region.Dispose();
            HalconDotNet.HOperatorSet.GenRegionPoints(out ho_Region, hv_NRCoord, hv_NCCoord);
            ho_DistanceImage.Dispose();
            HalconDotNet.HOperatorSet.DistanceTransform(ho_Region, out ho_DistanceImage, "octagonal",
                "false", hv_Width, hv_Height);
            //A clipping is needed because the marks cannot come close to the border
            hv_Border = (((hv_Width.TupleConcat(hv_Height))).TupleMax()) / 15;
            ho_Mask.Dispose();
            HalconDotNet.HOperatorSet.GenRectangle1(out ho_Mask, hv_Border, hv_Border, (hv_Height - 1) - hv_Border,
                (hv_Width - 1) - hv_Border);
            HalconDotNet.HOperatorSet.MinMaxGray(ho_Mask, ho_DistanceImage, 0, out hv_Min, out hv_Max,
                out hv_Range);
            HalconDotNet.HOperatorSet.DistancePp(0, 0, hv_Height - 1, hv_Width - 1, out hv_ImageDiagonal);
            hv_MinThresh = 0.3;
            hv_MaxThresh = 0.85;
            hv_Ratio = (hv_Max / hv_ImageDiagonal) * 2.5;
            hv_Tmp1 = 1 - hv_Ratio;
            hv_Tmp2 = (hv_Tmp1 - hv_MinThresh) / (hv_MaxThresh - hv_MinThresh);
            hv_MarksDistributionScore = ((((((hv_Tmp2.TupleConcat(1.0))).TupleMin())).TupleConcat(
                0.0))).TupleMax();
            ho_Region.Dispose();
            ho_DistanceImage.Dispose();
            ho_Mask.Dispose();

            return;

        }

        /// <summary>
        /// Auxiliary method for display purposes. Returns the coordinate system
        /// described by the parameters <c>hv_CamParam</c> and <c>hv_Pose</c>
        /// as an iconic object.
        /// 获取根据相机内参和外参得到的坐标系系统
        /// </summary>
        public void Get_3D_Coord_System(HalconDotNet.HObject ho_ImageReference,
                                 out HalconDotNet.HObject ho_CoordSystemRegion,
                                 HalconDotNet.HTuple hv_CamParam,
                                 HalconDotNet.HTuple hv_Pose,
                                 HalconDotNet.HTuple hv_CoordAxesLength)
        {



            // Local iconic variables 

            HalconDotNet.HObject ho_CoordSystemImage;


            // Local control variables 

            HalconDotNet.HTuple hv_Width, hv_Height, hv_OldBG, hv_WindowHandle;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CoordSystemRegion);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CoordSystemImage);

            HalconDotNet.HOperatorSet.GetImageSize(ho_ImageReference, out hv_Width, out hv_Height);
            HalconDotNet.HOperatorSet.GetWindowAttr("background_color", out hv_OldBG);
            HalconDotNet.HOperatorSet.SetWindowAttr("background_color", "black");
            HalconDotNet.HOperatorSet.OpenWindow(0, 0, hv_Width, hv_Height, 0, "buffer", "", out hv_WindowHandle);
            HalconDotNet.HOperatorSet.SetWindowAttr("background_color", hv_OldBG);
            HalconDotNet.HOperatorSet.SetColor(hv_WindowHandle, "white");
            HalconDotNet.HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_Height - 1, hv_Width - 1);
            Disp_3D_Coord_System(hv_WindowHandle, hv_CamParam, hv_Pose, hv_CoordAxesLength);
            ho_CoordSystemImage.Dispose();
            HalconDotNet.HOperatorSet.DumpWindowImage(out ho_CoordSystemImage, hv_WindowHandle);
            HalconDotNet.HOperatorSet.CloseWindow(hv_WindowHandle);
            ho_CoordSystemRegion.Dispose();
            HalconDotNet.HOperatorSet.Threshold(ho_CoordSystemImage, out ho_CoordSystemRegion, 255, 255);
            ho_CoordSystemImage.Dispose();

            return;
        }

        /// <summary>
        /// Display the axes of a 3d coordinate system.
        /// 显示3D坐标系
        /// </summary>
        private void Disp_3D_Coord_System(HalconDotNet.HTuple hv_WindowHandle,
                                          HalconDotNet.HTuple hv_CamParam,
                                          HalconDotNet.HTuple hv_Pose,
                                          HalconDotNet.HTuple hv_CoordAxesLength)
        {

            // Local iconic variables 

            HalconDotNet.HObject ho_ContX, ho_ContY, ho_ContZ;


            // Local control variables 

            HalconDotNet.HTuple hv_TransWorld2Cam, hv_OrigCamX, hv_OrigCamY;
            HalconDotNet.HTuple hv_OrigCamZ, hv_Row0, hv_Column0, hv_X, hv_Y, hv_Z;
            HalconDotNet.HTuple hv_RowAxX, hv_ColumnAxX, hv_RowAxY, hv_ColumnAxY;
            HalconDotNet.HTuple hv_RowAxZ, hv_ColumnAxZ;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ContX);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ContY);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_ContZ);

            if ((int)(new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_Pose.TupleLength())).TupleNotEqual(7))) != 0)
            {
                ho_ContX.Dispose();
                ho_ContY.Dispose();
                ho_ContZ.Dispose();

                return;
            }
            if ((int)(new HalconDotNet.HTuple(((hv_Pose.TupleSelect(5))).TupleEqual(0.0))) != 0)
            {
                ho_ContX.Dispose();
                ho_ContY.Dispose();
                ho_ContZ.Dispose();

                return;
            }
            HalconDotNet.HOperatorSet.PoseToHomMat3d(hv_Pose, out hv_TransWorld2Cam);
            //Project the world origin into the image
            HalconDotNet.HOperatorSet.AffineTransPoint3d(hv_TransWorld2Cam, 0, 0, 0, out hv_OrigCamX,
                out hv_OrigCamY, out hv_OrigCamZ);
            HalconDotNet.HOperatorSet.Project3dPoint(hv_OrigCamX, hv_OrigCamY, hv_OrigCamZ, hv_CamParam,
                out hv_Row0, out hv_Column0);
            //Project the coordinate axes into the image
            HalconDotNet.HOperatorSet.AffineTransPoint3d(hv_TransWorld2Cam, hv_CoordAxesLength, 0, 0,
                out hv_X, out hv_Y, out hv_Z);
            HalconDotNet.HOperatorSet.Project3dPoint(hv_X, hv_Y, hv_Z, hv_CamParam, out hv_RowAxX, out hv_ColumnAxX);
            HalconDotNet.HOperatorSet.AffineTransPoint3d(hv_TransWorld2Cam, 0, hv_CoordAxesLength, 0,
                out hv_X, out hv_Y, out hv_Z);
            HalconDotNet.HOperatorSet.Project3dPoint(hv_X, hv_Y, hv_Z, hv_CamParam, out hv_RowAxY, out hv_ColumnAxY);
            HalconDotNet.HOperatorSet.AffineTransPoint3d(hv_TransWorld2Cam, 0, 0, hv_CoordAxesLength,
                out hv_X, out hv_Y, out hv_Z);
            HalconDotNet.HOperatorSet.Project3dPoint(hv_X, hv_Y, hv_Z, hv_CamParam, out hv_RowAxZ, out hv_ColumnAxZ);
            ho_ContX.Dispose();
            gen_arrow_cont(out ho_ContX, hv_Row0, hv_Column0, hv_RowAxX, hv_ColumnAxX);
            ho_ContY.Dispose();
            gen_arrow_cont(out ho_ContY, hv_Row0, hv_Column0, hv_RowAxY, hv_ColumnAxY);
            ho_ContZ.Dispose();
            gen_arrow_cont(out ho_ContZ, hv_Row0, hv_Column0, hv_RowAxZ, hv_ColumnAxZ);
            if (HalconDotNet.HDevWindowStack.IsOpen())
            {
                //dev_display (ContX)
            }
            if (HalconDotNet.HDevWindowStack.IsOpen())
            {
                //dev_display (ContY)
            }
            if (HalconDotNet.HDevWindowStack.IsOpen())
            {
                //dev_display (ContZ)
            }
            HalconDotNet.HOperatorSet.DispObj(ho_ContX, hv_WindowHandle);
            HalconDotNet.HOperatorSet.DispObj(ho_ContY, hv_WindowHandle);
            HalconDotNet.HOperatorSet.DispObj(ho_ContZ, hv_WindowHandle);
            HalconDotNet.HOperatorSet.SetTposition(hv_WindowHandle, hv_RowAxX + 3, hv_ColumnAxX + 3);
            HalconDotNet.HOperatorSet.WriteString(hv_WindowHandle, "X");
            HalconDotNet.HOperatorSet.SetTposition(hv_WindowHandle, hv_RowAxY + 3, hv_ColumnAxY + 3);
            HalconDotNet.HOperatorSet.WriteString(hv_WindowHandle, "Y");
            HalconDotNet.HOperatorSet.SetTposition(hv_WindowHandle, hv_RowAxZ + 3, hv_ColumnAxZ + 3);
            HalconDotNet.HOperatorSet.WriteString(hv_WindowHandle, "Z");
            ho_ContX.Dispose();
            ho_ContY.Dispose();
            ho_ContZ.Dispose();

            return;
        }

        /// <summary>
        /// Generate a contour in form of an arrow.
        /// 产生箭头轮廓
        /// </summary>
        private void gen_arrow_cont(out HalconDotNet.HObject ho_Arrow,
                                    HalconDotNet.HTuple hv_Row1,
                                    HalconDotNet.HTuple hv_Column1,
                                    HalconDotNet.HTuple hv_Row2,
                                    HalconDotNet.HTuple hv_Column2)
        {

            // Local iconic variables 

            HalconDotNet.HObject ho_Cross1, ho_Cross2, ho_CrossP1, ho_CrossP2;


            // Local control variables 

            HalconDotNet.HTuple hv_Length, hv_Angle, hv_MinArrowLength;
            HalconDotNet.HTuple hv_DRow, hv_DCol, hv_ArrowLength, hv_Phi, hv_P1R;
            HalconDotNet.HTuple hv_P1C, hv_P2R, hv_P2C;

            // Initialize local and output iconic variables 
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Arrow);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Cross1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_Cross2);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CrossP1);
            HalconDotNet.HOperatorSet.GenEmptyObj(out ho_CrossP2);

            //Generate a contour in form of a arrow
            hv_Length = 7;
            hv_Angle = 40;
            hv_MinArrowLength = 2;
            hv_DRow = hv_Row2 - hv_Row1;
            hv_DCol = hv_Column2 - hv_Column1;
            hv_ArrowLength = (((hv_DRow * hv_DRow) + (hv_DCol * hv_DCol))).TupleSqrt();
            if ((int)(new HalconDotNet.HTuple(hv_ArrowLength.TupleLess(hv_MinArrowLength))) != 0)
            {
                hv_Length = 0;
            }
            HalconDotNet.HOperatorSet.TupleAtan2(hv_DRow, -hv_DCol, out hv_Phi);
            hv_P1R = hv_Row2 - (hv_Length * (((hv_Phi - (hv_Angle.TupleRad()))).TupleSin()));
            hv_P1C = hv_Column2 + (hv_Length * (((hv_Phi - (hv_Angle.TupleRad()))).TupleCos()));
            hv_P2R = hv_Row2 - (hv_Length * (((hv_Phi + (hv_Angle.TupleRad()))).TupleSin()));
            hv_P2C = hv_Column2 + (hv_Length * (((hv_Phi + (hv_Angle.TupleRad()))).TupleCos()));
            ho_Cross1.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_Row1, hv_Column1, 6, 0.785398);
            ho_Cross2.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out ho_Cross2, hv_Row2, hv_Column2, 6, 0.785398);
            ho_CrossP1.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out ho_CrossP1, hv_P1R, hv_P1C, 6, 0.785398);
            ho_CrossP2.Dispose();
            HalconDotNet.HOperatorSet.GenCrossContourXld(out ho_CrossP2, hv_P2R, hv_P2C, 6, 0.785398);
            ho_Arrow.Dispose();
            HalconDotNet.HOperatorSet.GenContourPolygonXld(out ho_Arrow, ((((((hv_Row1.TupleConcat(hv_Row2))).TupleConcat(
                hv_P1R))).TupleConcat(hv_Row2))).TupleConcat(hv_P2R), ((((((hv_Column1.TupleConcat(
                hv_Column2))).TupleConcat(hv_P1C))).TupleConcat(hv_Column2))).TupleConcat(
                hv_P2C));
            ho_Cross1.Dispose();
            ho_Cross2.Dispose();
            ho_CrossP1.Dispose();
            ho_CrossP2.Dispose();

            return;
        }

        private void tuple_equal_greater(HalconDotNet.HTuple hv_Tuple,
                                  HalconDotNet.HTuple hv_Threshold,
                                  out HalconDotNet.HTuple hv_Selected,
                                  out HalconDotNet.HTuple hv_Indices)
        {

            // Local control variables 

            HalconDotNet.HTuple hv_Sgn;

            // Initialize local and output iconic variables 

            hv_Selected = new HalconDotNet.HTuple();
            HalconDotNet.HOperatorSet.TupleSgn(hv_Tuple - hv_Threshold, out hv_Sgn);
            HalconDotNet.HOperatorSet.TupleFind(hv_Sgn, 1, out hv_Indices);
            if ((int)((new HalconDotNet.HTuple((new HalconDotNet.HTuple(hv_Indices.TupleLength())).TupleGreater(1))).TupleOr(
                new HalconDotNet.HTuple(((hv_Indices.TupleSelect(0))).TupleNotEqual(-1)))) != 0)
            {
                HalconDotNet.HOperatorSet.TupleSelect(hv_Tuple, hv_Indices, out hv_Selected);
            }

            return;
        }

        private void gen_fuzzy_weight_funct(HalconDotNet.HTuple hv_NPoints,
                                            HalconDotNet.HTuple hv_Min,
                                            HalconDotNet.HTuple hv_Max,
                                            HalconDotNet.HTuple hv_LowPass,
                                            HalconDotNet.HTuple hv_HighPass,
                                            out HalconDotNet.HTuple hv_FuzzyFunct)
        {

            // Local control variables 

            HalconDotNet.HTuple hv_Ones, hv_Index, hv_X, hv_Y, hv_Dummy;
            HalconDotNet.HTuple hv_IndicesTrans, hv_IndicesHigh, hv_i, hv_NTransPoints;

            // Initialize local and output iconic variables 

            //generates a function which is 0.0 for values lower than LowPass, 1.0 for
            //values over HighPass, and grows linearly for values in between the two
            HalconDotNet.HOperatorSet.TupleGenConst(hv_NPoints, 1, out hv_Ones);
            hv_Index = ((hv_Ones.TupleCumul()) - 1) / ((new HalconDotNet.HTuple(hv_Ones.TupleLength())).TupleReal()
                );
            hv_X = (hv_Index * (hv_Max - hv_Min)) + hv_Min;
            HalconDotNet.HOperatorSet.TupleGenConst(new HalconDotNet.HTuple(hv_X.TupleLength()), 0.0, out hv_Y);
            tuple_equal_greater(hv_X, hv_LowPass, out hv_Dummy, out hv_IndicesTrans);
            tuple_equal_greater(hv_X, hv_HighPass, out hv_Dummy, out hv_IndicesHigh);
            //ramp from LowPass (0.0) to Highpass (1.0)
            hv_i = 0;
            while ((int)(new HalconDotNet.HTuple(((hv_IndicesTrans.TupleSelect(hv_i))).TupleLess(hv_IndicesHigh.TupleSelect(
                0)))) != 0)
            {
                hv_i = hv_i + 1;
            }
            hv_NTransPoints = hv_i.Clone();
            for (hv_i = 0; hv_i.Continue(hv_NTransPoints - 1, 1); hv_i = hv_i.TupleAdd(1))
            {
                if (hv_Y == null)
                    hv_Y = new HalconDotNet.HTuple();
                hv_Y[hv_IndicesTrans.TupleSelect(hv_i)] = (hv_i.TupleReal()) / hv_NTransPoints;
            }
            for (hv_i = hv_IndicesTrans.TupleSelect(hv_NTransPoints); hv_i.Continue((new HalconDotNet.HTuple(hv_Y.TupleLength()
                )) - 1, 1); hv_i = hv_i.TupleAdd(1))
            {
                if (hv_Y == null)
                    hv_Y = new HalconDotNet.HTuple();
                hv_Y[hv_i] = 1.0;
            }
            HalconDotNet.HOperatorSet.CreateFunct1dPairs(hv_X, hv_Y, out hv_FuzzyFunct);

            return;
        }
    }
}
