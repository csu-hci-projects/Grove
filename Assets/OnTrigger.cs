using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //other.GetComponent<Rigidbody>().material.color = Color.red;
        Color red = Color.red;
        GetComponent<Renderer>().material.color = red;
    }
}
