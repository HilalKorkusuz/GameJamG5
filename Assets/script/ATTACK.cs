using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACK : MonoBehaviour
{
    public float f�rlatmaG�c� = 10f;
    [SerializeField] GameObject notaC�kacakNokta;
    [SerializeField] GameObject olu�acakObje;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            F�rlat();
        }
    }

    void F�rlat()
    {
        Vector3 f�rlatmaY�n� = transform.forward;
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject yeniObje = Instantiate(olu�acakObje,notaC�kacakNokta.transform.position,notaC�kacakNokta.transform.rotation);
        rb = yeniObje.GetComponent<Rigidbody>();
        rb.AddForce(f�rlatmaY�n� * f�rlatmaG�c�, ForceMode.Impulse);
        Destroy(yeniObje, 2f);
    }

}
