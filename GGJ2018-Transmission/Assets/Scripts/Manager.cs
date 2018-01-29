using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public static Manager i;
    public GameObject _1, _2, _3, _4, _5, _6, _7, _8, BlueCar, MoldPile, Conti1, Conti2, Conti3;
    public GameObject Radio, Radio25, moldPickup, Radio4, Radio5;
    public GameObject idle;
    int levelLoad;
    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;
        i = this;
        levelLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
	
	// Update is called once per frame
	void Update () {	
	}

    public void PreviousLevel()
    {
        SceneManager.LoadScene(levelLoad);
        levelLoad++;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(levelLoad);
        levelLoad++;
    }
}
