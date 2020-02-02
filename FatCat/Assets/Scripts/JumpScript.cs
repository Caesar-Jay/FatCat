using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public Transform jumpPos;

    private PlayerMovement playerMovement;
    private Vector3 startPos;
    private float timer;
    private bool isJumping;
    private Transform jumpTo;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isJumping == false && Input.GetKeyDown(KeyCode.Space) && jumpPos != null)
        {
            isJumping = true;
            startPos = transform.position;
            jumpTo = jumpPos;
        }

        if (isJumping)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, jumpTo.position, timer);
            if(timer >= 1)
            {
                timer = 0;
                isJumping = false;
                if (jumpTo.childCount > 0)
                {
                    jumpPos = jumpTo.GetChild(0);
                }
                else
                {
                    jumpPos = null;
                }
            }
        }
    }
}
