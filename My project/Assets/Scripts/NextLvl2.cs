using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl2 : MonoBehaviour
{
    public bool nivelCompletado = false;
    private bool isPlayerInRange = false;
    private void Update()
    {
        if (nivelCompletado && isPlayerInRange) // Cambia esto a tu l�gica de desbloqueo deseada
        {
            CargarSiguienteNivel();
        }
    }

    public void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(2);
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