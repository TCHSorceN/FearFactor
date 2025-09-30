using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için bu satır şart!

public class PlayerStatus : MonoBehaviour
{
    public float yakalanmaMesafesi = 1.5f; // Hayalet bu mesafeye gelirse oyuncu yakalanır.
    
    private HayaletAI hayalet;

    [System.Obsolete]
    void Start()
    {
        // Sahnedeki HayaletAI script'ini bul ve referans al.
        hayalet = FindObjectOfType<HayaletAI>();
    }

    void Update()
    {
        // Eğer hayalet sahnede varsa...
        if (hayalet != null)
        {
            // ...VE hayalet "Avlanma" durumundaysa...
            if (hayalet.suankiDurum == HayaletAI.HayaletDurumu.Avlanma)
            {
                // ...oyuncu ile hayalet arasındaki mesafeyi kontrol et.
                float mesafe = Vector3.Distance(transform.position, hayalet.transform.position);

                // Eğer mesafe yakalanma mesafesinden daha azsa...
                if (mesafe < yakalanmaMesafesi)
                {
                    // ...YAKALANDIN!
                    Yakalandin();
                }
            }
        }
    }

    void Yakalandin()
    {
        Debug.Log("YAKALANDIN! Bolum yeniden baslatiliyor.");
        // Mevcut sahneyi yeniden yükle.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}