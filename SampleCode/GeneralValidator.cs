using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralValidator : MonoBehaviour {
    //This Script Must Be Attached to NGUI UIInput to Work
    public UIInput Inp;
    public UILabel Lbl;
    public Vector2 WarningRange;
    public Vector2 LimitRange;
    public bool Islimited, IsWarning;
    public Color WarningTextColor;
    Color OriginalColor;
    public bool HasDefaultValue = true;
    public float DefaultValue;
    EventDelegate del;
    bool Onetime = true;
    void Start () {
        Inp = GetComponent<UIInput>();
        Lbl = GetComponentInChildren<UILabel>();
        OriginalColor = Lbl.color;
	}
	
	
	void Update () {

        if (GetComponent<UIInputOnGUI>() != null)
        {
            del = new EventDelegate(this, "DoValidate");
            EventDelegate.Add(Inp.onChange, del);
            Onetime = true;
        }
        else
        {
            if (Onetime)
            {
                ValidationFinalizing();
                Onetime = false;
            }
            
        }
    }

    void DoValidate()
    {
        float FieldValue;
        try
        {
            FieldValue = float.Parse(Inp.value);
            if (IsWarning)
            {
                if (FieldValue < WarningRange.x || FieldValue > WarningRange.y)
                    Lbl.color = WarningTextColor;
                else
                    Lbl.color = OriginalColor;
            }
            if (Islimited)
            {
                if (FieldValue < LimitRange.x)
                {
                    Inp.value = LimitRange.x.ToString();
                    FieldValue = float.Parse(Inp.value);
                }   
                else if (FieldValue > LimitRange.y)
                {
                    Inp.value = LimitRange.y.ToString();
                    FieldValue = float.Parse(Inp.value);
                }
                    
                //After Performing Limits,We Should Check Again The Warning Conditions
                if (IsWarning)
                {
                    if (FieldValue < WarningRange.x || FieldValue > WarningRange.y)
                        Lbl.color = WarningTextColor;
                    else
                        Lbl.color = OriginalColor;
                    
                }

            }

        }
        catch
        {
            return;
            
        }
        

    }

    void ValidationFinalizing()
    {
        EventDelegate.Execute(Inp.onChange);
        if (Inp.value.Trim() == "" && HasDefaultValue)
        {
            Inp.value = DefaultValue.ToString();
            
        }
    }


}
