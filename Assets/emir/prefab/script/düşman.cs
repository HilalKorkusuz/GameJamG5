using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class düşman : MonoBehaviour
{
    public Slider slider;
    float health=100f;
    float darbeGücü = 20f;
    public GameObject tuşPanel;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        darbeAl();
    }
    void darbeAl()
    {
        health -= darbeGücü;    
        if (health <= 25f)
        {
            tuşPanel.SetActive(true);

        }
    }
}

