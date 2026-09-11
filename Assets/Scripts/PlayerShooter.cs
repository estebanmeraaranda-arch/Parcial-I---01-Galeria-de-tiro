using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoDeDisparo;
    public float fuerzaDisparo = 20f;

    void Update()
    {
        bool firePressed = false;
        if (UnityEngine.InputSystem.Mouse.current != null)
        {
            firePressed = UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame;
        }

        if (firePressed && GameManager.Instance.PuedeDisparar())
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameManager.Instance.Disparar();
        GameObject proyectil = Instantiate(prefabProyectil, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.linearVelocity = puntoDeDisparo.forward * fuerzaDisparo;
        }
    }
}