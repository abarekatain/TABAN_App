using UnityEngine;
using System.Collections;
using System.IO;

public class WriteData2File : MonoBehaviour {

    public float[] Data;
    public VariableDatabase VD;
    public int DataLength;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PutData2Array()
    {
        //Physical Condition
        Data[1] = float.Parse(VD.IMachineNo.value);
        VD.OMachineNo.text = Data[1].ToString();

        Data[2] = float.Parse(VD.IstrandNo.value);
        VD.OstrandNo.text = Data[2].ToString();

        Data[3] = float.Parse(VD.Iwidth.value);
        VD.Owidth.text = Data[3].ToString();

        Data[4] = float.Parse(VD.Ispeed.value);
        VD.Ospeed.text = Data[4].ToString();

        Data[5] = float.Parse(VD.ITundishTemp.value);
        VD.OTundishTemp.text = Data[5].ToString();

        Data[6] = float.Parse(VD.IliquidTemp.value);
        VD.OliquidTemp.text = Data[6].ToString();

        Data[7] = float.Parse(VD.IsolidTemp.value);
        VD.OsolidTemp.text = Data[7].ToString();

        Data[8] = float.Parse(VD.IWaterSecTemp.value);
        VD.OWaterSecTemp.text = Data[8].ToString();

        Data[9] = float.Parse(VD.IsurTemp.value);
        VD.OsurTemp.text = Data[9].ToString();

        Data[10] = float.Parse(VD.IThickness.value);
        VD.OThickness.text = Data[10].ToString();
        //Primary Cooling
        Data[11] = float.Parse(VD.IFixedSideVFR.value);
        VD.OFixedSideVFR.text = Data[11].ToString();
        Data[12] = float.Parse(VD.IFixedSideTempDif.value);
        VD.OFixedSideTempDif.text = Data[12].ToString();

        Data[13] = float.Parse(VD.ILooseSideVFR.value);
        VD.OLooseSideVFR.text = Data[13].ToString();
        Data[14] = float.Parse(VD.ILooseSideTempDif.value);
        VD.OLooseSideTempDif.text = Data[14].ToString();

        Data[15] = float.Parse(VD.IRightNarrowSideVFR.value);
        VD.ORightNarrowSideVFR.text = Data[15].ToString();
        Data[16] = float.Parse(VD.IRightNarrowSideTempDif.value);
        VD.ORightNarrowSideTempDif.text = Data[16].ToString();

        Data[17] = float.Parse(VD.ILeftNarrowSideVFR.value);
        VD.OLeftNarrowSideVFR.text = Data[17].ToString();
        Data[18] = float.Parse(VD.ILeftNarrowSideTempDif.value);
        VD.OLeftNarrowSideTempDif.text = Data[18].ToString();


        //Conditional Inputs
        //Machines Loops
        if (VD.IMachineNo.value.Trim() == "1" || VD.IMachineNo.value.Trim() == "3")
        {
            int i = 1;
            foreach (float l in VD.Machine1And3Loops)
            {
                Data[18 + i] = l;
                try
                {
                    VD.OMachine1And3Loops[i-1].text = l.ToString();
                }
                catch
                {
                    VD.OMachine1And3Loops[i-1].text = "0";
                }
                i++; 
            }
            foreach (UISlider s in VD.Machine1And3TopNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine1And3BottomNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine1And3RightNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine1And3LeftNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            Data[18 + i] = -1f;

        }
        else if (VD.IMachineNo.value.Trim() == "2")
        {
            int i = 1;
            foreach (float l in VD.Machine2Loops)
            {
                Data[18 + i] = l;
                try
                {
                    VD.OMachine2Loops[i-1].text = l.ToString();
                }
                catch
                {
                    VD.OMachine2Loops[i-1].text = "0";
                }
                i++;
            }
            foreach (UISlider s in VD.Machine2TopNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine2BottomNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine2RightNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine2LeftNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            Data[18 + i] = -1f;
        }
        else if (VD.IMachineNo.value.Trim() == "4")
        {
            int i = 1;
            foreach (float l in VD.Machine4Loops)
            {
                Data[18 + i] = l;
                try
                {
                    VD.OMachine4Loops[i-1].text = l.ToString();
                }
                catch
                {
                    VD.OMachine4Loops[i-1].text = "0";
                }
                i++;
            }
            foreach (UISlider s in VD.Machine4TopNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine4BottomNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine4RightNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            foreach (UISlider s in VD.Machine4LeftNozzles)
            {
                Data[18 + i] = s.value;
                i++;
            }
            Data[18 + i] = -1f;
        }

        WriteData();



    }

    public void WriteData()
    {
        
        for (int i = 1; i < Data.Length; i++)
        {
            if (Data[i] == -1f)
                DataLength = i;
        }
        string[] data = new string[DataLength];
        for (int i = 1; i < DataLength; i++)
        {
            data[i] = Data[i].ToString();
        }
        data[0] = "101";
        File.WriteAllLines(string.Format("{0}/input.sm", Application.dataPath), data);
    }
}
