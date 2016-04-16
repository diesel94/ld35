using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void OnPlay()
    {
        SceneManager.LoadScene("game");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
