using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {
    public bool EnemyHit;
    
    //Chase On
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Player"))
            EnemyHit = true;
    }

    //Chase Off
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
            EnemyHit = false;
    }
}
