using UnityEngine;

public class GhostWritingBook : MonoBehaviour
{
    public GameObject karalamaObjesi;
    public float yazmaIhtimali = 25f;

    // YENİ: Hayaletin ne kadar yaklaşması gerektiğini buradan ayarlayacağız.
    public float tetiklenmeMesafesi = 2.0f; 

    private bool yaziYazildiMi = false;
    private Transform hayaletTransform; // YENİ: Hayaletin pozisyonunu saklamak için.

    void Start()
    {
        if (karalamaObjesi != null)
        {
            karalamaObjesi.SetActive(false);
        }

        // YENİ: Oyun başladığında "Hayalet" etiketli objeyi bul ve hafızaya al.
        GameObject hayaletObjesi = GameObject.FindGameObjectWithTag("Hayalet");
        if (hayaletObjesi != null)
        {
            hayaletTransform = hayaletObjesi.transform;
        }
        else
        {
            Debug.LogError("HATA: Sahnede 'Hayalet' etiketli bir obje bulunamadı!");
        }
    }

    // YENİ: OnTriggerEnter yerine artık Update kullanıyoruz.
    void Update()
    {
        // Eğer yazı zaten yazılmadıysa VE hayaleti bulduysak...
        if (!yaziYazildiMi && hayaletTransform != null)
        {
            // Defter ile hayalet arasındaki mesafeyi her frame hesapla.
            float mesafe = Vector3.Distance(transform.position, hayaletTransform.position);

            // Eğer mesafe, belirlediğimiz tetiklenme mesafesinden daha azsa...
            if (mesafe < tetiklenmeMesafesi)
            {
                // ...yazı yazma ihtimalini kontrol et.
                float rastgeleSayi = Random.Range(0f, 100f);
                if (rastgeleSayi < yazmaIhtimali)
                {
                    YaziYaz();
                }
            }
        }
    }

    void YaziYaz()
    {
        Debug.Log("KANIT BULUNDU: Hayalet Yazısı!");
        yaziYazildiMi = true; 
        
        if (karalamaObjesi != null)
        {
            karalamaObjesi.SetActive(true);
        }
    }
}