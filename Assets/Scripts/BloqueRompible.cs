using UnityEngine;

public class BloqueRompible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vidas vidasJugador = other.GetComponent<Vidas>();
            if (vidasJugador != null && vidasJugador.TieneFuerza)
            {
                Destroy(gameObject);
            }
        }
    }
}