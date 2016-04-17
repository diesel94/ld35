using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menuRoot;
    public GameObject controlsRoot;

    void Awake()
    {
        ShowMenu();   
    }

	public void OnPlay()
    {
        SceneManager.LoadScene("game");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnControls()
    {
        ShowControls();
    }

    public void OnReturnToMenu()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        menuRoot.SetActive(true);
        controlsRoot.SetActive(false);
    }

    private void ShowControls()
    {
        menuRoot.SetActive(false);
        controlsRoot.SetActive(true);
    }
}
