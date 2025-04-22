using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class FanController : MonoBehaviour
{
    public GameObject fanPlank1; // Drag the plank object for Fan 1
    public GameObject fanPlank2; // Drag the plank object for Fan 2

    private string apiKey = "thinkv_b671c992-ae8d-4638-bd26-c3f192a21128";
    private string channelId = "7492d60f-724f-4843-822d-4d49e42d1388";
    private string updateUrlBase = "https://api.thinkv.space/update";

    private int[] fanStates = new int[2]; // 0: Fan1, 1: Fan2

    void Start()
    {
        fanStates[0] = 0;
        fanStates[1] = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            fanStates[0] = 1 - fanStates[0];
            StartCoroutine(SendFanState());
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            fanStates[1] = 1 - fanStates[1];
            StartCoroutine(SendFanState());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            fanStates[0] = 1;
            fanStates[1] = 1;
            StartCoroutine(SendFanState());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            fanStates[0] = 0;
            fanStates[1] = 0;
            StartCoroutine(SendFanState());
        }

        // Rotate plank if fan is ON
        if (fanStates[0] == 1 && fanPlank1 != null)
        {
            fanPlank1.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
        if (fanStates[1] == 1 && fanPlank2 != null)
        {
            fanPlank2.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
    }

    IEnumerator SendFanState()
    {
        string field1 = $"{fanStates[0]}{fanStates[1]}";
        string url = $"{updateUrlBase}?channel_id={channelId}&api_key={apiKey}&field1={field1}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"✅ Fans updated: field1 = {field1}");
        }
        else
        {
            Debug.LogError("❌ Fan update failed: " + request.error);
        }
    }
}
