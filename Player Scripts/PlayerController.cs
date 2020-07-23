using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float startSpeed = 5f;
    private float moveSpeed;
    public float runSpeed = 2f;
    public Rigidbody2D playerRB;
    UnityEngine.Vector2 movement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        CheckLastInput();

    }

    private void FixedUpdate()
    {

        playerRB.MovePosition(playerRB.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = startSpeed * runSpeed;
        }
        else
        {
            moveSpeed = startSpeed;
        }
    }

    private void CheckLastInput()
    {
        if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat("lastMoveX", movement.x);
 
            animator.SetFloat("lastMoveY", movement.y);
        }
    }

   
}
