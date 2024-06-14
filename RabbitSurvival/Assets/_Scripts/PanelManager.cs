using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager PanelInstance;

    public GameObject panel;
    public Text statusText;

    private void Start()
    {
        PanelInstance = this;
        panel.SetActive(false);
    }
    public void ShowPanel(bool _isShow)
    {
        panel.SetActive(_isShow);
    }
    public void StatusTextShow(string _text)
    {
        statusText.text = _text;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
