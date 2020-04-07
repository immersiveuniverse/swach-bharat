using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderCustom : MonoBehaviour {
	public GameObject panelCongo, panelTime;
	public GameObject PanelWarning;

	public Image FadeInOut;
	public Animator FadeInOutAnim;

	void Start(){
		if(SceneManager.GetActiveScene().name != "0_Index"){
			FadeInOut.gameObject.SetActive (true);	
		}
	}


	void Update(){
		if (SceneManager.GetActiveScene ().name != "0_Index") {
			if (FadeInOut.color.a == 0) {
				FadeInOut.gameObject.SetActive (false);
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (SceneManager.GetActiveScene ().buildIndex > 1 && SceneManager.GetActiveScene ().buildIndex <= 3) {
				Debug.Log(SceneManager.GetActiveScene ().buildIndex);
				SceneManager.LoadScene (1);
			}else if(SceneManager.GetActiveScene ().buildIndex > 3){
				SceneManager.LoadScene (3);	
			} else if (SceneManager.GetActiveScene ().buildIndex <= 1) {
				Application.Quit();	
			}
		}
	}

	public void Refresh(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadScene(int sceneindex){
		SceneManager.LoadScene(sceneindex);
		if (SceneManager.GetActiveScene ().buildIndex > 1) {

		}
	}
		
/*
	public void EnablePanelWarning(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PanelWarning.SetActive (false);
		} else {
			PanelWarning.SetActive (true);
		}
	}

	public void StayGameYes() {
		PanelWarning.SetActive (false);
	}

	public void StayGameNo(){
		Debug.Log ("Quit");
		Application.Quit ();
	}

	public void LoadScene(string scenename){
		SceneManager.LoadScene(scenename);
	}
*/


	public void ExitApp(){
		Application.Quit();
	}
}

