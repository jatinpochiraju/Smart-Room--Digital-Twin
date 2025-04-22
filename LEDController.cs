using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class ThinkVButtonController : MonoBehaviour
{
    public Light[] pointLights;     // Assign 6 Point Lights
    public Button[] ledButtons;     // Assign 6 Buttons
    public GameObject canvasObject; // Assign your Canvas here in Inspector

    private string apiKey = "thinkv_b671c992-ae8d-4638-bd26-c3f192a21128";
    private string channelId = "7492d60f-724f-4843-822d-4d49e42d1388";
    private string updateUrlBase = "https://api.thinkv.space/update";

    void Start()
    {
        if (canvasObject != null)
            canvasObject.SetActive(false); // Start hidden

        for (int i = 0; i < 6; i++)
        {
            int index = i;
            pointLights[i].enabled = false;
            ledButtons[i].onClick.AddListener(() => ToggleLED(index));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canvasObject != null)
            {
                bool show = !canvasObject.activeSelf;
                canvasObject.SetActive(show);

                // Toggle cursor state
                Cursor.visible = show;
                Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }

    void ToggleLED(int i)
    {
        pointLights[i].enabled = !pointLights[i].enabled;
        StartCoroutine(UpdateThinkVField2());
    }

    IEnumerator UpdateThinkVField2()
    {
        string field2 = "";
        foreach (Light light in pointLights)
        {
            field2 += light.enabled ? "1" : "0";
        }

        string finalUrl = $"{updateUrlBase}?channel_id={channelId}&api_key={apiKey}&field2={field2}";
        UnityWebRequest request = UnityWebRequest.Get(finalUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log($"✅ Sent LED state to ThinkV: {field2}");
        else
            Debug.LogError("❌ Error sending to ThinkV: " + request.error);
    }
}
