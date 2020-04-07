using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwachGameController : MonoBehaviour {
    public GameObject _trash;
    public float force;
    public Vector3 direction;

    void Update () {
        if (Input.GetMouseButton(0)) {

            GameObject trash = Instantiate(_trash, Camera.main.transform.forward, Quaternion.identity) as GameObject;
            Rigidbody trashForce = trash.GetComponent<Rigidbody>();
            trashForce.AddForce(direction * force);

            Destroy(trash, 1f);

        }	
	}
}
