using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
    }
    public void StatusGame(bool _isWin)
    {
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
