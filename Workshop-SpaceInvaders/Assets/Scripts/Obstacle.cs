using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int health;
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyProjectile" || collision.tag == "PlayerProjectile")
            health--;
    }
}