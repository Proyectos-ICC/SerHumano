using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador a seguir
    public Vector3 offset;   // Desplazamiento opcional para ajustar la posici�n de la c�mara

    void Update()
    {
        // Combinar la posici�n del objetivo (jugador) con el desplazamiento
        Vector3 targetPosition = target.position + offset;

        // Establecer la posici�n de la c�mara igual a la posici�n del objetivo
        transform.position = targetPosition;
    }
}
