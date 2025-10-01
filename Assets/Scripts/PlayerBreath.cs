using UnityEngine;

public class PlayerBreath : MonoBehaviour
{
    // Inspector'dan nefes efektimizi bu alana sürükleyeceğiz
    public ParticleSystem nefesEfekti;

    private void OnTriggerEnter(Collider other)
    {
        // Girdiği alanın etiketi "SogukBolge" mi?
        if (other.CompareTag("SogukBolge"))
        {
            // GameManager'a sıcaklık kanıtının bulunduğunu haber ver.
            FindFirstObjectByType<GameManager>().KanitBulundu_Sicaklik();

            // Efekti oynat.
            Debug.Log("Soguk bir bolgeye girildi. Nefes efekti oynatiliyor.");
            nefesEfekti.Play(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Çıktığı alanın etiketi "SogukBolge" mi?
        if (other.CompareTag("SogukBolge"))
        {
            // Efekti durdur.
            Debug.Log("Soguk bolgeden cikildi. Nefes efekti durduruluyor.");
            nefesEfekti.Stop(); 
        }
    }
}