using UnityEngine;
using DG.Tweening; // DOTween'i kullanmak için bu satır gerekli

public class SimpleDoor : MonoBehaviour
{
    // Inspector'dan kapının ne kadar sürede açılacağını ayarlarız
    public float openDuration = 1.0f;
    
    // Inspector'dan kapının kaç derece açılacağını ayarlarız
    public float acilmaAcisi = 90.0f; 

    private bool isOpen = false;
    private Vector3 closedRotation;
    private Vector3 openRotation;

    void Start()
    {
        // Oyun başladığında kapının kapalı haldeki YEREL açısını kaydet
        closedRotation = transform.localEulerAngles;
        
        // Açık halini, kapalı halinin üzerine acilmaAcisi ekleyerek HESAPLA
        openRotation = closedRotation + new Vector3(0, acilmaAcisi, 0);
    }

    public void Operate()
    {
        if (isOpen == false)
        {
            // Kapıyı YEREL koordinat sisteminde, hesapladığımız "açık" pozisyonuna döndür
            transform.DOLocalRotate(openRotation, openDuration);
            isOpen = true;
        }
        else
        {
            // Kapıyı YEREL koordinat sisteminde, kaydettiğimiz "kapalı" pozisyonuna geri döndür
            transform.DOLocalRotate(closedRotation, openDuration);
            isOpen = false;
        }
    }
}