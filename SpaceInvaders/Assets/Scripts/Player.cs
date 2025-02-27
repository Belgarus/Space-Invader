using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpawnPosition;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private AudioSource shootAudio;

    private Rigidbody2D rb;
    public bool isDeath;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = $"{health}/3";
    }

    void Update()
    {
        //right
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForceX(speed, ForceMode2D.Force);
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceX(-speed, ForceMode2D.Force);
        }

        //shoot
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + projectileSpawnPosition),Quaternion.identity ,this.transform);
            shootAudio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        healthText.text = $"{health}/3";
        if (health <= 0)
        {
            health = 0;
            isDeath = true;
        }
    }
}