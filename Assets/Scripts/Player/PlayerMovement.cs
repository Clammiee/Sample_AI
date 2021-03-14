using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Inputs inputs;
    public Inputs.PlayerActions playerActions;
    [Tooltip("Speed of movement for all axis")]
    [SerializeField] private float speed;
    [Tooltip("Drag in the rigidbody attached to this object")]
    [SerializeField] private Rigidbody rb;

    private void Awake() 
    {
        inputs = new Inputs();
        playerActions = inputs.Player;
        playerActions.Enable();
    }

    private void FixedUpdate() 
    {
        Movement();
    }

    private void Movement()
    {
        float zDirection = DirectionOutput(playerActions.Forwards, playerActions.Backwards);
        float xDirection = DirectionOutput(playerActions.Right, playerActions.Left);
        Vector3 newDir = new Vector3(xDirection, 0f, zDirection);
        Move(newDir.normalized);
    }

    private float DirectionOutput(InputAction posButton, InputAction negButton)
    {
        float DirOutput = 0f;

        if(InputDetection(posButton) > 0 && InputDetection(negButton) > 0) DirOutput = 0f;
        else if(InputDetection(posButton) > 0 || InputDetection(negButton) > 0)
        {
            if(InputDetection(posButton) > 0) DirOutput = InputDetection(posButton);
            if(InputDetection(negButton) > 0) DirOutput = -InputDetection(negButton);
        }
        else DirOutput = 0f;

        return DirOutput;
    }

    private float InputDetection(InputAction inputButton)
    {
        float dir = 0;
        if(inputButton.ReadValue<float>() > 0f)
        {
            dir = inputButton.ReadValue<float>();
        }
        return dir;
    }

    private void Move(Vector3 direction)
    {
        Vector3 move = direction * speed * Time.deltaTime;
        rb.MovePosition(this.transform.position + move);
    }
}
