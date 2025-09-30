using UnityEngine;

public class GhostWritingBook : MonoBehaviour
{
    // Inspector'dan, defterin üzerine koyduğumuz karalama objesini buraya sürükleyeceğiz.
    public GameObject karalamaObjesi;
    
    // Hayalet bölgeye girdiğinde yazı yazma ihtimali (yüzde olarak, 0-100 arası).
    public float yazmaIhtimali = 25f;

    private bool yaziYazildiMi = false;

    void Start()
    {
        // Oyun başladığında karalamaların görünmez olduğundan emin ol.
        if (karalamaObjesi != null)
        {
            karalamaObjesi.SetActive(false);
        }
    }

    // Hayalet, defterin etrafındaki trigger alanına girdiğinde bu fonksiyon çalışır.
    private void OnTriggerEnter(Collider other)
    {
        // Eğer yazı zaten yazılmadıysa VE içeri giren hayaletse...
        if (!yaziYazildiMi && other.CompareTag("Hayalet")) // Hayaletin Tag'i "Hayalet" olmalı!
        {
            Debug.Log("Hayalet defterin yanina geldi, yazma ihtimali kontrol ediliyor...");

            // Rastgele bir sayı üret (0 ile 100 arasında).
            float rastgeleSayi = Random.Range(0f, 100f);

            // Eğer bu sayı, belirlediğimiz ihtimalden küçükse...
            if (rastgeleSayi < yazmaIhtimali)
            {
                // ...yazıyı yaz!
                YaziYaz();
            }
        }
    }

    void YaziYaz()
    {
        Debug.Log("KANIT BULUNDU: Hayalet Yazısı!");
        yaziYazildiMi = true; // Tekrar yazılmasını engelle.

        FindFirstObjectByType<GameManager>().KanitBulundu_Yazi();

        // Karalama objesini görünür yap.
        if (karalamaObjesi != null)
        {
            karalamaObjesi.SetActive(true);
        }
        
        // İleride buraya bir "kanıt bulundu" sesi ekleyebiliriz.
    }
}