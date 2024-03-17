using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACK : MonoBehaviour
{
    public float fýrlatmaGücü = 10f;
    [SerializeField] GameObject notaCýkacakNokta;
    [SerializeField] GameObject oluþacakObje;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fýrlat();
        }
    }

    void Fýrlat()
    {
        Vector3 fýrlatmaYönü = transform.forward;
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject yeniObje = Instantiate(oluþacakObje,notaCýkacakNokta.transform.position,notaCýkacakNokta.transform.rotation);
        rb = yeniObje.GetComponent<Rigidbody>();
        rb.AddForce(fýrlatmaYönü * fýrlatmaGücü, ForceMode.Impulse);
        Destroy(yeniObje, 2f);
    }

}
