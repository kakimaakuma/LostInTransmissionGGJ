using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public AnimationClip pAnim;
    public EnemyBehavior eb;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public GameObject clutter;
    public float maxSpeed = 7f;
    public float speedReduction = 1f;
    public bool isMoving, hit;
    public int thrust;
    public int currentLevel;


    // Use this for initialization
    void Start () {
        //clutter = GameObject.FindGameObjectWithTag("Clutter");
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(rb.velocity.x, -5f, 5f);

        if (sr.enabled == true)
        {
            //Walk Right
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * thrust);
                sr.flipX = false;
            }

            //Walk Left
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * thrust);
                sr.flipX = true;
            }

            //Anti Skid
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector2(0, this.rb.velocity.y);
            }
            if (rb.velocity.magnitude > 0)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
        if (sr.enabled == false)
        {
            rb.velocity = new Vector2(0, this.rb.velocity.y);
        }
    }

    //Enemyhit instance
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            hit = true;
        }
        if (collision.tag.Equals("Radio"))
        {
            sr.enabled = false;
            Manager.i.Radio.SetActive(true);
            StartCoroutine(Level1Radio());
        }

        if (collision.name.Equals("Radio2.5"))
        {
            sr.enabled = false;
            Manager.i.Radio25.SetActive(true);
            StartCoroutine(Level25Radio());
        }

        if (collision.tag.Equals("Clutter"))
        {
            Destroy(clutter.GetComponent<BoxCollider2D>());
            StartCoroutine(Level4Clutter());
        }

        if (collision.name.Equals("Radio4"))
        {
            sr.enabled = false;
            Manager.i.Radio4.SetActive(true);
            StartCoroutine(Level4Radio());
        }
        if (collision.name.Equals("Radio5"))
        {
            sr.enabled = false;
            Manager.i.Radio5.SetActive(true);
            StartCoroutine(Level5Radio());
        }
        if (collision.name.Equals("Cabin"))
        {
            NextLevel();
        }
        if (collision.name.Equals("Trans7"))
        {
            Manager.i._6.SetActive(false);
            Manager.i._7.SetActive(true);
        }
        if (collision.name.Equals("Trans8"))
        {
            Manager.i._7.SetActive(false);
            Manager.i._8.SetActive(true);
        }
        if (collision.name.Equals("BlueCar"))
        {

        }
        if (collision.name.Equals("NextLevel"))
        {
            NextLevel();
        }
    }



    IEnumerator Level1Radio()
    {

        yield return new WaitForSeconds(pAnim.length);
        Manager.i._1.SetActive(true);
        yield return new WaitForSeconds(5);
        Manager.i._1.SetActive(false);
        Manager.i._2.SetActive(true);
        yield return new WaitForSeconds(7);
        Manager.i._2.SetActive(false);
        Manager.i.Radio.SetActive(false);
        sr.enabled = true;
    }

    IEnumerator Level25Radio()
    {
        yield return new WaitForSeconds(pAnim.length);
        Manager.i._3.SetActive(true);
        yield return new WaitForSeconds(13);
        Manager.i._3.SetActive(false);
        Manager.i.Radio25.SetActive(false);
        sr.enabled = true;
    }

    IEnumerator Level4Clutter()
    {
        sr.enabled = false;
        Manager.i.idle.GetComponent<SpriteRenderer>().enabled = true;
        Manager.i.MoldPile.SetActive(true);
        yield return new WaitForSeconds(5);
        Manager.i.idle.GetComponent<SpriteRenderer>().enabled = false;
        Manager.i.MoldPile.SetActive(false);
        Manager.i.moldPickup.SetActive(true);
        yield return new WaitForSeconds(pAnim.length);
        Manager.i.Conti1.SetActive(true);
        yield return new WaitForSeconds(5);
        Manager.i.Conti1.SetActive(false);
        Manager.i.Conti2.SetActive(true);
        yield return new WaitForSeconds(18);
        Manager.i.Conti2.SetActive(false);
        Manager.i.Conti3.SetActive(true);
        yield return new WaitForSeconds(9);
        Manager.i.Conti3.SetActive(false);
        Manager.i.moldPickup.SetActive(false);
        sr.enabled = true;
    }

    IEnumerator Level4Radio()
    {
        yield return new WaitForSeconds(pAnim.length);
        Manager.i._6.SetActive(true);
        yield return new WaitForSeconds(15);
        Manager.i._6.SetActive(false);
        Manager.i.Radio4.SetActive(false);
        sr.enabled = true;
    }

    IEnumerator Level5Radio()
    {
        yield return new WaitForSeconds(pAnim.length);
        Manager.i._4.SetActive(true);
        yield return new WaitForSeconds(5);
        Manager.i._4.SetActive(false);
        Manager.i.Radio5.SetActive(false);
        sr.enabled = true;
    }


    void NextLevel()
    {
        Manager.i.NextLevel();
    }

}
