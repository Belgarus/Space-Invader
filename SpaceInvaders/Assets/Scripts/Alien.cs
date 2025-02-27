using System.Threading;
using UnityEngine;

public class Alien : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float downWalk;

    [SerializeField] private float maxTimer;
    [SerializeField] private float minTimer;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpawnPosition;

    [SerializeField] private HighScoreData highscore;
    [SerializeField] private int scorePoints;

    private AlienSpawner alienSpawner;
    private float timer;
    private bool hasBeenShooted;
    private Rigidbody2D rb;
    private bool isWalkingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alienSpawner = GetComponentInParent<AlienSpawner>();
        alienSpawner.currentAliens++;
    }

    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        if(Time.timeScale != 0)
        {
            if (isWalkingRight)
            {
                rb.AddForceX(speed, ForceMode2D.Force);
            }

            if (isWalkingRight == false)
            {
                rb.AddForceX(-speed, ForceMode2D.Force);
            }
        }
    }

    private void Shoot()
    {
        if (timer >= Random.Range(minTimer, maxTimer))
        {
            timer = 0;
            if (Random.Range(0f,1f) < 0.2f)
            {
                Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - projectileSpawnPosition), Quaternion.identity, this.transform);
            }
        }

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerProjectile" &&!hasBeenShooted)
        {
            hasBeenShooted = true;
            alienSpawner.currentAliens--;
            highscore.currentScore += scorePoints;
            Destroy(gameObject);
        }

        if (collision.tag == "DeathZone")
        {
            alienSpawner.isAlienWinning = true; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.tag == "rightWall")
        {
            isWalkingRight = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - downWalk, 0);
        }

        if (collision.collider.tag == "leftWall")
        {
            isWalkingRight = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - downWalk, 0);
        }
    }
}