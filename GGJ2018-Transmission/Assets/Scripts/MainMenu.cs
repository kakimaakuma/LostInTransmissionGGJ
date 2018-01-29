using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public GameObject PlayButton;
    public GameObject ExitButton;
    public GameObject RadioWave;

    public void PlayFunc()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitFunc()
    {
        Application.Quit();
    }
}
