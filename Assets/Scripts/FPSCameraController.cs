using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    public float mouseSensitivity = 100f;

    [Header("References")]
    public Transform playerBody;     // Drag your parent Player capsule/object here

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (UnityEngine.InputSystem.Mouse.current != null)
        {
            Vector2 mouseDelta = UnityEngine.InputSystem.Mouse.current.delta.ReadValue();
            mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
            mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;
        }

        // Look Up and Down (Rotates the Camera around the X axis)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping upside down

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Look Left and Right (Rotates the entire Player body around the Y axis)
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
