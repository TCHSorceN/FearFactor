using UnityEngine;
using UnityEngine.UI; // UI elemanlarını (Image gibi) kontrol etmek için bu gerekli.
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Kanıt Durumları")]
    public bool emfKanitiBulundu = false;
    public bool sicaklikKanitiBulundu = false;
    public bool yaziKanitiBulundu = false;

    [Header("Günlük UI Elemanları")]
    public GameObject gunlukPaneli;
    public Image emfOnayIsareti;
    public Image sicaklikOnayIsareti;
    public Image yaziOnayIsareti;

    private bool gunlukAcik = false;

    void Start()
    {
        // Oyun başında günlüğün kapalı olduğundan ve onay işaretlerinin görünmediğinden emin ol.
        gunlukPaneli.SetActive(false);
        emfOnayIsareti.enabled = false;
        sicaklikOnayIsareti.enabled = false;
        yaziOnayIsareti.enabled = false;
    }

    void Update()
    {
        // 'J' (Journal) tuşuna basıldığında günlüğü aç/kapat.
        if (Keyboard.current != null && Keyboard.current.jKey.wasPressedThisFrame)
        {
            gunlukAcik = !gunlukAcik;
            gunlukPaneli.SetActive(gunlukAcik);
        }
    }

    // Diğer script'ler bu fonksiyonları çağırarak kanıt bulduklarını bildirecek.
    public void KanitBulundu_EMF()
    {
        if (!emfKanitiBulundu)
        {
            emfKanitiBulundu = true;
            emfOnayIsareti.enabled = true;
            Debug.Log("KANIT BULUNDU: EMF Seviye 5");
        }
    }

    public void KanitBulundu_Sicaklik()
    {
        if (!sicaklikKanitiBulundu)
        {
            sicaklikKanitiBulundu = true;
            sicaklikOnayIsareti.enabled = true;
            Debug.Log("KANIT BULUNDU: Donma Sicakligi");
        }
    }

    public void KanitBulundu_Yazi()
    {
        if (!yaziKanitiBulundu)
        {
            yaziKanitiBulundu = true;
            yaziOnayIsareti.enabled = true;
            Debug.Log("KANIT BULUNDU: Hayalet Yazisi");
        }
    }
}