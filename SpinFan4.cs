using UnityEngine;

public class SpinFan4 : MonoBehaviour
{
    public KeyCode spinKey = KeyCode.L;  // Change this to any key you want
    public float spinSpeed = 200f;  // Rotation speed
    private bool isSpinning = false;

    void Update()
    {
        // Toggle spinning when the key is pressed
        if (Input.GetKeyDown(spinKey))
        {
            isSpinning = !isSpinning;
        }

        // Rotate object if spinning is enabled
        if (isSpinning)
        {
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }
    }
}
