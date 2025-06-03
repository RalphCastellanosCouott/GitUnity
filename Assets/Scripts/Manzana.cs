using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    [Header("Movimiento de las manzanas")]
    public float rotationSpeed = 45f;

    [Header("Lista de manzanas en escena")]
    public List<Transform> apples = new List<Transform>();
    private Dictionary<Transform, Vector3> posicionesIniciales = new Dictionary<Transform, Vector3>();
    private Vidas sistemaVidas;
    void Start()
    {
        sistemaVidas = FindAnyObjectByType<Vidas>();
        foreach (var apple in apples)
        {
            if (apple == null) continue;
            posicionesIniciales[apple] = apple.position;
            Collider col = apple.GetComponent<Collider>();
            if (col == null) col = apple.gameObject.AddComponent<BoxCollider>();
            col.isTrigger = true;

            if (apple.GetComponent<PlayerCollect>() == null)
            {
                apple.gameObject.AddComponent<PlayerCollect>().Init(this);
            }
        }
    }


    void Update()
    {
        foreach (var apple in apples)
        {
            if (apple == null) continue;
            apple.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Collect(Transform apple)
    {
        if (!apples.Contains(apple)) return;
        apples.Remove(apple);
        Debug.Log("Manzana recolectada");
        if (sistemaVidas != null && sistemaVidas.CurrentLives < sistemaVidas.MaxLives)
        {
            sistemaVidas.GanarVida();
            Debug.Log("Vida recuperada por manzana");
        }
        Destroy(apple.gameObject);
    }
}