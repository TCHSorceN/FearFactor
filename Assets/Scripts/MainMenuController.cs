using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Inspector'dan Onay Panelimizi bu alana sürükleyeceğiz
    public GameObject cikisOnayPaneli;

    // "OYUNU BAŞLAT" butonu bu fonksiyonu çağıracak
    public void OyunuBaslat()
    {
        // "OyunSahnesi" adındaki sahneyi yükle.
        // DİKKAT: Buradaki "OyunSahnesi" ismi, senin kaydettiğin sahne dosyasıyla BİREBİR AYNI olmalı!
        SceneManager.LoadScene("OyunSahnesi");
    }

    // ANA "ÇIKIŞ" BUTONU BU FONKSİYONU ÇAĞIRACAK
    public void CikisButonunaBasildi()
    {
        // Onay panelini görünür yap
        cikisOnayPaneli.SetActive(true);
    }

    // ONAY PANELİNDEKİ "EVET" BUTONU BU FONKSİYONU ÇAĞIRACAK
    public void CikisiOnayla()
    {
        // Oyunu kapatır
        Debug.Log("Oyundan cikiliyor...");
        Application.Quit();
    }

    // ONAY PANELİNDEKİ "HAYIR" BUTONU BU FONKSİYONU ÇAĞIRACAK
    public void CikisiIptalEt()
    {
        // Onay panelini tekrar görünmez yap
        cikisOnayPaneli.SetActive(false);
    }
}