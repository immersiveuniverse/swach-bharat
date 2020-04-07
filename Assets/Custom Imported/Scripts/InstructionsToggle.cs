using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsToggle : MonoBehaviour {

	public GameObject panelInstructions, trashCan, panelWin, panelLose, panelTour;
	public Image fadeImage, fadeVRTour;

	public void OpenInstructions(){
		panelInstructions.SetActive (true);
		fadeImage.gameObject.SetActive (true);
	}

	public void CloseInstructions(){
		if (SceneManager.GetActiveScene ().name == "2_Scan") {
			panelInstructions.SetActive (false);
			trashCan.SetActive (true);
		} else {
			panelInstructions.SetActive (false);
			fadeImage.gameObject.SetActive (false);
		}
	}

	public void CloseGuide(){
		panelInstructions.SetActive (false);
		fadeImage.gameObject.SetActive (false);
	}

	public void OpenVRTour(){
		panelTour.SetActive (true);
		fadeVRTour.gameObject.SetActive (true);
	}

	public void CloseVRTour(){
		panelTour.SetActive (false);
		fadeVRTour.gameObject.SetActive (false);
	}

	public void Lose(){
		panelLose.SetActive (false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Win(){
		panelWin.SetActive (false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Link(string link){
		Application.OpenURL (link);
	}
}
