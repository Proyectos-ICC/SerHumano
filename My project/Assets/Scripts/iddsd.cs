using UnityEngine;
using UnityEngine.SceneManagement;

public class iddsd : MonoBehaviour
{
    public bool nivelCompletado = true;
    private bool isPlayerInRange = false;
    private void Update()
    {
        if (isPlayerInRange) // Cambia esto a tu l�gica de desbloqueo deseada
        {
            CargarSiguienteNivel();
        }
    }

    public void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(13);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
