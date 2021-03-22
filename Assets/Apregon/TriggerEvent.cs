using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        //print("Distance to target: " + dist);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        GetComponent<MeshRenderer>().enabled=true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        GetComponent<MeshRenderer>().enabled = false;
    }
}
