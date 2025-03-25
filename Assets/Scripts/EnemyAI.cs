using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public int health = 3;
    public float damage = 1f;
    private NavMeshAgent agent;
    private Renderer enemyRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage()
    {
        health--;
        UpdateColor();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateColor()
    {
        if (enemyRenderer != null)
        {
            switch (health)
            {
                case 3:
                    enemyRenderer.material.color = Color.green;
                    break;
                case 2:
                    enemyRenderer.material.color = Color.yellow;
                    break;
                case 1:
                    enemyRenderer.material.color = Color.red;
                    break;
            }
        }
    }
}
