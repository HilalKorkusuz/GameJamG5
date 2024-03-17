using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaCıkarma : MonoBehaviour
{
    [SerializeField] GameObject notaCıkacakNokta;
    [SerializeField] GameObject oluşacakObje;


    void Update()
    {
        objeOluştur();
    }
    void objeOluştur()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(oluşacakObje, notaCıkacakNokta.transform.position, notaCıkacakNokta.transform.rotation);
            // animasyon.play();

        }
    }

}
