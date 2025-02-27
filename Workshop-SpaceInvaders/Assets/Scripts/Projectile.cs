using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed; //automatisch private
    [SerializeField] string opponentName;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForceY(speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == opponentName || collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}