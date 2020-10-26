using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float plataformaTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        //8 é o numero da layer ground
        if(collision.gameObject.tag == "Player")
        {
            //Quando o player encostar na plataforma o metodo Plataform é chamado em x segudndos
            Invoke("Plataform", plataformaTime);
        }
    }

    //Se bater em algum objeto que tenha trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
            {
                Destroy(gameObject);
            }
    }
    
    void Plataform()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }
}
