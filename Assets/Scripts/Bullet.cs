using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public GameObject bloodEffect;  // Efecto de sangre al disparar a un enemigo
    public GameObject dustEffect;   // Efecto de polvo al disparar a paredes o suelo
    public AudioClip fleshSound, wallSound, groundSound; // Sonidos de impacto
    public AudioSource audioSource; // Fuente de audio

    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 3f); // Destruir la bala después de 3 segundos
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Llamar a la función de daño del enemigo
            other.GetComponent<EnemyAI>()?.TakeDamage();

            // Instanciar efecto de sangre
            if (bloodEffect != null)
                Instantiate(bloodEffect, transform.position, Quaternion.identity);

            // Reproducir sonido de impacto en carne
            if (audioSource != null && fleshSound != null)
                audioSource.PlayOneShot(fleshSound);
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Ground"))
        {
            // Instanciar efecto de polvo
            if (dustEffect != null)
                Instantiate(dustEffect, transform.position, Quaternion.identity);

            // Reproducir sonido de impacto en pared o suelo
            if (audioSource != null)
            {
                if (other.CompareTag("Wall") && wallSound != null)
                    audioSource.PlayOneShot(wallSound);
                else if (other.CompareTag("Ground") && groundSound != null)
                    audioSource.PlayOneShot(groundSound);
            }
        }

        // Destruir la bala después del impacto
        Destroy(gameObject);
    }
}

