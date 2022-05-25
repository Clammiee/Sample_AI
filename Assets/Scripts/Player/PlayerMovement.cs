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
        Vector3 newDir = new Vector3(0f, 0f, zDirection);

        Move((newDir).normalized);
    }

    private void Move(Vector3 direction)
    {
        Vector3 move = (direction * speed);

        
        if(move != Vector3.zero && move.z < 0)
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", false);
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "RunBack", true);
        }
        else if (move != Vector3.zero)
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", true);
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "RunBack", false);
        }
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject,"Run", false);
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "RunBack", false);
        }

        if (base.InputDetection(playerActions.Attack) == 0f)
        {
            rb.AddForce((this.transform.forward * move.z) + (this.transform.right * move.x), ForceMode.Impulse);
        }
    }
}
