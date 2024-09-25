using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour // static を削除
{
    private static MusicController instance; // シングルトンインスタンス

    void Awake()
    {
        // 既にインスタンスが存在する場合は、自身を破棄
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを自身に設定し、シーン遷移後も保持
        instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}