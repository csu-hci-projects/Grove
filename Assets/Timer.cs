using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{   
    public Text timerDisplay;
    public float timer = 0f;
 
    void Start()
    {
        timerDisplay = GetComponent<Text>() as Text;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerDisplay.text = timer.ToString("0");
    }

 }