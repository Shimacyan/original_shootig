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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
         Timer.text = "Time: " + time.ToString("F1");
         if (time <= 0)
         {
            SceneManager.LoadScene("2");
         }


        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector2.up * playerSpeed * Time.deltaTime); 
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(-Vector2.up * playerSpeed * Time.deltaTime); 
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-
            Vector2.right * playerSpeed * Time.deltaTime);
        }
    }
        
        void OnCollisionEnter(Collision collision){
            if (collision.gameObject.tag == "Enemy")
            {
                gameOverUI.SetActive(true);
            }

        }
    }

