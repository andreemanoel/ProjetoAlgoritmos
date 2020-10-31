using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    private int score;

    private SpriteRenderer sprite;
    private CircleCollider2D circle;
    private AudioSource audio;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            audio.Play();
            sprite.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            score ++;
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            //pegando o propio objeto que esta com esse script e destruindo em 1 segundo
            Destroy(gameObject, 0.6f);
        }
    }
}
