using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //encontra objeto com a tage player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = new Vector3(player.position.x, 1f, -1f);
        transform.position = startPosition;
    }
}
