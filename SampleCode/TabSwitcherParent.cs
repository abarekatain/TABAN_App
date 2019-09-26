

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
////using Avarice.Ioc;
////using MainUI.ViewModels;



public class TabSwitcherParent : MonoBehaviour
{
    public List<TabSwitcherChild> Children = new List<TabSwitcherChild>();
    void Start()
    {
        foreach (TabSwitcherChild TC in gameObject.GetComponentsInChildren<TabSwitcherChild>())
        {
            Children.Add(TC);
        }

    }

    public void Add(TabSwitcherChild child)
    {
        Children.Add(child);
    }

    public void GoNext(TabSwitcherChild child)
    {
        int i = 0;
        foreach (TabSwitcherChild tc in Children)
        {
            try
            {
            if (child.gameObject.name == tc.gameObject.name)
            {
                UICamera.selectedObject = Children[i + 1].gameObject;
                return;
            }
            i++;
            }
            catch 
            {
                UICamera.selectedObject = Children[0].gameObject;
                return;

            }

        }
      
    }


}