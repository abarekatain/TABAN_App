using UnityEngine;
using System.Collections;

public class CustomRescaleAnchor : MonoBehaviour {
    public float XScaleCoefficient;
    public float YScaleCoefficient;
    float xAxisLength, yAxisLength;
    // Use this for initialization
    void Start () {
        xAxisLength = transform.localScale.x;
        yAxisLength = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.localScale = new Vector3(xAxisLength * Screen.width * XScaleCoefficient, yAxisLength * Screen.height * YScaleCoefficient, 0);
        GetComponent<UIAnchor>().enabled = true;
    }
}
