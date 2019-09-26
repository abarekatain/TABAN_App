using UnityEngine;
using System.Collections;
public class TabSwitcherChild : MonoBehaviour
{
    public int TabIndex = 0;
    public TabSwitcherParent controller;
    public bool Pressed = false;

    void Update()
    {

        if (UICamera.selectedObject == gameObject && Input.GetKeyDown(KeyCode.Tab))
        {
            Pressed = true;
        }
        if (Pressed == true && Input.GetKeyUp(KeyCode.Tab))
        {
            controller.GoNext(this);Pressed = false;
        }


    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }

}