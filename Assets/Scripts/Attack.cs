using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    public float firlatmaGucu = 0.5f;
    [SerializeField] GameObject notaCikacakNokta;
    [SerializeField] GameObject olusacakObje;
    [SerializeField] GameObject gitaryeri;
    public AudioSource playerAttackVoice;

    bool alreadyAttacked = false;

    Animator animator;

    CharacterController characterController;

    public Vector3 checkpointPos;

    void Start()
    {
        gitaryeri.SetActive(false);
        animator = GetComponent<Animator>();

        characterController = GetComponent<CharacterController>();

        checkpointPos = this.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Firlat();
        }
    }

    void Firlat()
    {
        if (!alreadyAttacked)
        {
            gitaryeri.SetActive(true);
            characterController.Move(Vector3.zero);

            playerAttackVoice.Play();
            animator.SetTrigger("attack");
            alreadyAttacked = true;
            Vector3 firlatmaYonu = transform.forward;
            GameObject yeniObje = Instantiate(olusacakObje, notaCikacakNokta.transform.position, notaCikacakNokta.transform.rotation);
            Rigidbody rb1 = yeniObje.GetComponent<Rigidbody>();
            rb1.AddForce(firlatmaYonu * firlatmaGucu, ForceMode.Impulse);
            Destroy(yeniObje, 4f);

            Invoke(nameof(resetAttack), 0.4f);
        }
    }

    void resetAttack()
    {
        alreadyAttacked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPos = other.transform.position;
        }
    }



}
