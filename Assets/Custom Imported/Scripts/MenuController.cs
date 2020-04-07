using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MenuController : MonoBehaviour {
	public Button[] menuButtons;
	public GameObject[] imageTargets;
	private ImageTargetBehaviour itb;


	public void MahatmaActive(){
		imageTargets [0].SetActive (true);
		imageTargets [1].SetActive (false);
		imageTargets [2].SetActive (false);
		imageTargets [3].SetActive (false);
		imageTargets [4].SetActive (false);
	}

	public void MounumentActive(){
		imageTargets [0].SetActive (false);
		imageTargets [1].SetActive (true);
		imageTargets [2].SetActive (false);
		imageTargets [3].SetActive (false);
		imageTargets [4].SetActive (false);
	}

	public void GalleryActive(){
		imageTargets [0].SetActive (false);
		imageTargets [1].SetActive (false);
		imageTargets [2].SetActive (true);
		imageTargets [3].SetActive (false);
		imageTargets [4].SetActive (false);
	}

	public void InfoActive(){
		imageTargets [0].SetActive (false);
		imageTargets [1].SetActive (false);
		imageTargets [2].SetActive (false);
		imageTargets [3].SetActive (true);
		imageTargets [4].SetActive (false);
	}

	public void GameActive(){
		imageTargets [0].SetActive (false);
		imageTargets [1].SetActive (false);
		imageTargets [2].SetActive (false);
		imageTargets [3].SetActive (false);
		imageTargets [4].SetActive (true);
	}
}
