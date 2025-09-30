using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public Light flashlightLight;
    private bool isFlashlightOn = true;

    void Start()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isFlashlightOn;
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isFlashlightOn;
        }
    }
}