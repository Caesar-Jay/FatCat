using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public bool canMove;
    public Animator animator;
    public int fatness;
    public bool isMoving;

    private bool movingLeft;
    private bool isAnimating;

    void Start()
    {
    }

    void Update()
    {
        if (isMoving && isAnimating == false)
        {
            if (movingLeft)
                animator.SetTrigger($"Walking{fatness}");
            else
                animator.SetTrigger($"Walking{fatness}");

            isAnimating = true;
        }

        if (isMoving == false && isAnimating)
        {
            animator.SetTrigger($"Idle{fatness}");
            isAnimating = false;
        }
        
    }

    private void FixedUpdate()
    {
        if(canMove)
            Move();
    }

    void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis == 0 && vAxis == 0)
            isMoving = false;
        else
        {
            isMoving = true;
            movingLeft = hAxis < 0 ? true : false;
        }

        var movement = new Vector3(-hAxis, vAxis, 0) * movementSpeed * Time.fixedDeltaTime;

        transform.position += movement;
    }

    public void GetFatter()
    {
        if(fatness < 3)
        {
            fatness++;
            AudioController.audioController.PlayEffect("Eating");
        }
    }
}
