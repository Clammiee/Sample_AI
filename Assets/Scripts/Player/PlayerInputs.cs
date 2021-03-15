using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    protected Inputs inputs;
    protected Inputs.PlayerActions playerActions;
    [SerializeField] protected Rigidbody rb;

    private void Awake() 
    {
        inputs = new Inputs();
        playerActions = inputs.Player;
        playerActions.Enable();
    }

    protected bool IsInputTriggered(InputAction inputButton)
    {
        if(inputButton.triggered) return true;
        else return false;
    }

    protected float InputDetection(InputAction inputButton)
    {
        float dir = 0;
        if(inputButton.ReadValue<float>() > 0f)
        {
            dir = inputButton.ReadValue<float>();
        }
        return dir;
    }

    protected float DirectionOutput(InputAction posButton, InputAction negButton)
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
}
