using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaTuşları : MonoBehaviour
{
    public float notaHızı;
    public bool başladıMı;

    
    void Start()
    {
        notaHızı = notaHızı / 60f;
    }

   
    void Update()
    {
        if(!başladıMı)
        {
            if (Input.anyKeyDown)
            {
                başladıMı = true;
            }            
        }
        else
        {
            
            transform.position-= new Vector3(0f,notaHızı*Time.deltaTime,0f);
        }
    }

}
