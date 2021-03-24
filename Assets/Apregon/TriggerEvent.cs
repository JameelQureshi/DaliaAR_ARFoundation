using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Transform target;
    public Material material;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist > 0.2f)
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
        }
        else
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 0.0f);
        }
        print("Distance to target: " + dist);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("OnTriggerEnter");
    //    material.color = new Color(material.color.r, material.color.g, material.color.b,0.0f);
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("OnTriggerExit");
    //    material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
    //}
}
