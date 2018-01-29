using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public EnemyHitBox ehb;
    public GameObject Player;
    public Rigidbody2D rb;
    public GameObject[] patrolArray;
    public bool playerHit;
    public bool positive = true;
    public float mSpeed;
    public int patrolPoint;

    // Use this for initialization
    void Start () {
        ehb = GetComponentInChildren<EnemyHitBox>();
        rb = this.GetComponent<Rigidbody2D>();  
	}

    // Update is called once per frame
    void Update() {
        if (ehb.EnemyHit == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, mSpeed * Time.deltaTime);
            Mathf.Clamp(rb.velocity.x, -10f, 10f);
        }
      /*  if (positive)
        {
            if (patrolPoint == 0)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[1].transform.position, mSpeed * Time.deltaTime);
            }
            if (patrolPoint == 1)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[2].transform.position, mSpeed * Time.deltaTime);
            }
            if (patrolPoint == 2)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[3].transform.position, mSpeed * Time.deltaTime);
            }
            positive = false;
        }
        if (!positive)
        {
            if (patrolPoint == 3)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[2].transform.position, mSpeed * Time.deltaTime);
            }
            if (patrolPoint == 2)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[1].transform.position, mSpeed * Time.deltaTime);
            }
            if (patrolPoint == 1)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[0].transform.position, mSpeed * Time.deltaTime);
            }
            positive = false;
        }*/

    }

       // transform.position = Vector2.MoveTowards(this.transform.position, patrolArray[i].transform.position, (mSpeed / 2) * Time.deltaTime);
}
