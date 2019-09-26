using UnityEngine;
using System.Collections;

public class PrimaryCoolingInitialValues : MonoBehaviour {
    public VariableDatabase VD;
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
            if (int.Parse(VD.IMachineNo.value) == 2)
            {
                VD.IFixedSideTempDif.value = VD.ILooseSideTempDif.value = "6";
                VD.IFixedSideVFR.value = VD.ILooseSideVFR.value = "3725";
                VD.IRightNarrowSideTempDif.value = VD.ILeftNarrowSideTempDif.value = "6";
                VD.IRightNarrowSideVFR.value = VD.ILeftNarrowSideVFR.value = "387";
            }
            else
            {
                if (int.Parse(VD.Iwidth.value) >= 1300)
                {
                    VD.IFixedSideTempDif.value = VD.ILooseSideTempDif.value = "8";
                    VD.IFixedSideVFR.value = VD.ILooseSideVFR.value = "3200";
                    VD.IRightNarrowSideTempDif.value = VD.ILeftNarrowSideTempDif.value = "9";
                    VD.IRightNarrowSideVFR.value = VD.ILeftNarrowSideVFR.value = "380";
                }
                else
                {
                    VD.IFixedSideTempDif.value = VD.ILooseSideTempDif.value = "7";
                    VD.IFixedSideVFR.value = VD.ILooseSideVFR.value = "2600";
                    VD.IRightNarrowSideTempDif.value = VD.ILeftNarrowSideTempDif.value = "8";
                    VD.IRightNarrowSideVFR.value = VD.ILeftNarrowSideVFR.value = "350";
                }
            }
        }
        catch { }
    
}
}
