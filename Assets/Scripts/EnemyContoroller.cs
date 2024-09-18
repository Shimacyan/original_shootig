using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour
{
    // public GameObject enemy;
    Transform playerTr;
    float speed = 3f;

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }

}