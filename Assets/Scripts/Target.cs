using UnityEngine;

public class Target : MonoBehaviour
{
    public int puntosQueOtorga = 10; // Cambia esto en el inspector para diferentes dianas

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            GameManager.Instance.AgregarPuntaje(puntosQueOtorga);
            Destroy(gameObject, 3); // Destruye el objetivo al ser impactado
        }
    }
}