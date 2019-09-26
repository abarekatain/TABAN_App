using UnityEngine;
using System.Collections;

public class Plotter : MonoBehaviour {
    public WMG_Axis_Graph Wag;
    public WMG_Series Ws;
    public VariableDatabase VD;
    public WriteData2File Writer;
    public float Telorance;
    public UILabel UnitLabel;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Plot(UIPopupList pp)
    {
        try
        {
            if (pp.value == pp.items[0].ToString())
            {
                //CenterPointTemp
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = 400;
                Wag.yAxisMaxValue = 1600;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.CenterPointTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.CenterPointTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.CenterPointTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

            }
            else if (pp.value == pp.items[1].ToString())
            {
                //TopFaceTemp
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = 400;
                Wag.yAxisMaxValue = 1600;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TopFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TopFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TopFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[2].ToString())
            {
                //BottomFaceTemp
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = 400;
                Wag.yAxisMaxValue = 1600;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.BottomFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.BottomFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.BottomFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[3].ToString())
            {
                //NarrowRightTemp
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = 400;
                Wag.yAxisMaxValue = 1600;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowRightFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowRightFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowRightFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[4].ToString())
            {
                //NarrowLeftTemp
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = 400;
                Wag.yAxisMaxValue = 1600;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowLeftFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowLeftFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.NarrowLeftFaceTemp;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[5].ToString())
            {
                //SolidThicknessOfTopFace
                UnitLabel.text = "[mm]";
                Wag.yAxisMinValue = 0;
                Wag.yAxisMaxValue = 100;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfTopFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfTopFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfTopFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[6].ToString())
            {
                //SolidThicknessOfBottomFace
                UnitLabel.text = "[mm]";
                Wag.yAxisMinValue = 0;
                Wag.yAxisMaxValue = 100;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfBottomFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfBottomFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfBottomFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[7].ToString())
            {
                //SolidThicknessOfRightNarrowFace
                UnitLabel.text = "[mm]";
                Wag.yAxisMinValue = 0;
                Wag.yAxisMaxValue = 1000;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowRightFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowRightFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowRightFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[8].ToString())
            {
                //SolidThicknessOfLeftNarrowFace
                UnitLabel.text = "[mm]";
                Wag.yAxisMinValue = 0;
                Wag.yAxisMaxValue = 1000;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowLeftFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowLeftFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.SolidThicknessOfNarrowLeftFace;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
            else if (pp.value == pp.items[9].ToString())
            {
                //Temp.Diff.
                UnitLabel.text = "[°C]";
                Wag.yAxisMinValue = -40;
                Wag.yAxisMaxValue = 40;
                Wag.axesType = WMG_Axis_Graph.axesTypes.I_IV;
                if (Writer.Data[1] == 1 || Writer.Data[1] == 3)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points1And3)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TempAsymmetry;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
                if (Writer.Data[1] == 2)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points2)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TempAsymmetry;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }

                if (Writer.Data[1] == 4)
                {
                    Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
                    Vector2 vct = new Vector2();
                    foreach (var item in VD.Points4)
                    {
                        int i = 0;
                        vct.x = item.Distance;
                        vct.y = item.TempAsymmetry;
                        Ws.pointValues.Insert(i, vct);
                        if (vct.x > Wag.xAxisMaxValue) Wag.xAxisMaxValue = vct.x + Telorance;
                        if (vct.x < Wag.xAxisMinValue) Wag.xAxisMinValue = vct.x - Telorance;
                        if (vct.y > Wag.yAxisMaxValue) Wag.yAxisMaxValue = vct.y + Telorance;
                        if (vct.y < Wag.yAxisMinValue) Wag.yAxisMinValue = vct.y - Telorance;
                        i++;
                    }
                }
            }
        }
        catch { }
    }
}
