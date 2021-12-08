using UnityEngine;
using UnityEngine.SceneManagement;


public class HeartManager : MonoBehaviour
{

    // Insert your 3 hearts images in the Unity Editor
    [SerializeField] private GameObject h1, h2, h3;
    // Create an array because we're lazy
    private GameObject[] heart;

    public GameObject GameOver;
    // Gameover
    //  [SerializeField] private Image gameOver;
    // A private variable to keep between scenes
    public int Health;
    // Now we define Get / Set methods for health
    // In case we Set health to a different value we want to update UI
    void Awake()
    {
        heart = new GameObject[] { h1, h2, h3 };
        Health = 3;
        GameOver.SetActive(false);
        Time.timeScale = 1;

    }

    void Update()
    {
        if (Health == 0)
        {
            AudioController.AudioPause((int)AudioType.BGM);
            if (Input.GetKeyDown("space"))
            {
                PlayerPrefs.SetInt("High Score", GetComponent<PlayerMovement>().highScoreCounter);
                AudioController.AudioResume((int)AudioType.BGM);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void UpdateHealthUI()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            // Hide all images superior to the newHealth
            if (i >= Health)
                heart[i].SetActive(false);
            else
                heart[i].SetActive(true);
        }

        // Game Over
        if (Health == 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
}
