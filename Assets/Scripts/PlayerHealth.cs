using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public Volume postProcessingVolume;
    private Vignette vignette;

    void Start()
    {
        if (postProcessingVolume != null)
            postProcessingVolume.profile.TryGet(out vignette);
    }

    public void TakeDamage(float amount)
    {
        health--;
        UpdateVignette();
        if (health <= 0)
        {
            RestartGame();
        }
    }

    void UpdateVignette()
    {
        if (vignette != null)
        {
            float intensity = 1f - ((float)health / 5f);
            vignette.intensity.Override(intensity);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
