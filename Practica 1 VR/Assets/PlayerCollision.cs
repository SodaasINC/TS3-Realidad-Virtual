using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public GameObject losePanel; // Panel de derrota
    public Button restartButton; // Bot�n de reinicio

    private void Start()
    {
        // Aseg�rate de que el panel de derrota est� oculto al inicio
        losePanel.SetActive(false);

        // Asigna la funci�n RestartGame al bot�n
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Activa el panel de derrota
            losePanel.SetActive(true);

            // Detiene el tiempo para que el juego se pause
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        // Restablece el tiempo a la velocidad normal antes de reiniciar la escena
        Time.timeScale = 1f;

        // Opcional: A�adir un peque�o retraso antes de recargar la escena
        // Esto da tiempo a que cualquier estado pausado o de reinicio se libere adecuadamente
        StartCoroutine(ReloadSceneWithDelay(0.1f));
    }

    private IEnumerator ReloadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Espera brevemente

        // Ahora recarga la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
