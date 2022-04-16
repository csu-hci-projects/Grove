using UnityEngine;
using UnityEngine.UI; 

public class Progress : MonoBehaviour
{
    public Text progressDisplay;
    public Transform door;
    private float progress = 0f;
    private float check = 0f;

    void Start()
    {
        progressDisplay = GetComponent<Text>() as Text;
    }
    
    public void Update()
    {
        if (door == null && check == 0)
        {
            progress += 1;
            //progress = progress / 10f;
            check += 1;
        }
        progressDisplay.text = progress.ToString("0");
    }
}