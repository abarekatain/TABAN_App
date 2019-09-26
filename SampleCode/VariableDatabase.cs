using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VariableDatabase : MonoBehaviour {
    public WriteData2File Writer;
    //PhysicalCondition & PrimaryCooling Tabs Variables Input
    public UIInput IMachineNo, IstrandNo, Iwidth, Ispeed, ITundishTemp, IliquidTemp, IsolidTemp, IWaterSecTemp, IsurTemp,IThickness, IFixedSideVFR, IFixedSideTempDif, ILooseSideVFR, ILooseSideTempDif, IRightNarrowSideVFR, IRightNarrowSideTempDif, ILeftNarrowSideVFR, ILeftNarrowSideTempDif;
    public float MachineNo, strandNo, width, speed, TundishTemp, liquidTemp, solidTemp, WaterSecTemp, surTemp,Thickness, FixedSideVFR, FixedSideTempDif, LooseSideVFR, LooseSideTempDif, RightNarrowSideVFR, RightNarrowSideTempDif, LeftNarrowSideVFR, LeftNarrowSideTempDif;
    public Dictionary<UIInput, float> Inputs;


    //Machines Variables Input,The Variables Order Has Been Sorted According to Loops Order;Dont Worry!
    public UIInput[] IMachine4Loops;
    public UIInput[] IMachine2Loops;
    public UIInput[] IMachine1And3Loops;
    public float[] Machine4Loops = new float[13];
    public float[] Machine2Loops = new float[15];
    public float[] Machine1And3Loops = new float[9];


    //PhysicalCondition & PrimaryCooling Reports Output
    public UILabel OMachineNo, OstrandNo, Owidth, Ospeed, OTundishTemp, OliquidTemp, OsolidTemp, OWaterSecTemp, OsurTemp,OThickness, OFixedSideVFR, OFixedSideTempDif, OLooseSideVFR, OLooseSideTempDif, ORightNarrowSideVFR, ORightNarrowSideTempDif, OLeftNarrowSideVFR, OLeftNarrowSideTempDif;
    public Dictionary<UILabel,float > Outputs;

    //Machines Loops Output
    public UILabel[] OMachine4Loops;
    public UILabel[] OMachine2Loops;
    public UILabel[] OMachine1And3Loops;

    //Segmental Results Report Output
    [System.Serializable]
    public struct SegmentData
    {
        public float TCenter, TMidWideTop, TMidWideBot, TMidNarr, ThickWide, ThickNarr, TempDiff;
        public UILabel OTCenter, OTMidWideTop, OTMidWideBot, OTMidNarr, OThickWide, OThickNarr, OTempDiff;
    }
    public SegmentData[] Machine2And4SegmentRes = new SegmentData[14];
    public SegmentData[] Machine1And3SegmentRes = new SegmentData[8];

    //Results Tab Variables Output
    
    [System.Serializable]
    public struct PointValues
    {
        public float Distance,RollNo,CenterPointTemp, TopFaceTemp, BottomFaceTemp, NarrowRightFaceTemp, NarrowLeftFaceTemp, SolidThicknessOfBottomFace, SolidThicknessOfTopFace, SolidThicknessOfNarrowRightFace, SolidThicknessOfNarrowLeftFace, TempAsymmetry;
        
    }

    [System.Serializable]
    public struct PointsOutputGOs
    {
        public UILabel ODistance,OCenterPointTemp, OTopFaceTemp, OBottomFaceTemp, ONarrowRightFaceTemp, ONarrowLeftFaceTemp, OSolidThicknessOfBottomFace, OSolidThicknessOfTopFace, OSolidThicknessOfRightNarrowFace, OSolidThicknessOfLeftNarrowFace, OTempAsymmetry;
    }
    public PointValues[] Points1And3 = new PointValues[66];
    public PointValues[] Points2 = new PointValues[81];
    public PointValues[] Points4 = new PointValues[76];
    public PointsOutputGOs PointsOutGO;
    [System.Serializable]
    public struct GeneralResults //This Structure Is Common Between Results And Report Tab
    {
        public float MetallurgicalLength, MeanTempDiff, MaxTempDiff;
        public UILabel ORESMettalurgicalLength, ORESMeanTempDiff, ORESMaxTempDiff;
        public UILabel OREPMettalurgicalLength, OREPMeanTempDiff, OREPMaxTempDiff;
    }
    public GeneralResults GeneralRes;
    [System.Serializable]
    public struct MoldExitProperties
    {
        public float TopMoldSolidThickness, BottomMoldSolidThickness, NarrowRightMoldSolidThickness, NarrowLeftMoldSolidThickness;
        public UILabel OTopMoldSolidThickness, OBottomMoldSolidThickness, ONarrowRightMoldSolidThickness, ONarrowLeftMoldSolidThickness;
    }
    public MoldExitProperties MoldExitProp;


    //Nozzles
    public GameObject Machine4NozzlesMasterDir;
    public GameObject Machine2NozzlesMasterDir;
    public GameObject Machine1And3NozzlesMasterDir;
        //Top
    public UISlider[] Machine4TopNozzles;
    public GameObject[] Machine4TopNozzlesDir;
    public GameObject Machine4TopNozzlesMasterDir;

    public UISlider[] Machine2TopNozzles;
    public GameObject[] Machine2TopNozzlesDir;
    public GameObject Machine2TopNozzlesMasterDir;

    public UISlider[] Machine1And3TopNozzles;
    public GameObject[] Machine1And3TopNozzlesDir;
    public GameObject Machine1And3TopNozzlesMasterDir;
        //Bottom
    public UISlider[] Machine4BottomNozzles;
    public GameObject[] Machine4BottomNozzlesDir;
    public GameObject Machine4BottomNozzlesMasterDir;

    public UISlider[] Machine2BottomNozzles;
    public GameObject[] Machine2BottomNozzlesDir;
    public GameObject Machine2BottomNozzlesMasterDir;

    public UISlider[] Machine1And3BottomNozzles;
    public GameObject[] Machine1And3BottomNozzlesDir;
    public GameObject Machine1And3BottomNozzlesMasterDir;
        //Right
    public UISlider[] Machine4RightNozzles;
    public GameObject Machine4RightNozzlesMasterDir;

    public UISlider[] Machine2RightNozzles;
    public GameObject Machine2RightNozzlesMasterDir;

    public UISlider[] Machine1And3RightNozzles;
    public GameObject Machine1And3RightNozzlesMasterDir;
        //Left
    public UISlider[] Machine4LeftNozzles;
    public GameObject Machine4LeftNozzlesMasterDir;

    public UISlider[] Machine2LeftNozzles;
    public GameObject Machine2LeftNozzlesMasterDir;

    public UISlider[] Machine1And3LeftNozzles;
    public GameObject Machine1And3LeftNozzlesMasterDir;

    void Start() {
        //Get The Nozzles Objects
        Machine4NozzlesMasterDir.SetActive(true);
        Machine2NozzlesMasterDir.SetActive(true);
        Machine1And3NozzlesMasterDir.SetActive(true);
        //Top
        #region
        int j = 0;
        for (int i = 0; i < Machine4TopNozzlesDir.Length; i++)
        {
            Machine4TopNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine4TopNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                //if(s.gameObject.active)
                //{
                    Machine4TopNozzles[j] = s;
                    j++;
                //}

            }
            //Machine4TopNozzlesMasterDir.SetActive(false);
        }

        j = 0;
        for (int i = 0; i < Machine2TopNozzlesDir.Length; i++)
        {
            Machine2TopNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine2TopNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                if (s.gameObject.activeInHierarchy)
                {
                    Machine2TopNozzles[j] = s;
                    j++;
                }

            }
            //Machine2TopNozzlesMasterDir.SetActive(false);
        }

        j = 0;
        for (int i = 0; i < Machine1And3TopNozzlesDir.Length; i++)
        {
            Machine1And3TopNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine1And3TopNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                if (s.gameObject.activeInHierarchy)
                {
                    Machine1And3TopNozzles[j] = s;
                    j++;
                }

            }
            //Machine1And3TopNozzlesMasterDir.SetActive(false);
        }
        #endregion

        //Bottom
        #region
        j = 0;
        for (int i = 0; i < Machine4BottomNozzlesDir.Length; i++)
        {
            Machine4BottomNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine4BottomNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                //if(s.gameObject.active)
                //{
                Machine4BottomNozzles[j] = s;
                j++;
                //}

            }
            Machine4BottomNozzlesMasterDir.SetActive(false);
        }

        j = 0;
        for (int i = 0; i < Machine2BottomNozzlesDir.Length; i++)
        {
            Machine2BottomNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine2BottomNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                if (s.gameObject.activeInHierarchy)
                {
                    Machine2BottomNozzles[j] = s;
                    j++;
                }

            }
            Machine2BottomNozzlesMasterDir.SetActive(false);
        }

        j = 0;
        for (int i = 0; i < Machine1And3BottomNozzlesDir.Length; i++)
        {
            Machine1And3BottomNozzlesMasterDir.SetActive(true);
            foreach (UISlider s in Machine1And3BottomNozzlesDir[i].GetComponentsInChildren<UISlider>())
            {
                if (s.gameObject.activeInHierarchy)
                {
                    Machine1And3BottomNozzles[j] = s;
                    j++;
                }

            }
            Machine1And3BottomNozzlesMasterDir.SetActive(false);
        }
        #endregion

        Machine4NozzlesMasterDir.SetActive(false);
        Machine2NozzlesMasterDir.SetActive(false);
        Machine1And3TopNozzlesMasterDir.SetActive(true);
        
        //Configure The Dictionary For PhysicalCondition & PrimaryCooling Inputs
        #region
        Inputs = new Dictionary<UIInput, float>() {
                {IMachineNo, MachineNo},
                {IstrandNo, strandNo},
                {Iwidth,width},
                {Ispeed, speed},
                {ITundishTemp, TundishTemp},
                {IliquidTemp, liquidTemp},
                {IsolidTemp, solidTemp},
                {IWaterSecTemp, WaterSecTemp},
                {IsurTemp, surTemp},
                {IThickness, Thickness},
                {IFixedSideVFR, FixedSideVFR},
                {IFixedSideTempDif, FixedSideTempDif},
                {ILooseSideVFR,LooseSideVFR },
                {ILooseSideTempDif, LooseSideTempDif},
                {IRightNarrowSideVFR, RightNarrowSideVFR},
                {IRightNarrowSideTempDif, RightNarrowSideTempDif},
                {ILeftNarrowSideVFR, LeftNarrowSideVFR},
                {ILeftNarrowSideTempDif, LeftNarrowSideTempDif},
          };
        #endregion



        //Configure The Dictionary For PhysicalCondition & PrimaryCooling Outputs
        #region
        Outputs = new Dictionary<UILabel,float >() {
                {OMachineNo,Writer.Data[1]},
                {OstrandNo,Writer.Data[2] },
                {Owidth,Writer.Data[3]},
                {Ospeed,Writer.Data[4] },
                {OTundishTemp,Writer.Data[5] },
                { OliquidTemp,Writer.Data[6]},
                {OsolidTemp,Writer.Data[7] },
                {OWaterSecTemp,Writer.Data[8] },
                {OsurTemp,Writer.Data[9] },
                {OThickness,Writer.Data[10] },
                {OFixedSideVFR,Writer.Data[11] },
                {OFixedSideTempDif,Writer.Data[12] },
                {OLooseSideVFR,Writer.Data[13] },
                {OLooseSideTempDif,Writer.Data[14] },
                {ORightNarrowSideVFR,Writer.Data[15] },
                {ORightNarrowSideTempDif,Writer.Data[16] },
                {OLeftNarrowSideVFR,Writer.Data[17] },
                {OLeftNarrowSideTempDif,Writer.Data[18] },
          };
        #endregion
    }

    //Update is called once per frame
    void Update()
    {


        //Get inputs From PhysicalCondition & PrimaryCooling Tabs
        #region
        foreach (UIInput inp in Inputs.Keys)
        {
            EventDelegate del = new EventDelegate(this, "InputsSetValue");
            del.parameters[0].value = inp;
            EventDelegate.Add(inp.onChange, del);
        }
        #endregion

        //Get Inputs From Machine 1&3 Loops
        #region
        for (int i = 0; i < IMachine1And3Loops.Length; i++)
        {
            var inp = IMachine1And3Loops[i];
            EventDelegate del = new EventDelegate(this, "InputMachinesSetValue");
            del.parameters[0].value = inp;
            del.parameters[1].value = Machine1And3Loops;
            del.parameters[2].value = i;
            EventDelegate.Add(inp.onChange, del);
        }
        #endregion

        //Get Inputs From Machine 2 Loops
        #region
        for (int i = 0; i < IMachine2Loops.Length; i++)
        {
            var inp = IMachine2Loops[i];
            EventDelegate del = new EventDelegate(this, "InputMachinesSetValue");
            del.parameters[0].value = inp;
            del.parameters[1].value = Machine2Loops;
            del.parameters[2].value = i;
            EventDelegate.Add(inp.onChange, del);
        }
        #endregion

        //Get Inputs From Machine 4 Loops
        #region
        for (int i = 0; i < IMachine4Loops.Length; i++)
        {
            var inp = IMachine4Loops[i];
            EventDelegate del = new EventDelegate(this, "InputMachinesSetValue");
            del.parameters[0].value = inp;
            del.parameters[1].value = Machine4Loops;
            del.parameters[2].value = i;
            EventDelegate.Add(inp.onChange, del);
        }
        #endregion


    }
    void InputsSetValue(UIInput inp)
    {
        try
        {
            Inputs[inp] = float.Parse(inp.value);
            
        }
        catch
        {
            Inputs[inp] = 0;
        }
            
    }

    void InputMachinesSetValue(UIInput inp, float[] Output,int i)
    {
        try
        {
            Output[i] = float.Parse(inp.value);
        }
        catch
        {
            Output[i] = 0;
        }
        //Debug.Log(inp.ToString());

    }
}
