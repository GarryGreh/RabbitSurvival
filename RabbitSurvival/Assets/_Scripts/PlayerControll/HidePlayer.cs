using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    private bool isHide = false;

    public void Hide(bool _isHide)
    {
        isHide = _isHide;
    }
    public bool CheckHide()
    {
        return isHide;
    }
}
