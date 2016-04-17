using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    public Text scoreText;
    public GameObject menu;
    public Image backgroundImage;
    public float fadeInTime = 1.0f;
    private bool fadeLock = false;

    void Start()
    {
        Hide();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.RestartGame();
        }
    }

	public void Show()
    {
        gameObject.SetActive(true);
        if (!fadeLock)
        {
            StartCoroutine(FadeInCoroutine());
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        fadeLock = true;

        Color bgColor = backgroundImage.color;
        float passedTime = 0.0f;
        while(passedTime < fadeInTime)
        {
            passedTime += Time.deltaTime;
            bgColor.a = Mathf.Lerp(0.0f, 1.0f, passedTime / fadeInTime);
            backgroundImage.color = bgColor;
            yield return new WaitForEndOfFrame();
        }
        bgColor.a = 255.0f;
        backgroundImage.color = bgColor;
        menu.SetActive(true);

        fadeLock = false;
    }

    private void Hide()
    {
        menu.SetActive(false);
        gameObject.SetActive(false);
        Color bgColor = backgroundImage.color;
        bgColor.a = 0.0f;
        backgroundImage.color = bgColor;
    }

    public void SetScoreText(int value)
    {
        scoreText.text = "score: " + value;
    }
}
