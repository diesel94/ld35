using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Emmiter emiter;
    public GameObject gameOverUICanvas;
    public Text scoreText;
    public Text scoreTextGameOver;
    private int score;

    void Awake()
    {
        score = 0;
        instance = this;
        gameOverUICanvas.SetActive(false);
    }

    void Start()
    {
        scoreText.text = "score: " + score;
    }

    public void Win()
    {
        print("Win");
        ++score;
        scoreText.text = "score: " + score;
    }

    public void Lose()
    {
        print("Lose");
        emiter.isEmitingEnable = false;
        scoreTextGameOver.text = "score: " + score;
        gameOverUICanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
