using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image energyBar;
    public Text timerText;
    public Text distanceText;

    private float timer;
    private float distance;

    private void Start()
    {
        Instance = this;
        Time.timeScale = 1.0f;
        timer = 0.0f;
    }
    public void EnergyUI(float _energy)
    {
        energyBar.fillAmount = _energy / 100.0f;
    }
    public void StatusGame(bool _isWin)
    {
        Time.timeScale = 0.0f;
        PanelManager.PanelInstance.ShowPanel(true);
        if (_isWin)
        {
            PanelManager.PanelInstance.StatusTextShow("Win!");
        }
        else
        {
            PanelManager.PanelInstance.StatusTextShow("Lose!");
        }
    }
    public void Distance(float _dis)
    {
        distance = _dis;
        distanceText.text = distance.ToString("f0") + " метров";
    }
    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("f1") + " сек";
    }
}
