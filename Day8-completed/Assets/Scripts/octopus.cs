using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class octopus : MonoBehaviour
{
    public Transform groundPos;
    public float speed;
    public float rad;
    public LayerMask groundLayer;
    int healthocto = 5;
    public Collider2D Bullet;
  

    Collider2D enemycol;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemycol = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();

        deathOcto();
    }

    void EnemyPatrol()
    {
        rb.velocity = new Vector2(speed, 0f);

        bool isGrounded = Physics2D.OverlapCircle(groundPos.position, rad, groundLayer);
        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }

    void deathOcto()
    {
        Bullet = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>();
        if(enemycol.IsTouching(Bullet))
        {
            healthocto -= 5;
            Destroy(Bullet.gameObject);
        }
        
        if(healthocto <= 0)
        {
            Destroy(gameObject);
        }
    }
}
