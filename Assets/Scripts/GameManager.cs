using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }
    public Emmiter emiter;
    public GameOverScreen gameOverScreen;
    public Text scoreText;
    public System.Action OnLose;
    public float startPauseTime = 3.0f;
    public AudioClip loseGameClip;
    public AudioClip getPointClip;
    private AudioSource audioSource;
    private int score;

    void Awake()
    {
        score = 0;
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        scoreText.text = "score: " + score;
    }

    public void Win(bool extraPoints)
    {
        score += extraPoints ? 5 : 1;
        scoreText.text = "score: " + score;
        PlayGetPointClip();
    }

    public void Lose()
    {
        emiter.isEmitingEnable = false;
        PlayLoseClip();
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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    private void PlayLoseClip()
    {
        audioSource.clip = loseGameClip;
        audioSource.Play();
    }

    private void PlayGetPointClip()
    {
        audioSource.clip = getPointClip;
        audioSource.Play();
    }
}
