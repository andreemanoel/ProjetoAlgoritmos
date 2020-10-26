using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float speed = 1;
    private float mov = 1;

    private SpriteRenderer sprite;
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 movimento = new Vector3(mov, 0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            mov = mov *-1;
            Move();
            Flip();
        }
    }
    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
