using UnityEngine;

public class LeftRightPlatfom : MonoBehaviour
{
    [Header("Configuracion de la plataforma")]
    [Tooltip("Altura mínima de la plataforma en unds del mundo")]
    [SerializeField] private float minWidth = 0f;
    [Tooltip("Altura máxima de la plataforma en unds del mundo")]
    [SerializeField] private float maxWidth = 0f;
    [Tooltip("Velocidad de movimiento en unds / s")]
    [SerializeField] private float speed = 1f;

    private bool movingLeft = true;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        float currentWidth = transform.position.x;
        Vector3 movement = movingLeft ? Vector3.left : Vector3.right;
        movement *= speed * Time.deltaTime;
        transform.Translate(movement);
        float maxX = initialPosition.x + maxWidth;
        float minX = initialPosition.x + minWidth;

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(
                maxX,
                transform.position.y,
                transform.position.z);
            movingLeft = true;
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(
                minX,
                transform.position.y,
                transform.position.z);
            movingLeft = false;
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