using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class FreeLookCamControll : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image areaCamControll;
    [SerializeField]
    private CinemachineFreeLook camFreeLook;
    string strMouseX = "Mouse X", strMouseY = "Mouse Y";

    private void Start()
    {
        areaCamControll = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(areaCamControll.rectTransform, 
            eventData.position, eventData.enterEventCamera, out Vector2 posOut))
        {
            camFreeLook.m_XAxis.m_InputAxisName = strMouseX;
            camFreeLook.m_YAxis.m_InputAxisName= strMouseY;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        camFreeLook.m_XAxis.m_InputAxisName = null;
        camFreeLook.m_YAxis.m_InputAxisName = null;
        camFreeLook.m_XAxis.m_InputAxisValue = 0f;
        camFreeLook.m_YAxis.m_InputAxisValue= 0f;
    }
}
