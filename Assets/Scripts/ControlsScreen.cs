using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour {

	public void ReturnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
