using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{
    [Header("Configuración plataforma arriba abajo")]
    [Tooltip("Altura mínima de la plataforma en unds del mundo")]
    [SerializeField] private float minHeight = 0f;
    [Tooltip("Altura máxima de la plataforma en unds del mundo")]
    [SerializeField] private float maxHeight = 0f;
    [Tooltip("Velocidad de movimiento en unds / s")]
    [SerializeField] private float speed = 1f;
    private bool movingUp = true;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        float currentHeight = transform.position.y;
        Vector3 movement = movingUp ? Vector3.up : Vector3.down;
        movement *= speed * Time.deltaTime;
        transform.Translate(movement);
        float maxY = initialPosition.y + maxHeight;
        float minY = initialPosition.y + minHeight;

        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(
                transform.position.x,
                maxY,
                transform.position.z);
            movingUp = false;
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(
                transform.position.x,
                minY,
                transform.position.z);
            movingUp = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}