using UnityEngine;
using System.Collections;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System;
public class TakeScreenshot : MonoBehaviour
{

    [DllImport("user32.dll")]
    private static extern void SaveFileDialog(); //in your case : OpenFileDialog

    //private int count = 0;
    public Transform BottomLeftPos;
    public Transform TopRightPos;
    public Transform CenterPos;
    Vector3 SBottomLeftPos, STopRightPos, SCenterPos;
    float Width, Height;
    //public Camera Cam;

    //public UISprite s;

    public Rect rect;

    //Texture2D texture;





    public int resWidth = 2550;
    public int resHeight = 3300;


    public Camera cam;
    public Camera MainCam;


     GameObject gcam;
     GameObject gMainCam;

    string filename;

    void Start()
    {
        gcam = cam.gameObject;
        gMainCam = MainCam.gameObject;
    }

    void Update()
    {
        //    //Vector3 pt = UICamera.currentCamera.WorldToScreenPoint(s.transform.position);
        //    //rect = new Rect(pt.x - s.width / 2, pt.y - s.height / 2, s.width, s.height);

        
        SBottomLeftPos = cam.WorldToScreenPoint(BottomLeftPos.position);
        STopRightPos = cam.WorldToScreenPoint(TopRightPos.position);
        SCenterPos = cam.WorldToScreenPoint(CenterPos.position);
        Width = STopRightPos.x - SBottomLeftPos.x;
        Height = STopRightPos.y - SBottomLeftPos.y;
        rect = new Rect(SBottomLeftPos, new Vector2(Width, Height));
        cam.transform.position = CenterPos.position;


        if (takeHiResShot)
        {
            gMainCam.SetActive(false);
            gcam.SetActive(true);
            StartCoroutine(w());
            
        }

    }


    private bool takeHiResShot = false;



    IEnumerator w()
    {

        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds(1f);
        resWidth = Screen.width;
        resHeight = Screen.height;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        cam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        //string filename = ScreenShotName(resWidth, resHeight);
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        takeHiResShot = false;
        gMainCam.SetActive(true);
        gcam.SetActive(false);
    }



    public void ShowSaveDialog()
    {
        System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

        saveFileDialog1.Filter = "PNG File|*.PNG";
        saveFileDialog1.Title = "Save Graph";
        saveFileDialog1.ShowDialog();
        if (saveFileDialog1.FileName != "")
        {
            filename = saveFileDialog1.FileName;
            takeHiResShot = true;
        }
    }



}
