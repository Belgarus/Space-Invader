using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb; //Rigidbody ist ein Kollisions check
    [SerializeField] private Projectile projectile;
    [SerializeField] private float spawnPosition;
    [SerializeField] int health;
    public bool isDead;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceX(speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceX(-speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, new Vector2(transform.position.x, //Vektor ist der Spawnpunkt
                transform.position.y + spawnPosition), Quaternion.identity, transform); //Quaternion ist die rotation
        }   //Erschaft einen identischen Klone
    }
}

/*
   Shoot - Methode
   health - Variable
   move - methode
   position x 
   variable speed
 */