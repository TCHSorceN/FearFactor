using UnityEngine;
using TMPro;

public class EMFController : MonoBehaviour
{
    public TextMeshProUGUI emfText;
    private Transform hayalet;

    void Start()
    {
        GameObject hayaletObjesi = GameObject.FindGameObjectWithTag("Hayalet");
        if (hayaletObjesi != null)
        {
            hayalet = hayaletObjesi.transform;
        }
        else
        {
            Debug.LogError("SAHNEDE 'Hayalet' TAG'İNE SAHİP BİR OBJE BULUNAMADI!");
        }
    }

    void Update()
    {
        if (hayalet != null && emfText != null)
        {
            float mesafe = Vector3.Distance(transform.position, hayalet.position);
            int emfSeviyesi = 0;

            if (mesafe < 3)       { emfSeviyesi = 5; FindFirstObjectByType<GameManager>().KanitBulundu_EMF(); }
            else if (mesafe < 6)  { emfSeviyesi = 4; }
            else if (mesafe < 10) { emfSeviyesi = 3; }
            else if (mesafe < 15) { emfSeviyesi = 2; }
            else if (mesafe < 25) { emfSeviyesi = 1; }
            
            emfText.text = "EMF: " + emfSeviyesi;
        }
    }
}