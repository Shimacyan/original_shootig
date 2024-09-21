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

    public bool isTimerRunning = true;

    public GameObject heart1;
    public GameObject heart2;

    private static bool heart1bool = true;
    private static bool heart2bool = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            time -= Time.deltaTime;
            Timer.text = "Time: " + time.ToString("F1");
            if (time <= 0)
            {
                currentStage++;
                string nextSceneName = currentStage.ToString();
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

            if (heart1bool == false)
            {
                heart1.SetActive(false);
            }

            if (heart2bool == false)
            {
                heart2.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            if (heart1.activeSelf)
            {
                heart1.SetActive(false);
                heart1bool = false;
            }
            else if (heart2.activeSelf)
            {
                heart2.SetActive(false);
                heart2bool = false;
                gameOverUI.SetActive(true);
                isTimerRunning = false;
            }
        }


    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");


    }
}