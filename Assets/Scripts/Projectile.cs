using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float tiempoDeVida = 5f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida); // Se destruye si no golpea nada
    }

    private void OnCollisionEnter(Collision collision)
    {
        // La lógica de puntaje la maneja el objetivo. Aquí solo nos destruimos.
        Destroy(gameObject);
    }
}