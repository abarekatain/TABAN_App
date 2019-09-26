using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text.RegularExpressions;


public class SecondaryCoolingInitialValues : MonoBehaviour {
    public string[] Data;
    public VariableDatabase VD;
    string[] stringSeparators = new string[] { "," };

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetInitial()
    {
        try
        {
            if (int.Parse(VD.IMachineNo.value) == 1 || int.Parse(VD.IMachineNo.value) == 3)
            {
                switch (int.Parse(VD.IsurTemp.value))
                {
                    case 1:
                        Setup(string.Format("{0}/CCM1,3/Group1.txt", Application.dataPath), 1);
                        break;
                    case 2:
                        Setup(string.Format("{0}/CCM1,3/Group2.txt", Application.dataPath), 1);
                        break;
                    case 3:
                        Setup(string.Format("{0}/CCM1,3/Group3.txt", Application.dataPath), 1);
                        break;
                    case 4:
                        Setup(string.Format("{0}/CCM1,3/Group4.txt", Application.dataPath), 1);
                        break;
                    case 5:
                        Setup(string.Format("{0}/CCM1,3/Group5.txt", Application.dataPath), 1);
                        break;

                    default:
                        break;
                }
            }
            else if (int.Parse(VD.IMachineNo.value) == 4)
            {
                switch (int.Parse(VD.IsurTemp.value))
                {
                    case 1:
                        Setup(string.Format("{0}/CCM4/Group1.txt", Application.dataPath), 4);
                        break;
                    case 2:
                        Setup(string.Format("{0}/CCM4/Group2.txt", Application.dataPath), 4);
                        break;
                    case 3:
                        Setup(string.Format("{0}/CCM4/Group3.txt", Application.dataPath),4);
                        break;
                    case 4:
                        Setup(string.Format("{0}/CCM4/Group4.txt", Application.dataPath), 4);
                        break;
                    case 5:
                        Setup(string.Format("{0}/CCM4/Group5.txt", Application.dataPath), 4);
                        break;

                    default:
                        break;
                }
            }
            else if (int.Parse(VD.IMachineNo.value) == 2)
            {
                switch (int.Parse(VD.IsurTemp.value))
                {
                    case 1:
                        Setup(string.Format("{0}/CCM2/Group1,2,5.txt", Application.dataPath), 2);
                        break;
                    case 2:
                        Setup(string.Format("{0}/CCM2/Group1,2,5.txt", Application.dataPath), 2);
                        break;
                    case 3:
                        Setup(string.Format("{0}/CCM2/Group3.txt", Application.dataPath), 2);
                        break;
                    case 4:
                        Setup(string.Format("{0}/CCM2/Group4.txt", Application.dataPath), 2);
                        break;
                    case 5:
                        Setup(string.Format("{0}/CCM2/Group1,2,5.txt", Application.dataPath), 2);
                        break;

                    default:
                        break;
                }
            }
    }
        catch(Exception ex) { Debug.Log(ex.ToString()); }
    }

    private void Setup(string path,int index)
    {
        Data = File.ReadAllLines(path);
        string[][] result = new string[Data.Length][];
        int CorrectIndex = 0;
        for (int i = 0; i < Data.Length; i++)
        {
            result[i] = Data[i].Split(stringSeparators,StringSplitOptions.RemoveEmptyEntries);
        }
        Debug.Log(result[0].Length);
        for (int i = 1; i < (result[0].Length-1); i++)
        {
            //Debug.Log(float.Parse(VD.Ispeed.value.Trim()));

            if (float.Parse(VD.Ispeed.value) >= float.Parse(result[0][i]) && float.Parse(VD.Ispeed.value) < float.Parse(result[0][i + 1]))
            {
                CorrectIndex = i;
               // Debug.Log("first");
                break;
            }
            else if (float.Parse(VD.Ispeed.value) >= float.Parse(result[0][result[0].Length - 1]))
            {
                CorrectIndex = result[0].Length - 1;
               // Debug.Log("sec");
                break;
            }
            else if (float.Parse(VD.Ispeed.value) < float.Parse(result[0][1]))
            {
                CorrectIndex = 1;
              //  Debug.Log("last");
                break;
            }
        }
        switch (index)
        {
            case 1:
                for (int i = 0; i < VD.IMachine1And3Loops.Length; i++)
                {
                    VD.IMachine1And3Loops[i].value = result[i + 1][CorrectIndex];
                }
                break;
            case 3:
                for (int i = 0; i < VD.IMachine1And3Loops.Length; i++)
                {
                    VD.IMachine1And3Loops[i].value = result[i + 1][CorrectIndex];
                }
                break;
            case 2:
                for (int i = 0; i < VD.IMachine2Loops.Length; i++)
                {
                    VD.IMachine2Loops[i].value = result[i + 1][CorrectIndex];
                }
                break;
            case 4:
                for (int i = 0; i < VD.IMachine4Loops.Length; i++)
                {
                    VD.IMachine4Loops[i].value = result[i + 1][CorrectIndex];
                }
                break;
            default:
                break;
        }

    }
}
