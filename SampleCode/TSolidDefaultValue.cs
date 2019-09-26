using UnityEngine;
using System.Collections;

public class TSolidDefaultValue : MonoBehaviour {
    public UIInput TsolidInput;
    public UIInput TLiquidInput;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetValue()
    {
        try
        {
            TsolidInput.value = (float.Parse(TLiquidInput.value) - 20f).ToString();
        }
        catch (System.Exception)
        {

           
        }
        
    }

}
