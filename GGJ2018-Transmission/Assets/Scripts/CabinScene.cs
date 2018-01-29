using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinScene : MonoBehaviour {
    public AnimationClip Walk, Pickup, Die;
    public GameObject pickupModel, deathModel;
        // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Cabin());
	}
 
    IEnumerator Cabin()
    {
        yield return new WaitForSeconds(Walk.length);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        pickupModel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Manager.i._7.SetActive(true);
        yield return new WaitForSeconds(10);
        Manager.i._7.SetActive(false);
        Manager.i._7.transform.position = new Vector2(999, 999);
        pickupModel.SetActive(false);
        pickupModel.transform.position = new Vector2(999, 999);
        deathModel.SetActive(true);
        yield return new WaitForSeconds(Die.length);
        Manager.i._8.SetActive(true);
        yield return new WaitForSeconds(10);
        Application.Quit();



    }
}
