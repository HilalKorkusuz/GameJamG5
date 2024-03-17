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
    public float notaOlu�turmaS�kl��� = 2f;
    float sonOlu�turmaZaman� = 0f;
    public GameObject[] olu�acakNokta;

    public GameObject aktifEdilecek1;
    public GameObject aktifEdilecek2;
    public GameObject kapanacakPanel;
    public GameObject karakter;
    ATTACK attack;
    void Start()
    {
        instance = this;
        sonOlu�turmaZaman� = Time.time;
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
            RandomNotaOlu�tur();
        }

    }
    void startRitim()
    {
        startPlaying = true;
        aktifEdilecek1.SetActive(true);
        aktifEdilecek2.SetActive(true);
        karakter.GetComponent<ATTACK>().enabled = false;
    }
    public void notaKa�t�()
    {
        Debug.Log("nota ka�t�");
    }
    public void notayaBas�ld�()
    {
        Debug.Log("notaya bas�ld�");

    }
    public void RandomNotaOlu�tur()
    {
        if (Time.time > notaOlu�turmaS�kl��� + sonOlu�turmaZaman�)
        {
            int randomNotalar�ndex = Random.Range(0, notalar.Length);
            int olu�acakNokta�ndex = Random.Range(0, olu�acakNokta.Length);
            Instantiate(notalar[olu�acakNokta�ndex], olu�acakNokta[randomNotalar�ndex].transform.position, olu�acakNokta[randomNotalar�ndex].transform.rotation);
            sonOlu�turmaZaman� = Time.time;
        }
    }
   

        // boss �l�nce son darbede �al��cak k�s�m
        /*    public void finishRitim()
           {
               aktifEdilecek1.SetActive(false);
               aktifEdilecek2.SetActive(false);
               startPlaying = false;
               karakter.GetComponent<ATTACK>().enabled = true;
           }
        */

}

