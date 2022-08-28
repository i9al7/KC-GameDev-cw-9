using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool faceRight = true;
    public GameObject bulletprefab;
    GameObject bullet;
    public Transform laftSpwn;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && faceRight)
        {
            bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bullet, 2f);
        }

        if (Input.GetMouseButtonDown(0) && !faceRight)
        {
            bullet = Instantiate(bulletprefab, laftSpwn.position, laftSpwn.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bullet, 2f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
