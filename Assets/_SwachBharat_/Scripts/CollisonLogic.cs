using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisonLogic : MonoBehaviour {

	public Text gameobjectName;
	int count=0;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("trash")) {
			Destroy (other, 0.1f);
			this.GetComponent<Renderer> ().material.color = Color.green;
			count++;
			gameobjectName.text = count + "";
		}
		this.GetComponent<Renderer> ().material.color = Color.black;
	}
}
