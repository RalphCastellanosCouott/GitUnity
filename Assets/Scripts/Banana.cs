using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    [Header("Movimiento de las manzanas")]
    public float rotationSpeed = 45f;

    [Header("Lista de manzanas en escena")]
    public List<Transform> bananas = new List<Transform>();
    private Dictionary<Transform, Vector3> posicionesIniciales = new Dictionary<Transform, Vector3>();
    void Start()
    {
        foreach (var banana in bananas)
        {
            if (banana == null) continue;
            posicionesIniciales[banana] = banana.position;
            Collider col = banana.GetComponent<Collider>();
            if (col == null) col = banana.gameObject.AddComponent<BoxCollider>();
            col.isTrigger = true;

            if (banana.GetComponent<PlayerCollect>() == null)
            {
                banana.gameObject.AddComponent<PlayerCollect>().Init(this);
            }
        }
    }

    void Update()
    {
        foreach (var banana in bananas)
        {
            if (banana == null) continue;
            banana.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Collect(Transform banana)
    {
        if (!bananas.Contains(banana)) return;
        bananas.Remove(banana);
        Debug.Log("Banana recolectada");
        Destroy(banana.gameObject);
    }
}