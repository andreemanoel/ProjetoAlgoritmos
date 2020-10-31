using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float speed = 2f;

    private SpriteRenderer sprite;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "parede")
        {
            Flip();
            speed *= -1f;
        }
        if(collider.gameObject.tag == "bullet")
        {
            anim.SetTrigger("dead");
            speed = 0;
            Destroy(gameObject, 0.3f);
        }
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
