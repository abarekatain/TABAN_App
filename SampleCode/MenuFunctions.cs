using UnityEngine;
using System.Collections;

public class MenuFunctions : MonoBehaviour {
    public UIScrollBar ReportPanelScrollBar;
    // Use this for initialization
    void Start()
    {
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void ResetReportSlider()
    {
        ReportPanelScrollBar.value = 0;
    }
}
