﻿using System;
using System.Collections;



namespace Vision.Tool.Model
{
    [Serializable]
    public class NCCParam
    {
        public int NumLevels;
        public float AngleStart;
        public float AngleExtent;
        public float AngleStep;
        public string Metric;

        public float MinScore;
        public int NumMatches;
        public float MaxOverlap;
        public string SubPixel;

        public ArrayList paramAuto = new ArrayList();



        public bool IsAuto(string mode)
        {
            bool isAuto = false;

            switch (mode)
            {
                case AUTO_NUM_LEVEL:
                    isAuto = paramAuto.Contains(AUTO_NUM_LEVEL);
                    break;
                case AUTO_ANGLE_STEP:
                    isAuto = paramAuto.Contains(AngleStep);
                    break;
                default: break;
            }

            return isAuto;
        }


        public bool IsOnAuto()
        {
            if (paramAuto.Count > 0)
                return true;
            else
                return false;
        }


        public bool SetAuto(string val)
        {
            string mode = "";

            switch (val)
            {
                case AUTO_NUM_LEVEL:
                    if (!paramAuto.Contains(AUTO_NUM_LEVEL))
                        mode = AUTO_NUM_LEVEL;
                    break;
                case AUTO_ANGLE_STEP:
                    if (!paramAuto.Contains(AUTO_ANGLE_STEP))
                        mode = AUTO_ANGLE_STEP;
                    break;
                default: break;
            }

            if (mode == "")
                return false;

            paramAuto.Add(mode);
            return true;
        }


        public bool RemoveAuto(string val)
        {
            string mode = "";

            switch (val)
            {
                case AUTO_NUM_LEVEL:
                    if (paramAuto.Contains(AUTO_NUM_LEVEL))
                        mode = AUTO_NUM_LEVEL;
                    break;
                case AUTO_ANGLE_STEP:
                    if (paramAuto.Contains(AUTO_ANGLE_STEP))
                        mode = AUTO_ANGLE_STEP;
                    break;
                default: break;
            }

            if (mode == "")
                return false;

            paramAuto.Remove(mode);
            return true;
        }


        public string[] GetAutoParList()
        {
            int count = paramAuto.Count;
            string[] paramList = new string[count];

            for (int i = 0; i < count; i++)
                paramList[i] = (string)paramAuto[i];

            return paramList;
        }


        public const string AUTO_NUM_LEVEL = "num_levels";
        public const string AUTO_ANGLE_STEP = "angle_step";





        public void WriteParam(string fileName)
        {
            SetParam.WriteParam(fileName, "NumLevels", NumLevels.ToString());
            SetParam.WriteParam(fileName, "AngleStart", AngleStart.ToString());
            SetParam.WriteParam(fileName, "AngleExtent", AngleExtent.ToString());
            SetParam.WriteParam(fileName, "AngleStep", AngleStep.ToString());
            SetParam.WriteParam(fileName, "Metric", Metric.ToString());
            SetParam.WriteParam(fileName, "MinScore", MinScore.ToString());
            SetParam.WriteParam(fileName, "NumMatches", NumMatches.ToString());
            SetParam.WriteParam(fileName, "MaxOverlap", MaxOverlap.ToString());
            SetParam.WriteParam(fileName, "SubPixel", SubPixel.ToString());


            SetParam.WriteParam(fileName, "AutoNumLevels", IsAuto(AUTO_NUM_LEVEL).ToString());
            SetParam.WriteParam(fileName, "AutoAngleStep", IsAuto(AUTO_ANGLE_STEP).ToString());
        }

        public void ReadParam(string fileName)
        {
            NumLevels = Convert.ToInt32(SetParam.ReadParam(fileName, "NumLevels", NumLevels.ToString()));
            AngleStart = Convert.ToSingle(SetParam.ReadParam(fileName, "AngleStart", AngleStart.ToString()));
            AngleExtent = Convert.ToSingle(SetParam.ReadParam(fileName, "AngleExtent", AngleExtent.ToString()));
            AngleStep = Convert.ToSingle(SetParam.ReadParam(fileName, "AngleStep", AngleStep.ToString()));
            Metric = Convert.ToString(SetParam.ReadParam(fileName, "Metric", Metric.ToString()));
            MinScore = Convert.ToSingle(SetParam.ReadParam(fileName, "MinScore", MinScore.ToString()));
            NumMatches = Convert.ToInt32(SetParam.ReadParam(fileName, "NumMatches", NumMatches.ToString()));
            MaxOverlap = Convert.ToSingle(SetParam.ReadParam(fileName, "MaxOverlap", MaxOverlap.ToString()));
            SubPixel = Convert.ToString(SetParam.ReadParam(fileName, "SubPixel", SubPixel.ToString()));

            bool flag1 = Convert.ToBoolean(SetParam.ReadParam(fileName, "AutoNumLevels", IsAuto(AUTO_NUM_LEVEL).ToString()));
            if (flag1) SetAuto(AUTO_NUM_LEVEL);
            else RemoveAuto(AUTO_NUM_LEVEL);

            flag1 = Convert.ToBoolean(SetParam.ReadParam(fileName, "AutoNumLevels", IsAuto(AUTO_ANGLE_STEP).ToString()));
            if (flag1) SetAuto(AUTO_ANGLE_STEP);
            else RemoveAuto(AUTO_ANGLE_STEP);
        }



        public NCCParam()
        {
            NumLevels = 5;
            AngleStart = 0;
            AngleExtent = 0;
            AngleStep = 0.088f;
            Metric = "use_polarity";

            MinScore = 0.7f;
            NumMatches = 1;
            MaxOverlap = 0.5f;
            SubPixel = "true";
        }
    }
}
