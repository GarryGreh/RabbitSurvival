using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ThirdPersonalController>() != null)
        {
            //other.gameObject.GetComponent<ThirdPersonalController>().Carrot();
            other.gameObject.GetComponent<ThirdPersonalController>().AddEnegy(RandomEnergy());
            Destroy(gameObject);
        }
    }
    private float RandomEnergy()
    {
        return Random.Range(5.0f, 30.0f);
    }
}
