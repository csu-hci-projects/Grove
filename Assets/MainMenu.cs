using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Code referenced from " gamesplusjames"
    //https://www.youtube.com/watch?v=76WOa6IU_s8

    [Header("Level One Settings")]
    public Button buttonOne;
    public string levelOne;

    [Header("Level Two Settings")]
    public Button buttonTwo;
    public string levelTwo;

    [Header("Level Three Settings")]
    public Button buttonThree;
    public string levelThree;

    // Start is called before the first frame update
    void Start()
    {
        buttonOne = buttonOne.GetComponent<Button>();
        buttonTwo = buttonTwo.GetComponent<Button>();
        buttonThree = buttonThree.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableButton(Button button)
    {
        button.GetComponent<Button>().interactable = false;
    }

    public void LevelOne()
    {
        DisableButton(buttonOne);
        SceneManager.LoadScene(levelOne);
        Debug.Log("Level one loaded...");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(levelTwo);
        Debug.Log("Level two loaded...");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(levelThree);
        Debug.Log("Level three loaded...");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting application...");
    }
}
