using UnityEngine;

public class EnemyContoroller : MonoBehaviour
{
    Transform playerTr;
    float speed = 3f;

    // PlayerController への参照を保持
    PlayerController playerController;

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        // PlayerController を取得
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        // PlayerController が存在し、タイマーが動いている場合のみ移動する
        if (playerController != null && playerController.isTimerRunning && Vector2.Distance(transform.position, playerTr.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
    }
}