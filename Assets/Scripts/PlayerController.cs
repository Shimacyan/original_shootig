using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float playerSpeed = 8;
    public GameObject gameOverUI;
    public Text Timer;
    public float time = 10;

    private Rigidbody rb;

    public int currentStage = 1; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        Timer.text = "Time: " + time.ToString("F1");
        if (time <= 0)
        {
            currentStage++;
            string nextSceneName =  currentStage.ToString();
            SceneManager.LoadScene(nextSceneName);
        }


        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        rb.velocity = moveDirection * playerSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            gameOverUI.SetActive(true);
        }

    }
}
