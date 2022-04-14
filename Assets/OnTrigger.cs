using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AnswerCube")
        {
            Color red = Color.red;
            GetComponent<Renderer>().material.color = red;
        }
        else
        {
            return;
        }
    }
}
