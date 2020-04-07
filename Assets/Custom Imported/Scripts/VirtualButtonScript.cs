using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject flagBtn, flagSource;

	void Start () {
		flagBtn = GameObject.Find ("flagBtn");
		flagBtn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb){
		flagSource.SetActive (true);	
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb){
		flagSource.SetActive (false);
	}
}
