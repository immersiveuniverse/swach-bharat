using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseRaycastManager : MonoBehaviour {
    //public GameObject imageResult;
    //public Text Debugtext;

    public GameObject[] Result;
    public GameObject[] India;

    public Animator[] menuPressAnimator;

    bool isActive = false;
    bool isMission = false;
    bool isAchievement = false;
    bool isGallery = false;

    private Vector3 r1,r2,r3;
    private void Start()
    {
        r1 = Result[0].transform.position;
        r2 = Result[1].transform.position;
        r3 = Result[2].transform.position;
    }

    private void Update()
    {
        #region MainInput
        HandlingHits();
        #endregion
    }

    public void HandlingHits() {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.gameObject.name.Equals("1-Mission"))
                {
                    HitMission();
                }
                else if (hit.transform.gameObject.name.Equals("2-Achievement"))
                {
                    HitAchievement();
                }
                else if (hit.transform.gameObject.name.Equals("3-Gallery"))
                {
                    HitGallery();
                }
                else if (hit.transform.gameObject.name.Equals("4-Game"))
                {
                    HitGame();
                }
                else if (hit.transform.gameObject.name.Equals("g-top"))
                {
                    India[3].SetActive(true);
                }
                else if (hit.transform.gameObject.name.Equals("g-left"))
                {
                    India[2].SetActive(true);
                }
                else if (hit.transform.gameObject.name.Equals("g-right"))
                {
                    India[1].SetActive(true);
                }
                else if (hit.transform.gameObject.name.Equals("g-bottom"))
                {
                    India[0].SetActive(true);
                }
            }
        }
    }

    public void HitMission()
    {
        Result[1].SetActive(false);
        Result[2].SetActive(false);
        Result[3].SetActive(false);
        //Debugtext.text += "In If";

        if (isActive && isMission && !isAchievement && !isGallery)
        {
            Result[0].SetActive(false);

            menuPressAnimator[0].SetBool("doPress", false);
            isActive = false;
        }
        else
        {
            Result[0].SetActive(true);
            Result[0].transform.position = r1;
            Result[0].transform.localScale = Vector3.one;

            menuPressAnimator[0].SetBool("doPress", true);
            menuPressAnimator[1].SetBool("doPress", false);
            menuPressAnimator[2].SetBool("doPress", false);

            isActive = true;
            isMission = true;
            isAchievement = false;
            isGallery = false;
        }
    }

    public void HitAchievement() {
        Result[0].SetActive(false);
        Result[2].SetActive(false);
        Result[3].SetActive(false);
        //Debugtext.text += "In If";
        if (isActive && !isMission && isAchievement && !isGallery)
        {
            Result[1].SetActive(false);
            menuPressAnimator[1].SetBool("doPress", false);
            isActive = false;
        }
        else
        {
            Result[1].SetActive(true);
            Result[1].transform.position = r2;
            Result[1].transform.localScale = Vector3.one;

            menuPressAnimator[1].SetBool("doPress", true);
            menuPressAnimator[0].SetBool("doPress", false);
            menuPressAnimator[2].SetBool("doPress", false);

            isActive = true;
            isMission = false;
            isAchievement = true;
            isGallery = false;
        }
    }

    public void HitGallery() {
        Result[0].SetActive(false);
        Result[1].SetActive(false);
        Result[3].SetActive(false);

        //Debugtext.text += "In If";
        if (isActive && !isMission && !isAchievement && isGallery)
        {
            Result[2].SetActive(false);
            menuPressAnimator[2].SetBool("doPress", false);
            isActive = false;
        }
        else
        {
            Result[2].SetActive(true);
            Result[2].transform.position = r3;
            Result[2].transform.localScale = Vector3.one;

            menuPressAnimator[2].SetBool("doPress", true);
            menuPressAnimator[0].SetBool("doPress", false);
            menuPressAnimator[1].SetBool("doPress", false);

            isActive = true;
            isMission = false;
            isAchievement = false;
            isGallery = true;
        }
    }

    public void HitGame() {
        SceneManager.LoadScene("3_SwachBharat_Game_3D");    
    }
}
