using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public bool isJump;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    //Deu play no jogo, metodo start é chamado uma vez
    void Start()
    {
        //Pegar qualquer componente do rigidbody
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    //Deu play, o metodo update é chamado a cada frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float mov = Input.GetAxis("Horizontal");
        //movimenta só o eixo x, Horizontal nome padrao unity das teclas ;
        Vector3 movimento = new Vector3(mov, 0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;

        if((mov > 0f && sprite.flipX) || (mov < 0f && !sprite.flipX))
        {
            Flip();
            anim.SetBool("andar", true);
        }

        if(mov == 0f)
        {
            anim.SetBool("andar", false);
        }

    }
    void Jump()
    {
        //Jump é o espaço no padrão unity(Project Setting)
        if(Input.GetButtonDown("Jump") && isJump == false){
            anim.SetBool("pular", true);
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    //metodo da unity
    void OnCollisionEnter2D(Collision2D collision)
    {
        //8 é o numero da layer ground
        if(collision.gameObject.layer == 8)
        {
            isJump = false;
            anim.SetBool("pular", false);
        }
        if(collision.gameObject.tag == "spinho")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "inimigo")
        {
            GameController.instance.totalVidas --;
            GameController.instance.UpdateTextVidas();
            if((GameController.instance.totalVidas) == 0)
            {
                GameController.instance.ShowGameOver();
                Destroy(gameObject);
            }
        }
    }

    //Detecta qualquer colisao coom personagem
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "proxLvl")
            {
                GameController.instance.NextLvl();
                Destroy(gameObject);
            }
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }

    
}
