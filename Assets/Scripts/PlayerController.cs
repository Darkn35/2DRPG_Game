using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D playerRigidBody;
    private static bool playerExists;
    public string startPoint;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            playerRigidBody.velocity = Vector2.zero;
            return;
        }
        // movement control
        if (Input.GetAxisRaw("Horizontal") !=0f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * moveSpeed * Time.deltaTime);
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
        }
        else if (Input.GetAxisRaw("Vertical") !=0f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * moveSpeed * Time.deltaTime);
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(0f, playerRigidBody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0f);
        }

        anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("playerMoving", playerMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);
    }
}
