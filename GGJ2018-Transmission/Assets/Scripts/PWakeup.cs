using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWakeup : MonoBehaviour {
    public Animator anim;
    public AnimationClip clip;
    public SpriteRenderer sr;
    public GameObject playable;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        sr = playable.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(WakeUp());	
        
	}

    IEnumerator WakeUp()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("WakeUp", true);

        yield return new WaitForSeconds(clip.length);
        sr.enabled = true;
        Destroy(this.gameObject);
    }
}
