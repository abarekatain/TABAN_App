using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class RunTheBackEndProgram : MonoBehaviour {

    public ReadDataFromFile RD;
    public WriteData2File WD;
    public GameObject Notification;
    string InstallApp;
    public bool OneTime = false;
    Process installProcess;
    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (OneTime)
        {
            if (installProcess.HasExited)
            {
                
                try
                {
                    Notification.SetActive(false);
                    OneTime = false;
                    CancelInvoke();
                    RD.PutData2Array();

                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.Log(ex);
                }
            }
            else
            {
                if (!IsInvoking("PercentUpdate"))
                {
                    InvokeRepeating("PercentUpdate", 1, 1);
                }
                
            }
        }


    }

     void PercentUpdate()
    {
        RD.UpdatePercentage();
        UnityEngine.Debug.Log("Dadaaaaaa");    
    }

    public void Run()
    {
        WD.PutData2Array();
        if (WD.Data[1] == 1||WD.Data[1] == 3)
        {
            InstallApp = string.Format("{0}/CCM1AND3.exe", Application.dataPath);
            installProcess = new Process();
            //settings up parameters for the install process
            installProcess.StartInfo.FileName = InstallApp;
            installProcess.StartInfo.UseShellExecute = false;
            installProcess.StartInfo.WorkingDirectory = Application.dataPath;
            installProcess.StartInfo.CreateNoWindow = true;

            installProcess.Start();
            Notification.SetActive(true);
            OneTime = true;

        }
        else if (WD.Data[1] == 2)
        {
            InstallApp = string.Format("{0}/CCM2.exe", Application.dataPath);
            installProcess = new Process();
            //settings up parameters for the install process
            installProcess.StartInfo.FileName = InstallApp;
            installProcess.StartInfo.UseShellExecute = false;
            installProcess.StartInfo.WorkingDirectory = Application.dataPath;
            installProcess.StartInfo.CreateNoWindow = true;
            installProcess.Start();
            Notification.SetActive(true);
            OneTime = true;

        }
        else if (WD.Data[1] == 4)
        {
            InstallApp = string.Format("{0}/CCM4.exe", Application.dataPath);
            installProcess = new Process();
            //settings up parameters for the install process
            installProcess.StartInfo.FileName = InstallApp;
            installProcess.StartInfo.UseShellExecute = false;
            installProcess.StartInfo.WorkingDirectory = Application.dataPath;
            installProcess.StartInfo.CreateNoWindow = true;
            installProcess.Start();
            Notification.SetActive(true);
            OneTime = true;

        }


    }


    void OnApplicationQuit()
    {
        try
        {
            installProcess.Kill();
        }
        catch
        {

            
        }

    }
}
