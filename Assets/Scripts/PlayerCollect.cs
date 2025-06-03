using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private Manzana manzanaManager;
    private Banana bananaManager;

    public void Init(Manzana manager)
    {
        manzanaManager = manager;
    }

    public void Init(Banana manager)
    {
        bananaManager = manager;
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            Vidas vidasJugador = other.GetComponent<Vidas>();
            if (vidasJugador != null)
            {
                vidasJugador.ActivarFuerza();
            }
            if (manzanaManager != null)
            {
                manzanaManager.Collect(transform);
            }
            else if (bananaManager != null)
            {
                bananaManager.Collect(transform);
            }
        }
    }
}