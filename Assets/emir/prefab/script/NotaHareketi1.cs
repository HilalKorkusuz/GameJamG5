using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaHareketi1 : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite varsayýlanButon;
    public Sprite basýlýncaButton;

    public KeyCode tuþaBas;
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(tuþaBas))
        {
            sr.sprite = varsayýlanButon;
        }
        if(Input.GetKeyUp(tuþaBas))
        {
            sr.sprite = basýlýncaButton;
        }
    }
}
