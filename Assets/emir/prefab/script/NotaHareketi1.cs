using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaHareketi1 : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite varsayılanButon;
    public Sprite basılıncaButton;

    public KeyCode tuşaBas;
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(tuşaBas))
        {
            sr.sprite = varsayılanButon;
        }
        if(Input.GetKeyUp(tuşaBas))
        {
            sr.sprite = basılıncaButton;
        }
    }
}
