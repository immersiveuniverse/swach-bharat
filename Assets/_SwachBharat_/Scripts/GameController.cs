using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject _trash;
	public Text gameobjectName;	
	int count=0;

	void Update(){
		
		if(Input.touchCount > 0){
			//Input.GetTouch(0).phase == TouchPhase.Began
			Touch touch = Input.GetTouch(0);
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (touch.position);

			if(touch.phase == TouchPhase.Began){

				GameObject trash = Instantiate (_trash, touchPosition, Quaternion.identity) as GameObject;
				Rigidbody trashForce = trash.GetComponent<Rigidbody> ();
				trashForce.AddForce(transform.forward * 300f);
				Destroy (trash, 1f);

				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit)){
					Debug.Log (hit.transform.name);
					Destroy (hit.transform.gameObject);
					//gameobjectName.text = hit.transform.name;
				}
				//gameobjectName.text = count + " " + trash.name +trash.transform.position; count++;
			}
		}
	}		
}
