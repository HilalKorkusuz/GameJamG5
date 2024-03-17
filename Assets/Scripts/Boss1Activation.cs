using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Activation : MonoBehaviour
{

    public bool started;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            started = true;
        }
    }

}
