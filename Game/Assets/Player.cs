using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public float health;
    public string current_level;
    public string play_date;

    private Vector2 direction;

    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D myRigidBody;

    //to access the Animator component tied to Player
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();

        string is_loading = PlayerPrefs.GetString("loading");
        if (is_loading == "true")
        {
            string json = File.ReadAllText("./saves/gamesave.json");

            Save save = JsonUtility.FromJson<Save>(json);
            direction.x += save.currentX;
            move();
            direction.y += save.currentY;
            move();
            Debug.Log(save.currentX);
            Debug.Log("Loaded game from: " + save.gamedate);
            PlayerPrefs.SetString("loading", "false");
            PlayerPrefs.Save();
        }
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
        animator.SetFloat("speed", 0);

        // MOVE
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
            animator.SetFloat("speed", 1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
            animator.SetFloat("speed", 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
            animator.SetFloat("speed", 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            animator.SetFloat("speed", 1);

        }

        // ATTACK
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isAttacking", true);

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isAttacking", false);

        }



    }
    public float getPositionX()
    {
        return direction.x;
    }



    public float getPositionY()
    {
        return direction.y;
    }

    public void setPositionX(float current_x)
    {
        direction.x = current_x;
    }
    public void setPositionY(float current_y)
    {
        direction.y = current_y;
    }
}
