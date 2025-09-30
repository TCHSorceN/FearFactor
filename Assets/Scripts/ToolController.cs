using UnityEngine;
using UnityEngine.InputSystem;

public class ToolController : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject kameraArayuzu; // Kameranın açık olduğunu gösteren UI
    
    private bool kameraModuAktif = false;
    private int hayaletKatmani;

    void Start()
    {
        // Script başladığında "HayaletObjeleri" katmanının sayısal değerini alıp sakla
        hayaletKatmani = LayerMask.NameToLayer("HayaletObjeleri");
        // Başlangıçta kamera arayüzünü kapat
        if (kameraArayuzu != null) kameraArayuzu.SetActive(false);
    }

    void Update()
    {
        // Eğer 'C' tuşuna basıldıysa...
        if (Keyboard.current != null && Keyboard.current.cKey.wasPressedThisFrame)
        {
            // Kamera modunu tersine çevir (açıksa kapat, kapalıysa aç)
            kameraModuAktif = !kameraModuAktif;

            if (kameraModuAktif)
            {
                // Kamera modunu AÇ
                // Kameranın görüş maskesine HayaletObjeleri katmanını ekle
                playerCamera.cullingMask |= (1 << hayaletKatmani);
                if (kameraArayuzu != null) kameraArayuzu.SetActive(true);
                Debug.Log("Kamera Modu ACILDI");
            }
            else
            {
                // Kamera modunu KAPAT
                // Kameranın görüş maskesinden HayaletObjeleri katmanını çıkar
                playerCamera.cullingMask &= ~(1 << hayaletKatmani);
                if (kameraArayuzu != null) kameraArayuzu.SetActive(false);
                Debug.Log("Kamera Modu KAPANDI");
            }
        }
    }
}