using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
    private float timeToChangeDirection;
    private Rigidbody2D myScriptsRigidbody2D;
     

    //initializing move
    public void Start () {
        ChangeDirection();
        myScriptsRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // update direction once per frame 
    public void Update () {
        timeToChangeDirection -= Time.deltaTime;

        myScriptsRigidbody2D.AddForce(new Vector2(7, 7)); 

        if (timeToChangeDirection <= 0) {
            ChangeDirection();
        }
        myScriptsRigidbody2D.velocity = transform.right * 3 ;
        myScriptsRigidbody2D.velocity = transform.forward * 2;
        // myScriptsRigidbody2D.velocity = transform.up * 1;
    }



    private void ChangeDirection() {
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector2.one);
        Vector2 newUp = quat * Vector2.up;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = 1.5f;
    }
}
