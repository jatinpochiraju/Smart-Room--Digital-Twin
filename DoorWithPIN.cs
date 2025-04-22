using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DoorWithPIN : MonoBehaviour
{
    public GameObject pinPanel;
    public InputField pinInput;
    public Text messageText;

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public float rotationAngle = 90f;
    public float openSpeed = 2f;
    private string correctPIN = "4256";

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
        pinPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor at the start
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && !pinPanel.activeSelf)
        {
            OpenPINPanel();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, isOpen ? openRotation : closedRotation, Time.deltaTime * openSpeed);
    }

    // Function to Open PIN Panel and Unlock Cursor
    void OpenPINPanel()
    {
        pinPanel.SetActive(true);
        pinInput.text = "";
        messageText.text = "";

        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true;
    }

    // Function to Close PIN Panel and Lock Cursor
    void ClosePINPanel()
    {
        pinPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor again
        Cursor.visible = false;
    }

    // Check PIN when "Enter" button is clicked
    public void CheckPIN()
    {
        if (pinInput.text == correctPIN)
        {
            isOpen = !isOpen;
            ClosePINPanel(); // Hide UI and lock cursor again
        }
        else
        {
            messageText.text = "Incorrect PIN! Access Denied.";
        }
    }

    // Clear input when "Clear" button is clicked
    public void ClearInput()
    {
        pinInput.text = "";
        messageText.text = "";
    }
}
