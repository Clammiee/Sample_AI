using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : PlayerInputs
{
    [Tooltip("Speed of rotation on Y axis")]
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        float yDirection = base.DirectionOutput(playerActions.RotateRight, playerActions.RotateLeft);
        Vector3 newDir = new Vector3(0f, yDirection, 0f);
        Rotate(newDir);
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion deltaRotation = Quaternion.Euler(direction * Time.fixedDeltaTime * speed);
        if(deltaRotation != Quaternion.identity)
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", true); 
        } 
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", false);
        }
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
