using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput)), RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const int posCount = 3;
    private Vector2[] movementPos = new Vector2[posCount];
    private int currentPos = 1;

    private bool move = false;
    private Vector3 target = Vector3.zero;
    
    [Header("Player Data")]
    public Rigidbody2D rb;
    public float moveForceMultiplier = 1f;
       

    private void Awake()
    {
        //populates the allowed movement positions of the player
        movementPos[1] = gameObject.transform.position;
        movementPos[0] = movementPos[1] + 4*Vector2.left;
        movementPos[2] = movementPos[1] + 4*Vector2.right;
    }

    private void FixedUpdate()
    {

        if (move)
        {
            Vector3 moveToVector = target - gameObject.transform.position;
            rb.AddForce(moveToVector.normalized * moveForceMultiplier,ForceMode2D.Impulse);
            if (Mathf.Abs((transform.position - target).magnitude) < 0.5f){
                rb.velocity = Vector2.zero;
                transform.position = target;
                move = false;
            }
        }   
    }

    public void moveRight()
    {
        rb.velocity = Vector2.zero;
        currentPos = (currentPos + 1 >= posCount) ? posCount - 1 : currentPos + 1;
        move = true;
        target = movementPos[currentPos];
    }

    public void moveLeft()
    {
        rb.velocity = Vector2.zero;
        currentPos = (currentPos - 1 < 0) ? 0 : currentPos - 1;
        move = true;
        target = movementPos[currentPos];
    }
}
