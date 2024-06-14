using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShelterScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<HidePlayer>())
        {
            other.gameObject.GetComponent<HidePlayer>().Hide(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<HidePlayer>())
        {
            other.gameObject.GetComponent<HidePlayer>().Hide(false);
        }
    }
}
