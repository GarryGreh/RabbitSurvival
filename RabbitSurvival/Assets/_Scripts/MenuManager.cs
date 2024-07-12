using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
