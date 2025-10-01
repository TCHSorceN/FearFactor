using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    // Bu script'in eklendiği objenin üzerindeki Light bileşenini tutar
    Light _light;

    // Işığın titrerken inip çıkacağı minimum ve maksimum parlaklık değerleri
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;

    // Titremenin daha rastgele görünmesi için kullanılacak bir sayı
    float random;

    void Start()
    {
        _light = GetComponent<Light>();
        random = Random.Range(0.0f, 65535.0f);
    }

    void Update()
    {
        // PerlinNoise, yumuşak ve doğal görünen rastgele değerler üretir
        float noise = Mathf.PerlinNoise(random, Time.time * 2); // 2 ile çarparak titreme hızını artırabilirsin
        
        // Işığın parlaklığını, üretilen rastgele değere göre min ve max arasında ayarla
        _light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}