using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class MachinesSwitcher : MonoBehaviour {

    public GameObject[] M1And3, M2, M4;
    public MenuFunctions Menufunction;
    public int SeriesIndex; //index of series object included in Mi GameObject Array
    public VariableDatabase VD;
    public WMG_Axis_Graph WG;
    public ResultGraphSlider RGS;

    public void SwitchMachine()
    {
        try
        {
            if (VD.IMachineNo.value.Trim() == "1" || VD.IMachineNo.value.Trim() == "3")
            {
                for (int i = 0; i < 5; i++)
                {
                    M2[i].SetActive(false);
                    M4[i].SetActive(false);
                    M1And3[i].SetActive(true);

                }

            }
            else if (VD.IMachineNo.value.Trim() == "2")
            {
                for (int i = 0; i < 5; i++)
                {
                    M1And3[i].SetActive(false);
                    M4[i].SetActive(false);
                    M2[i].SetActive(true);
                }


            }
            else if (VD.IMachineNo.value.Trim() == "4")
            {
                for (int i = 0; i < 5; i++)
                {
                    M1And3[i].SetActive(false);
                    M2[i].SetActive(false);
                    M4[i].SetActive(true);
                }


            }

            RGS.SliderInitialize();
            Menufunction.ResetReportSlider();

        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    public void Test()
    {
        Debug.Log("test");

    }



}
