using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    
    public void LoadScene(int index){
		SceneManager.LoadScene (index);
	}

	public void ExitApplication(){
		Application.Quit ();
	}

    public Animator Ashoka;
    private bool boolSpin = false;
    public void SpinAshoka() {
        if (!boolSpin) {
            Ashoka.enabled = true;
            boolSpin = true;
        }
        else {
            Ashoka.enabled = false;
            boolSpin = false;
        }
    }

    public GameObject GuidePanel;
    private bool boolGuide;
    public void GuidePop() {
        if (boolGuide)
        {
            boolGuide = false;
            GuidePanel.SetActive(false);
        }
        else
        {
            boolGuide = true;
            GuidePanel.SetActive(true);
        }
        
    }

    private void Start()
    {
        boolShow = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);

        if (boolShow == 0)
        {
            GuidePanel.SetActive(true);
            boolGuide = true;
            imgDontShowPopUp.GetComponent<Image>().sprite = imgUncheck;
            Debug.Log("Awake "+ SceneManager.GetActiveScene().name + " " + boolShow);
        }
        else {
            GuidePanel.SetActive(false);
            boolGuide = false;
            imgDontShowPopUp.GetComponent<Image>().sprite = imgCheck;
            Debug.Log("Awake " + SceneManager.GetActiveScene().name + " " + boolShow);
        }
    }

    private int boolShow = 0;
    public Image imgDontShowPopUp;
    public Sprite imgCheck, imgUncheck;
    public void DontShowPop()
    {
        if (boolShow==0)
        {
            boolShow = 1;
            //activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, boolShow);
            imgDontShowPopUp.GetComponent<Image>().sprite = imgCheck;
            Debug.Log("F "+ SceneManager.GetActiveScene().name + " "+ boolShow);
        }
        else
        {
            boolShow = 0;
            //activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, boolShow);
            imgDontShowPopUp.GetComponent<Image>().sprite = imgUncheck;
            Debug.Log("F " + SceneManager.GetActiveScene().name + " " + boolShow);
        }
    }


    public void OpenVideoTour(string videoUrl) {
        Application.OpenURL(videoUrl);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex > 1 && SceneManager.GetActiveScene().buildIndex <= 3)
            {
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(3);
            }
            else if (SceneManager.GetActiveScene().buildIndex <= 1)
            {
                Application.Quit();
            }
        }
    }
}
