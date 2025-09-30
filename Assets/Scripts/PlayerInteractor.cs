using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    // Ne kadar uzaktan etkileşime girebileceğimizi belirler
    public float interactionDistance = 3f;

    // Oyuncunun kamerasını referans alacağız
    public Camera playerCamera;

    // Ekranda yazı göstermek için (opsiyonel ama kodda kalsın)
    public TMPro.TextMeshProUGUI interactionText; 

    void Update()
    {
        if(playerCamera == null) return; // Kamera atanmadıysa hata vermemesi için kontrol

        // Kameranın tam ortasından ileriye doğru görünmez bir ışın oluştur
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Bu ışın belirlediğimiz mesafe içinde bir şeye çarparsa...
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Çarptığı şeyin bir Animator'u var mı diye kontrol et
            Animator animator = hit.collider.GetComponentInParent<Animator>();

            // Eğer bir Animator bulduysak...
            if (animator != null)
            {
                if(interactionText != null) interactionText.text = "Etkilesim icin [E]";

                // VE klavyeden E tuşuna bu frame basıldıysa...
                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    // Animator'deki "IsOpen" bool'unun mevcut durumunu al
                    bool currentState = animator.GetBool("IsOpen");
                    
                    // Bu durumu tersine çevir (true ise false, false ise true yap) ve Animator'e geri gönder
                    animator.SetBool("IsOpen", !currentState);
                }
            }
            else
            {
                 if(interactionText != null) interactionText.text = "";
            }
        }
        else
        {
            if(interactionText != null) interactionText.text = "";
        }
    }
}