using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Emmiter emiter;
    public GameOverScreen gameOverScreen;
    public Text scoreText;
    public System.Action OnLose;
    private int score;

    void Awake()
    {
        score = 0;
        instance = this;
    }

    void Start()
    {
        scoreText.text = "score: " + score;
    }

    public void Win(bool extraPoints)
    {
        score += extraPoints ? 5 : 1;
        scoreText.text = "score: " + score;
    }

    public void Lose()
    {
        emiter.isEmitingEnable = false;
        gameOverScreen.SetScoreText(score);
        gameOverScreen.Show();
        if(OnLose != null)
        {
            OnLose();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
