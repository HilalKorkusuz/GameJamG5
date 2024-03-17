using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenControl : MonoBehaviour
{

    public Animator pauseScreen;

    int pausedTime = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausedTime++;

            if (pausedTime % 2 != 0)
            {
                pauseScreen.SetBool("paused", true);
                Time.timeScale = 0.2f;
            }
            else
            {
                pauseScreen.SetBool("paused", false);
                Time.timeScale = 1f;
            }


        }

    }

}
