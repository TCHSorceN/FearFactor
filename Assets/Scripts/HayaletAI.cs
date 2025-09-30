using UnityEngine;

public class HayaletAI : MonoBehaviour
{
    // YENİ: Hayaletin olabileceği durumları tanımlıyoruz.
    public enum HayaletDurumu { Pasif, Avlanma }
    public HayaletDurumu suankiDurum;

    [Header("Genel Ayarlar")]
    public Transform[] devriyeNoktalari;
    public float hiz = 2.0f;
    public float guvenliSure = 120.0f;

    [Header("Paranormal Olay Ayarları")]
    public float etkilesimAlaniYaricapi = 7f;
    public float firlatmaGucu = 10f;
    public float olayTekrarlamaSuresi = 15f;

    [Header("Avlanma Ayarları")]
    public float avlanmaSuresi = 10f;          // Bir avlanmanın ne kadar süreceği (saniye).
    public float avlanmaAraligi = 60f;         // Avlanmalar arasında ne kadar bekleneceği (saniye).
    public float avlanmaHizi = 5f;             // Avlanırkenki hızı.

    private Transform oyuncu;
    private bool aktifMi = false;
    private int suankiNoktaIndex = 0;
    private float olayZamanlayici;
    private float avlanmaZamanlayici;           // YENİ: Bir sonraki ava ne kadar kaldığını sayar.
    private float mevcutAvlanmaSuresi;        // YENİ: Mevcut avın bitmesine ne kadar kaldığını sayar.
    private float normalHiz;                    // YENİ: Normal hızını kaydetmek için.

    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").transform;
        
        suankiDurum = HayaletDurumu.Pasif; // Oyuna Pasif modda başla.
        avlanmaZamanlayici = avlanmaAraligi; // İlk av için sayacı doldur.
        normalHiz = hiz; // Başlangıçtaki normal hızını kaydet.
    }

    void Update()
    {
        // Güvenli süre bitene kadar hiçbir şey yapma
        if (!aktifMi)
        {
            if (guvenliSure > 0) guvenliSure -= Time.deltaTime;
            else
            {
                guvenliSure = 0;
                aktifMi = true;
                if (devriyeNoktalari.Length > 0) transform.position = devriyeNoktalari[0].position;
            }
            return;
        }

        // Durum makinesi: Hayaletin mevcut durumuna göre farklı davranmasını sağla.
        switch (suankiDurum)
        {
            case HayaletDurumu.Pasif:
                ModPasif();
                break;
            case HayaletDurumu.Avlanma:
                ModAvlanma();
                break;
        }
    }

    // YENİ: Pasif durumdayken yapacağı her şey bu fonksiyonda
    void ModPasif()
    {
        hiz = normalHiz; // Hızını normale döndür.
        Patrol(); // Devriye gez.
        
        olayZamanlayici -= Time.deltaTime;
        if (olayZamanlayici <= 0 && Vector3.Distance(transform.position, oyuncu.position) < etkilesimAlaniYaricapi)
        {
            FirlatilacakObjeBulVeFirlat();
            olayZamanlayici = olayTekrarlamaSuresi;
        }

        // Bir sonraki av için geri sayım yap
        avlanmaZamanlayici -= Time.deltaTime;
        if (avlanmaZamanlayici <= 0)
        {
            // Av zamanı geldi!
            suankiDurum = HayaletDurumu.Avlanma;
            mevcutAvlanmaSuresi = avlanmaSuresi; // Av süresini başlat.
            Debug.Log("AVLANMA BAŞLADI!");
        }
    }

    // YENİ: Avlanma durumundayken yapacağı her şey bu fonksiyonda
    void ModAvlanma()
    {
        hiz = avlanmaHizi; // Hızını artır!

        // Oyuncuyu takip et!
        transform.position = Vector3.MoveTowards(transform.position, oyuncu.position, hiz * Time.deltaTime);

        // Av süresini azalt
        mevcutAvlanmaSuresi -= Time.deltaTime;
        if (mevcutAvlanmaSuresi <= 0)
        {
            // Av süresi bitti, pasif moda geri dön
            suankiDurum = HayaletDurumu.Pasif;
            avlanmaZamanlayici = avlanmaAraligi; // Bir sonraki av için sayacı tekrar doldur.
            Debug.Log("AVLANMA BİTTİ.");
        }
    }

    // Bu fonksiyonlar değişmedi
    void FirlatilacakObjeBulVeFirlat()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, etkilesimAlaniYaricapi);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Firlatilabilir"))
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 firlatmaYonu = (oyuncu.position - rb.transform.position).normalized + Vector3.up * 0.5f;
                    rb.AddForce(-firlatmaYonu * firlatmaGucu, ForceMode.Impulse);
                    return;
                }
            }
        }
    }

    void Patrol()
    {
        if (devriyeNoktalari.Length == 0) return;
        Transform hedefNokta = devriyeNoktalari[suankiNoktaIndex];
        transform.position = Vector3.MoveTowards(transform.position, hedefNokta.position, hiz * Time.deltaTime);
        if (Vector3.Distance(transform.position, hedefNokta.position) < 0.1f)
        {
            suankiNoktaIndex++;
            if (suankiNoktaIndex >= devriyeNoktalari.Length) suankiNoktaIndex = 0;
        }
    }
}