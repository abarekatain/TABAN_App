using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ReadDataFromFile : MonoBehaviour {
    public string[] Data;
    public string[] SecondData;
    public string PercentageTemp;
    public UILabel PercentLabel;
    public VariableDatabase VD;
    // Use this for initialization
    string[] stringSeparators = new string[] { "," };
    public int[] M1And3EndOfSegIndex, M2EndOfSegIndex, M4EndOfSegIndex; // MoldIndex,SegIndexes,...,StrandIndex


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReadData()
    {
        Data = File.ReadAllLines(string.Format("{0}/output.sm", Application.dataPath));
    }

    public void UpdatePercentage()
    {
        try
        {
            //PercentageTemp = File.ReadAllLines(string.Format("{0}/output.sm", Application.dataPath));

            using (FileStream stream = File.Open(string.Format("{0}/output.sm", Application.dataPath), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        PercentageTemp =reader.ReadToEnd();
                        PercentLabel.text = PercentageTemp.Trim() + "%";
                    }
                }
            }



            
        }
        catch(Exception ex)
        {
            Debug.LogError(ex);
            
        }

    }

    public void PutData2Array()
    {
        ReadData();
            //////
            VD.GeneralRes.MetallurgicalLength = float.Parse(Data[1]);
            VD.GeneralRes.OREPMettalurgicalLength.text = VD.GeneralRes.ORESMettalurgicalLength.text = Data[1];
            //////
            VD.GeneralRes.MeanTempDiff = float.Parse(Data[2]);
            VD.GeneralRes.OREPMeanTempDiff.text = VD.GeneralRes.ORESMeanTempDiff.text = Data[2];
            //////
            VD.GeneralRes.MaxTempDiff = float.Parse(Data[3]);
            VD.GeneralRes.OREPMaxTempDiff.text = VD.GeneralRes.ORESMaxTempDiff.text = Data[3];
            //////
            VD.MoldExitProp.TopMoldSolidThickness = float.Parse(Data[4]);
            VD.MoldExitProp.OTopMoldSolidThickness.text = Data[4];
            //////
            VD.MoldExitProp.BottomMoldSolidThickness = float.Parse(Data[5]);
            VD.MoldExitProp.OBottomMoldSolidThickness.text = Data[5];
            //////
            VD.MoldExitProp.NarrowRightMoldSolidThickness = float.Parse(Data[6]);
            VD.MoldExitProp.ONarrowRightMoldSolidThickness.text = Data[6];
            //////
            VD.MoldExitProp.NarrowLeftMoldSolidThickness = float.Parse(Data[7]);
            VD.MoldExitProp.ONarrowLeftMoldSolidThickness.text = Data[7];
            //////

            if (VD.Inputs[VD.IMachineNo] == 1 || VD.Inputs[VD.IMachineNo] == 3)
            {
                for (int i = 0; i < VD.Points1And3.Length; i++)
                {
                    string[] result;
                    result = Data[8 + i].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    VD.Points1And3[i].CenterPointTemp = float.Parse(result[0].Trim());
                    VD.Points1And3[i].TopFaceTemp = float.Parse(result[1].Trim());
                    VD.Points1And3[i].BottomFaceTemp = float.Parse(result[2].Trim());
                    VD.Points1And3[i].NarrowRightFaceTemp = float.Parse(result[3].Trim());
                    VD.Points1And3[i].NarrowLeftFaceTemp = float.Parse(result[4].Trim());
                    VD.Points1And3[i].SolidThicknessOfBottomFace = float.Parse(result[5].Trim());
                    VD.Points1And3[i].SolidThicknessOfTopFace = float.Parse(result[6].Trim());
                    VD.Points1And3[i].SolidThicknessOfNarrowRightFace = float.Parse(result[7].Trim());
                    VD.Points1And3[i].SolidThicknessOfNarrowLeftFace = float.Parse(result[8].Trim());
                    VD.Points1And3[i].TempAsymmetry = float.Parse(result[9].Trim());
                    VD.Points1And3[i].Distance = float.Parse(result[10].Trim());
                    VD.Points1And3[i].RollNo = i - 2;
                    ////////////////
                    for (int j = 0; j < M1And3EndOfSegIndex.Length; j++)
                    {
                        if (M1And3EndOfSegIndex[j] == i)
                        {
                            VD.Machine1And3SegmentRes[j].OTCenter.text = VD.Points1And3[i].CenterPointTemp.ToString();
                            VD.Machine1And3SegmentRes[j].OTMidWideTop.text = VD.Points1And3[i].TopFaceTemp.ToString();
                            VD.Machine1And3SegmentRes[j].OTMidWideBot.text = VD.Points1And3[i].BottomFaceTemp.ToString();
                            VD.Machine1And3SegmentRes[j].OTMidNarr.text = (VD.Points1And3[i].NarrowRightFaceTemp / 2 + VD.Points1And3[i].NarrowLeftFaceTemp / 2).ToString();
                            VD.Machine1And3SegmentRes[j].OThickWide.text = (VD.Points1And3[i].SolidThicknessOfBottomFace / 2 + VD.Points1And3[i].SolidThicknessOfTopFace / 2).ToString();
                            VD.Machine1And3SegmentRes[j].OThickNarr.text = (VD.Points1And3[i].SolidThicknessOfNarrowRightFace / 2 + VD.Points1And3[i].SolidThicknessOfNarrowLeftFace / 2).ToString();
                            VD.Machine1And3SegmentRes[j].OTempDiff.text = VD.Points1And3[i].TempAsymmetry.ToString();
                        }
                    }
                    //////////////////
                }
            }
            else if (VD.Inputs[VD.IMachineNo] == 2)
            {
                for (int i = 0; i < VD.Points2.Length; i++)
                {
                    string[] result;
                    result = Data[8 + i].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    VD.Points2[i].CenterPointTemp = float.Parse(result[0].Trim());
                    VD.Points2[i].TopFaceTemp = float.Parse(result[1].Trim());
                    VD.Points2[i].BottomFaceTemp = float.Parse(result[2].Trim());
                    VD.Points2[i].NarrowRightFaceTemp = float.Parse(result[3].Trim());
                    VD.Points2[i].NarrowLeftFaceTemp = float.Parse(result[4].Trim());
                    VD.Points2[i].SolidThicknessOfBottomFace = float.Parse(result[5].Trim());
                    VD.Points2[i].SolidThicknessOfTopFace = float.Parse(result[6].Trim());
                    VD.Points2[i].SolidThicknessOfNarrowRightFace = float.Parse(result[7].Trim());
                    VD.Points2[i].SolidThicknessOfNarrowLeftFace = float.Parse(result[8].Trim());
                    VD.Points2[i].TempAsymmetry = float.Parse(result[9].Trim());
                    VD.Points2[i].Distance = float.Parse(result[10].Trim());
                    VD.Points2[i].RollNo = i - 2;
                    ////////////////
                    for (int j = 0; j < M2EndOfSegIndex.Length; j++)
                    {
                        if (M2EndOfSegIndex[j] == i)
                        {
                            VD.Machine2And4SegmentRes[j].OTCenter.text = VD.Points2[i].CenterPointTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidWideTop.text = VD.Points2[i].TopFaceTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidWideBot.text = VD.Points2[i].BottomFaceTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidNarr.text = (VD.Points2[i].NarrowRightFaceTemp / 2 + VD.Points2[i].NarrowLeftFaceTemp / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OThickWide.text = (VD.Points2[i].SolidThicknessOfBottomFace / 2 + VD.Points2[i].SolidThicknessOfTopFace / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OThickNarr.text = (VD.Points2[i].SolidThicknessOfNarrowRightFace / 2 + VD.Points2[i].SolidThicknessOfNarrowLeftFace / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OTempDiff.text = VD.Points2[i].TempAsymmetry.ToString();
                        }
                    }
                    //////////////////
                }
            }
            else if (VD.Inputs[VD.IMachineNo] == 4)
            {
                for (int i = 0; i < VD.Points4.Length; i++)
                {
                    string[] result;
                    result = Data[8 + i].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    VD.Points4[i].CenterPointTemp = float.Parse(result[0].Trim());
                    VD.Points4[i].TopFaceTemp = float.Parse(result[1].Trim());
                    VD.Points4[i].BottomFaceTemp = float.Parse(result[2].Trim());
                    VD.Points4[i].NarrowRightFaceTemp = float.Parse(result[3].Trim());
                    VD.Points4[i].NarrowLeftFaceTemp = float.Parse(result[4].Trim());
                    VD.Points4[i].SolidThicknessOfBottomFace = float.Parse(result[5].Trim());
                    VD.Points4[i].SolidThicknessOfTopFace = float.Parse(result[6].Trim());
                    VD.Points4[i].SolidThicknessOfNarrowRightFace = float.Parse(result[7].Trim());
                    VD.Points4[i].SolidThicknessOfNarrowLeftFace = float.Parse(result[8].Trim());
                    VD.Points4[i].TempAsymmetry = float.Parse(result[9].Trim());
                    VD.Points4[i].Distance = float.Parse(result[10].Trim());
                    VD.Points4[i].RollNo = i - 2;
                    ////////////////
                    for (int j = 0; j < M4EndOfSegIndex.Length; j++)
                    {
                        if (M4EndOfSegIndex[j] == i)
                        {
                            VD.Machine2And4SegmentRes[j].OTCenter.text = VD.Points4[i].CenterPointTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidWideTop.text = VD.Points4[i].TopFaceTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidWideBot.text = VD.Points4[i].BottomFaceTemp.ToString();
                            VD.Machine2And4SegmentRes[j].OTMidNarr.text = (VD.Points4[i].NarrowRightFaceTemp / 2 + VD.Points4[i].NarrowLeftFaceTemp / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OThickWide.text = (VD.Points4[i].SolidThicknessOfBottomFace / 2 + VD.Points4[i].SolidThicknessOfTopFace / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OThickNarr.text = (VD.Points4[i].SolidThicknessOfNarrowRightFace / 2 + VD.Points4[i].SolidThicknessOfNarrowLeftFace / 2).ToString();
                            VD.Machine2And4SegmentRes[j].OTempDiff.text = VD.Points4[i].TempAsymmetry.ToString();
                        }
                    }
                    //////////////////
                }
            }
            Debug.Log("Reading Completed");
        
        
    }

    public void ReadSecondOutput()
    {
        SecondData = File.ReadAllLines(string.Format("{0}/output2.sm", Application.dataPath));

    }


}
