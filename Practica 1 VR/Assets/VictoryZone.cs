using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    public GameObject victoryPanel; // Panel de victoria
    public Button restartButton;    // Botón de reinicio

    private void Start()
    {
        // Asegúrate de que el panel de victoria esté oculto al comenzar
        victoryPanel.SetActive(false);

        // Asigna la función RestartGame al botón
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el panel de victoria
            victoryPanel.SetActive(true);

            // Detiene el tiempo
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        // Restablece el tiempo a su velocidad normal
        Time.timeScale = 1f;

        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
