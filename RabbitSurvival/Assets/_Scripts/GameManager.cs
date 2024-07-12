using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image energyBar;

    private void Start()
    {
        Instance = this;
        Time.timeScale = 1.0f;
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
}
