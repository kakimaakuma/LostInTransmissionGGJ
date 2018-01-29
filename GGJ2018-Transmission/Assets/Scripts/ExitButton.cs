using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    public GameObject ExitLight;
    public Animator anim;
    public AudioClip Hover, Click;
    public AudioSource audSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audSource = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        ExitLight.SetActive(true);
        audSource.PlayOneShot(Hover);
    }

    private void OnMouseExit()
    {
        ExitLight.SetActive(false);
    }

    IEnumerator ExitFunc()
    {
        yield return new WaitForSeconds(1.25f);
        Application.Quit();
    }

    public void ExitClick()
    {
        ExitLight.transform.position = new Vector2(transform.position.x, 10);
        anim.SetBool("Clicked", true);
        audSource.PlayOneShot(Click);

        StartCoroutine(ExitFunc());
    }
}
