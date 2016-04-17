using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    private Text timeCounter;

	void Awake()
    {
        timeCounter = GetComponent<Text>();
    }

    void Start()
    {
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        float time = 0.0f;
        while (time < GameManager.instance.startPauseTime-0.25f)
        {
            time += Time.deltaTime;
            timeCounter.text = ((int)(GameManager.instance.startPauseTime - time) + 1).ToString();
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
