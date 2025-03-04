using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // Vidas del enemigo
    private Renderer enemyRenderer; // Referencia al Renderer del enemigo

    private void Start()
    {
        enemyRenderer = GetComponent<Renderer>(); // Obtiene el Renderer para cambiar el color
        UpdateColor(); // Establece el color inicial
    }

    public void TakeDamage()
    {
        health--; // Resta una vida al enemigo
        UpdateColor(); // Cambia el color dependiendo de la vida restante

        if (health <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo si su vida llega a 0
        }
    }

    private void UpdateColor()
    {
        if (health == 3)
            enemyRenderer.material.color = Color.green; // Verde (3 vidas)
        else if (health == 2)
            enemyRenderer.material.color = Color.yellow; // Amarillo (2 vidas)
        else if (health == 1)
            enemyRenderer.material.color = Color.red; // Rojo (1 vida)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Si la bala impacta al enemigo
        {
            TakeDamage(); // Reducir vida del enemigo
            Destroy(collision.gameObject); // Destruir la bala al impactar
        }
    }
}
