using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okDüþüþ : MonoBehaviour
{
    public bool basýldý;
    public KeyCode tuþaBas;

    public GameObject hitEffect, GoodEffect, perfectEfekt;
   
    void Update()
    {
        if(Input.GetKeyDown(tuþaBas))
        {
            if(basýldý)
            {
                
                gameObject.SetActive(false);
                if (Mathf.Abs(transform.position.y) > .8f)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                   
                    Debug.Log("HÝT");                  
                }
                else if (Mathf.Abs(transform.position.y) > .7f) 
                {
                    Instantiate(GoodEffect, transform.position, GoodEffect.transform.rotation);
                   
                    Debug.Log("GOOD");
                }
                else if(Mathf.Abs(transform.position.y)>.5f)
                {
                    Instantiate(perfectEfekt,transform.position, perfectEfekt.transform.rotation);
                 
                    Debug.Log("PERFECT");

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag=="buton")
        {
            basýldý = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "buton")
        {
            
            basýldý = false;
            GameKontrol.instance.notaKaçtý();        

        }
    }
}
