using UnityEngine;
using TMPro; // Asegúrate de importar TextMeshPro para la UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuraciones")]
    public int municionMaxima = 15; // Según tu imagen, o 10 como dice el PDF
    private int municionActual;
    private int puntajeActual = 0;

    [Header("UI")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoMunicion;
    public GameObject panelFinJuego;
    public TextMeshProUGUI textoPuntajeFinal;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        municionActual = municionMaxima;
        ActualizarUI();
        panelFinJuego.SetActive(false);
    }

    public void AgregarPuntaje(int puntos)
    {
        puntajeActual += puntos;
        ActualizarUI();
    }

    public void Disparar()
    {
        if (municionActual > 0)
        {
            municionActual--;
            ActualizarUI();

            if (municionActual <= 0)
            {
                Invoke("FinalizarJuego", 2f); // Espera 2 seg para que el último proyectil impacte
            }
        }
    }

    public bool PuedeDisparar()
    {
        return municionActual > 0;
    }

    private void ActualizarUI()
    {
        textoPuntaje.text = puntajeActual.ToString();
        textoMunicion.text = municionActual.ToString();
    }

    private void FinalizarJuego()
    {
        panelFinJuego.SetActive(true);
        textoPuntajeFinal.text = "Puntaje Total: " + puntajeActual;
        Time.timeScale = 0f; // Pausa el juego
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true;
    }
}