using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    bool isWalkingRight = true;
    [SerializeField] float downWalk;
    float timer;
    [SerializeField] float miniTimer, maxTimer;
    [SerializeField] GameObject projectile;
    [SerializeField] float spawnPosition;
    bool hasBeenShooted;
    AlienContainer container;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        container = GetComponentInParent<AlienContainer>();
        container.currentAlienAmount++;
    }

    void Update()
    {
        if (isWalkingRight)
        {
            rb.AddForceX(speed);
        }
        else
        {
            rb.AddForceX(-speed);
        }
        if (timer >= Random.Range(miniTimer, maxTimer))
        {
            timer = 0;
            if (Random.Range(0f, 1f) < 0.2f)
            {
                Instantiate(projectile, new Vector2(transform.position.x, transform.position.y
                    - spawnPosition), Quaternion.identity, transform);
            }
        }
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile" && !hasBeenShooted)
        {
            hasBeenShooted = true;
            container.currentAlienAmount--;
            Destroy(gameObject);
        }
        if (collision.tag == "DeathZone")
        {
            container.isAlienWinning = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "rightWall")
        {
            isWalkingRight = false;
            transform.position = new Vector3(transform.position.x, transform.position.y
                - downWalk, 0);
        }
        if (collision.collider.tag == "leftWall")
        {
            isWalkingRight = true;
            transform.position = new Vector3(transform.position.x, transform.position.y
                - downWalk, 0);
        }
    }
}
