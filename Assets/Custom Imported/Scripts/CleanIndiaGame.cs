using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanIndiaGame : MonoBehaviour {

	public GameObject wasteBag;
	public GameObject arCamera;
	public float bagThrowForce;

	public GameObject hitBin;


	/*
	int count=0;
	public Text check;
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("WasteTag")){
			check.text = count.ToString ();	
		}
	}
	*/

	public void Fire(){
		GameObject t_WasteBag;
		t_WasteBag = Instantiate (wasteBag, arCamera.transform.position, arCamera.transform.rotation) as GameObject;

		Rigidbody t_rgWB;
		t_rgWB = t_WasteBag.GetComponent<Rigidbody> ();
		t_rgWB.AddForce (transform.forward * bagThrowForce);

		Debug.Log (t_WasteBag.transform.position);
		Debug.Log (t_WasteBag.transform.rotation);

		Destroy (t_WasteBag, 5.0f);
	}
}
