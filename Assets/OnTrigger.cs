using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [Header("Question Settings")]

    Color response;
    public bool correct;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AnswerCube")
        {
            if (correct == true)
            {
                response = Color.green;
                Debug.Log("Guessed correctly!");
            }
            else
            {
                response = Color.red;
                Debug.Log("Guessed incorrectly");
            }
            GetComponent<Renderer>().material.color = response;
        }
        else
        {
            return;
        }
    }
}
