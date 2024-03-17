using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HurtScreen : MonoBehaviour
{
    public Animator deadScreen;

    float health;
    public Health playerHealth;

    PostProcessVolume volume;
    Vignette vignette;

    //her saniye ger�ekle�mesini engellemek ama�l�
    bool alreadyWorking = false;

    float hurtEffectIntensity;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();

        volume.profile.TryGetSettings<Vignette>(out vignette);

        if (!vignette)
            print("error, vignette empty");
        else
            vignette.enabled.Override(false);

    }

    private void Update()
    {
        health = playerHealth.currentHealth;

        if (health > 0 && health < 100)
        {
            //her saniye iyile�me
            health += Time.deltaTime;

            //�l�m ekran� de�i�kenlerinin do�uldu�unda s�f�rlanmas�
            deadScreen.SetBool("isDead", false);
        }

        //Can 80'in alt�ndaysa yaralanma efektine ba�lama �art�
        if (health >= 80)
        {
            vignette.enabled.Override(false);
            ResetHurtEffect();
        }
        else if (health > 0 && health < 80)
        {
            //Kalan cana ba�l� olarak yaralanma efektini ayarlayan de�i�ken
            hurtEffectIntensity = ((100 - health) / 100 / 1.4f);

            StartCoroutine(HurtEffect(hurtEffectIntensity));
        }
        else if(health <= 0)
        {
            StartCoroutine(DieAndRecoverScreen());
        }

    }

    IEnumerator HurtEffect(float intensityValue)
    {

        if (!alreadyWorking)
        {

            alreadyWorking = true;

            float minIntensityValue = intensityValue - 0.1f;

            yield return new WaitForSeconds(0.5f);

            vignette.enabled.Override(true);
            vignette.intensity.Override(intensityValue);

            yield return new WaitForSeconds(0.1f);

            //Efektin pik noktas�ndan sonra s�f�ra inmeden belli bir seviyede kalmas� i�in d�ng�
            while (intensityValue > minIntensityValue)
            {
                intensityValue -= 0.01f;

                if (intensityValue < minIntensityValue)
                    intensityValue = minIntensityValue;

                vignette.intensity.Override(intensityValue);

                yield return new WaitForSeconds(0.02f);
            }
            
            Invoke(nameof(ResetHurtEffect), 0.2f);

        }

    }

    //her saniye ger�ekle�mesini engellemek ama�l�
    void ResetHurtEffect()
    {
        alreadyWorking = false;
    }

    IEnumerator DieAndRecoverScreen()
    {
        yield return new WaitForSeconds(0.02f);
        vignette.intensity.Override(1);
        deadScreen.SetBool("isDead", true);

        yield return new WaitForSeconds(2f);
        health = 98;

    }

}
