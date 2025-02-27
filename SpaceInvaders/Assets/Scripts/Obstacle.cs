using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int health;

    void Update()
    {
        Death();
    }

    private void Death()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyProjectile" || collision.tag == "PlayerProjectile")
        {
            health--;
        }
    }
}