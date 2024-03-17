using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    Animator animator;
    NPCAI attackNPC;
    Attack attackPlayer;

    public GameObject outro;


    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        attackNPC = GetComponent<NPCAI>();
        attackPlayer = GetComponent<Attack>();
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hurt");

        currentHealth -= Mathf.Clamp(damage, 0, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        if (this.CompareTag("Enemy") || this.CompareTag("Boss"))
        {
            attackNPC.enabled = false;
        }

        if (this.CompareTag("Player"))
        {
            attackPlayer.enabled = false;
            StartCoroutine(Respawn());
        }

        if (this.CompareTag("Boss"))
        {
            attackNPC.enabled = false;
            outro.SetActive(true);
        }

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }







}