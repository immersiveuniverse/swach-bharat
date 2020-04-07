using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMenu : MonoBehaviour {

    public Animator menuAnimator;
    private bool slideInOut = false;

    public void UploadMenu() {
        if (!slideInOut) {
            slideInOut = true;
            menuAnimator.SetBool("Slide_In_Out", slideInOut);
        } else if (slideInOut) {
            slideInOut = false;
            menuAnimator.SetBool("Slide_In_Out", slideInOut);
        }
    }
}
