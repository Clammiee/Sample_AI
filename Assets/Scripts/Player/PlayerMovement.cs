using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerInputs
{
    [Tooltip("Speed of movement for all axis")]
    [SerializeField] private float speed;

    private void FixedUpdate() 
    {
        Movement();
    }

    private void Movement()
    {
        float zDirection = base.DirectionOutput(playerActions.Forwards, playerActions.Backwards);
        float xDirection = base.DirectionOutput(playerActions.Right, playerActions.Left);
        Vector3 newDir = new Vector3(xDirection, 0f, zDirection);
        Move(newDir.normalized);
    }

    private void Move(Vector3 direction)
    {
        Vector3 move = direction * speed * Time.deltaTime;
        if(move != Vector3.zero)
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", true); 
        } 
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", false);
        }
        rb.MovePosition(this.transform.position + move);
    }
}
