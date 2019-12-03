using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 direction;

    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getinput();

        if (direction == Vector2.left)
        {

            Debug.Log("veolcity: " + myRigidBody.velocity.x);
            mySpriteRenderer.flipX = true;
        }
        else if(direction == Vector2.right)
        {
           
            mySpriteRenderer.flipX = false;
        }

        move();
    }

    public void move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void getinput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }



    }

}
