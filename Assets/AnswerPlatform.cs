using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class AnswerPlatform : MonoBehaviour
{
    [Header("Question Settings")]

    public bool correct;
    public Transform door;
    private Color response;

    void OnTriggerEnter(Collider other)
    {
        response = Color.red;
        if (other.gameObject.tag == "AnswerCube")
        {
            if (correct == true)
            {
                response = Color.green;
                Debug.Log("Guessed correctly!");
            }
            else
            {
                Debug.Log("Guessed incorrectly");
            }
            GetComponent<Renderer>().material.color = response;
            other.GetComponent<Renderer>().material.color = response;
            door.GetComponent<Renderer>().material.color = response;
        }
        else
        {
            return;
        }
    }
}
