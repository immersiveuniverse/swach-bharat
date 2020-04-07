using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public GameObject binPrefab;
    public float bagThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject _binPrefab = Instantiate(binPrefab, ray.origin, Quaternion.identity) as GameObject;
                Rigidbody _binRb =_binPrefab.GetComponent<Rigidbody>();
                _binRb.AddForce(transform.forward * bagThrow);

                Destroy(_binPrefab, 2.0f);
            }
        }
    }
}
