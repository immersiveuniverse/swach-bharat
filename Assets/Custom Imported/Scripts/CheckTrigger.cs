using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckTrigger : MonoBehaviour {

	int count=0;
	int total = 10;

	public Text check;
	public Text left;

	float targetTime = 15.0f;
	public Text timer;

	public GameObject panelWin, panelLose, trashCan;

	void Start(){
		check.text = "0";
		timer.text = "15";
	}

	void Update(){
		targetTime = targetTime % 60;
		timer.text = targetTime.ToString ("f1");
		targetTime -= Time.deltaTime;
		if(targetTime <= 0.0f){
			TimerEnded ();
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("WasteTag")){
			count++;
			total--;
			Debug.Log (count);
			SetCount ();
		}

		if(count >= 10){
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			panelWin.SetActive (true);
			trashCan.SetActive (false);
		}
	}


	void SetCount(){
		check.text = count.ToString ();
		left.text = total.ToString () + " more to go";
	}

	void TimerEnded(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		panelLose.SetActive (true);
		trashCan.SetActive (false);
	}
}
