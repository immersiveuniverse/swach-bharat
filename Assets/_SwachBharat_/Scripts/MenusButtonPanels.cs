using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusButtonPanels : MonoBehaviour
{
    public GameObject[] MenuPanels;
    public Button[] BtnMenus;

    private bool boolPanelOpen = false;
    public void HomeMenus(int index) {

        if (!boolPanelOpen)
        {
            MenuPanels[index].SetActive(true);
            boolPanelOpen = true;
        }
        else {
            MenuPanels[index].SetActive(false);
            boolPanelOpen = false;
        }
        
    }
}
