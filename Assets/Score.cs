using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public Text scoreDisplay;
    public Transform door;
    private float score = 0f;
    private float check = 0f;

    void Start()
    {
        scoreDisplay = GetComponent<Text>() as Text;
    }
    
    public void Update()
    {
        if (door == null && check == 0)
        {
            score += 1;
            check += 1;
        }
        scoreDisplay.text = score.ToString("0");
    }
}
