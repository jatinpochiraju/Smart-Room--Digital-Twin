using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    public Light[] pointLights;

    void Update()
    {
        if (pointLights.Length < 6) return;

        if (Keyboard.current.zKey.wasPressedThisFrame) ToggleLight(0);
        if (Keyboard.current.xKey.wasPressedThisFrame) ToggleLight(1);
        if (Keyboard.current.cKey.wasPressedThisFrame) ToggleLight(2);
        if (Keyboard.current.vKey.wasPressedThisFrame) ToggleLight(3);
        if (Keyboard.current.bKey.wasPressedThisFrame) ToggleLight(4);
        if (Keyboard.current.nKey.wasPressedThisFrame) ToggleLight(5);
    }

    void ToggleLight(int index)
    {
        if (pointLights[index] != null)
        {
            pointLights[index].enabled = !pointLights[index].enabled;
        }
    }
}
