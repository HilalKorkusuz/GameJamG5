using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameKontrol : MonoBehaviour
{
    // public AudioSource muzik;
    public bool startPlaying;
    public static GameKontrol instance;

    public GameObject[] notalar;
    public float notaOluþturmaSýklýðý = 2f;
    float sonOluþturmaZamaný = 0f;
    public GameObject[] oluþacakNokta;

    public GameObject aktifEdilecek1;
    public GameObject aktifEdilecek2;
    public GameObject kapanacakPanel;
    public GameObject karakter;
    ATTACK attack;
    void Start()
    {
        instance = this;
        sonOluþturmaZamaný = Time.time;
        attack = karakter.GetComponent<ATTACK>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                startRitim();
                kapanacakPanel.SetActive(false);
            }
        }
        if (startPlaying)
        {
            RandomNotaOluþtur();
        }

    }
    void startRitim()
    {
        startPlaying = true;
        aktifEdilecek1.SetActive(true);
        aktifEdilecek2.SetActive(true);
        karakter.GetComponent<ATTACK>().enabled = false;
    }
    public void notaKaçtý()
    {
        Debug.Log("nota kaçtý");
    }
    public void notayaBasýldý()
    {
        Debug.Log("notaya basýldý");

    }
    public void RandomNotaOluþtur()
    {
        if (Time.time > notaOluþturmaSýklýðý + sonOluþturmaZamaný)
        {
            int randomNotalarÝndex = Random.Range(0, notalar.Length);
            int oluþacakNoktaÝndex = Random.Range(0, oluþacakNokta.Length);
            Instantiate(notalar[oluþacakNoktaÝndex], oluþacakNokta[randomNotalarÝndex].transform.position, oluþacakNokta[randomNotalarÝndex].transform.rotation);
            sonOluþturmaZamaný = Time.time;
        }
    }
   

        // boss ölünce son darbede çalýþcak kýsým
        /*    public void finishRitim()
           {
               aktifEdilecek1.SetActive(false);
               aktifEdilecek2.SetActive(false);
               startPlaying = false;
               karakter.GetComponent<ATTACK>().enabled = true;
           }
        */

}

