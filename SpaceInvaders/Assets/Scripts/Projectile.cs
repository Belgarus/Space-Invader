using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private string opponentName;
    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForceY(speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == opponentName || other.tag == "Obstacle")
        {
            if(animator != null)
            {
                animator.SetTrigger("Hit");
                rb.linearVelocityY = 0;
                Destroy(gameObject, 0.35f);
            }
            else
            {
                rb.linearVelocityY = 0;
                Destroy(gameObject);
            }
        }
    }
}