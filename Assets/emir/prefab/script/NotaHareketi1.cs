using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaHareketi1 : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite varsay�lanButon;
    public Sprite bas�l�ncaButton;

    public KeyCode tu�aBas;
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(tu�aBas))
        {
            sr.sprite = varsay�lanButon;
        }
        if(Input.GetKeyUp(tu�aBas))
        {
            sr.sprite = bas�l�ncaButton;
        }
    }
}
