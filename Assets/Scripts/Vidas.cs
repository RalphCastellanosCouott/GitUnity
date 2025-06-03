using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    [Header("Vidas")]
    public int maxLives = 5;
    private int currentLives;
    public Transform respawnPoint;
    public TextMeshProUGUI livesText;

    [Header("Fuerza temporal")]
    public bool TieneFuerza { get; private set; } = false;
    public float duracionFuerza = 10f;

    public int CurrentLives => currentLives;
    public int MaxLives => maxLives;
    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
        if (respawnPoint == null) respawnPoint = this.transform;
    }

    void Update()
    {
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = $"{currentLives}/{maxLives}";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            PerderVida();
            if (currentLives > 0) transform.position = respawnPoint.position;
        }
    }

    public void GanarVida()
    {
        currentLives++;
        UpdateLivesUI();
    }

    public void PerderVida()
    {
        currentLives--;
        UpdateLivesUI();
        if (currentLives == 0)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
    
    public void ActivarFuerza()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(FuerzaTemporal());
    }

    private System.Collections.IEnumerator FuerzaTemporal()
    {
        TieneFuerza = true;
        Debug.Log("¡Fuerza activada!");
        yield return new WaitForSeconds(duracionFuerza);
        TieneFuerza = false;
        Debug.Log("Fuerza desactivada.");
    }
}