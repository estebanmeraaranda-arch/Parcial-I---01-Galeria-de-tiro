using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensibilidadRaton = 200f;
    public Transform cuerpoJugador;
    private float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor en el centro
    }

    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (UnityEngine.InputSystem.Mouse.current != null)
        {
            Vector2 mouseDelta = UnityEngine.InputSystem.Mouse.current.delta.ReadValue();
            mouseX = mouseDelta.x * sensibilidadRaton * Time.deltaTime;
            mouseY = mouseDelta.y * sensibilidadRaton * Time.deltaTime;
        }

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Evita que la cámara dé vueltas completas

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        if (cuerpoJugador != null)
        {
            cuerpoJugador.Rotate(Vector3.up * mouseX);
        }
    }
}