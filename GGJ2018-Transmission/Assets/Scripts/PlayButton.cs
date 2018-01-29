using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject PlayLight;
    public Animator anim;
    public AudioClip Hover, Click;
    public AudioSource audS;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audS = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        PlayLight.SetActive(true);
        audS.PlayOneShot(Hover);
    }

    private void OnMouseExit()
    {
        PlayLight.SetActive(false);
    }

    IEnumerator PlayFunc()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(1);
    }


    public void PlayClick()
    {
        PlayLight.transform.position = new Vector2(transform.position.x, 10);
        anim.SetBool("Clicked", true);
        audS.PlayOneShot(Click);

        StartCoroutine(PlayFunc());
    }
}


