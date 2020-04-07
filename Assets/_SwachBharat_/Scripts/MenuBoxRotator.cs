using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuBoxRotator : MonoBehaviour
{
    public GameObject BoxObject;
    public Button btnPlayPause;
    public Text textPlayPause;
    public Sprite play, pause;

    private Animator BoxAnimator;

    private void Start()
    {
        BoxAnimator = BoxObject.GetComponent<Animator>();
    }

    private bool boolPlayPause = false;
    public void PlayPauseBox() {
        if (!boolPlayPause)
        {
            BoxAnimator.enabled = true;
            boolPlayPause = true;

            btnPlayPause.GetComponent<Image>().sprite = pause;
            textPlayPause.GetComponent<Text>().text = "Pause";            
        }
        else {
            BoxAnimator.enabled = false;
            boolPlayPause = false;

            btnPlayPause.GetComponent<Image>().sprite = play;
            textPlayPause.GetComponent<Text>().text = "Play";            
        }
    }


}
