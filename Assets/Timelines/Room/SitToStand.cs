using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitToStand : MonoBehaviour
{

    public Animator sitToStand;

    private void Update()
    {
        sitToStand.SetBool("standUp", true);
    }
}
