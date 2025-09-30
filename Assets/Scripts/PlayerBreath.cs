using UnityEngine;

public class PlayerBreath : MonoBehaviour
{
    // Inspector'dan nefes efektimizi bu alana sürükleyeceğiz
    public ParticleSystem nefesEfekti;

    private void OnTriggerEnter(Collider other)
    {
        // Girdiği alanın etiketi "SogukBolge" mi?
        if (other.CompareTag("SogukBolge"))FindFirstObjectByType<GameManager>().KanitBulundu_Sicaklik();


        {
            // DEĞİŞTİ: Artık Play() komutunu kullanıyoruz. Bu, Burst'ü tetikler.
            Debug.Log("Soguk bir bolgeye girildi. Nefes efekti oynatiliyor.");
            nefesEfekti.Play(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Çıktığı alanın etiketi "SogukBolge" mi?
        if (other.CompareTag("SogukBolge"))
        {
            // DEĞİŞTİ: Artık Stop() komutunu kullanıyoruz. Bu, efekti durdurur.
            Debug.Log("Soguk bolgeden cikildi. Nefes efekti durduruluyor.");
            nefesEfekti.Stop(); 
        }
    }
}