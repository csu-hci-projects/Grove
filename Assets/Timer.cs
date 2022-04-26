using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{   
    //public Transform end;
    public Text timerDisplay;
    private float timer = 0f;
    //private bool timing = true;
 
    void Start()
    {
        timerDisplay = GetComponent<Text>() as Text;
        //end = end.GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerDisplay.text = timer.ToString("0");
    }
 }