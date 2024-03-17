using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panel;
    public void OyunuBaslat()
    {
        SceneManager.LoadScene(1);
    }
    public void OyunuKapat()
    {
        Application.Quit();
    }
    public void Credits()
    {
            panel.SetActive(true);
    }
}
