using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionState : State
{
    public VisionState(AISystem aISystem) : base(aISystem)
    {        

    }

    public override void DoAction()
    {

        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Vision", true);
        
        //PUT THIS ON UI TO DEBUG OR SOMETHING------------------
        if(WithinVisionCheck() == true) Debug.Log("We SEE the player");
        else Debug.Log("We DONT see the player");
    }

    private bool WithinVisionCheck()
    {
        Vector3 reference_Forward = aI_System.forwardVector;
        Vector3 reference_Right = Vector3.Cross(aI_System.upVector, reference_Forward);
        Vector3 newDir = aI_System.player.transform.position - aI_System.transform.position;
        float starter_Angle = Vector3.Angle(newDir, reference_Forward);
        float sign = Mathf.Sign(Vector3.Dot(newDir, reference_Right));
        float angle = sign * starter_Angle;
        Vector3 direction = newDir;

        bool hitPlayer = false;
        RaycastHit hit;
        if(angle < aI_System.field_Of_View_Angle && angle > -aI_System.field_Of_View_Angle)
        {
            if(Physics.Raycast(aI_System.transform.position, direction.normalized, out hit, aI_System.visionRange))
            {
                if(hit.collider.CompareTag("Player"))
                {
                   hitPlayer = true;
                }
                else hitPlayer = false;
            } 
            else hitPlayer = false;
        } 
        else hitPlayer = false;

        return hitPlayer;
    }

    public override void End()
    {
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Vision", false);
    }

    public override void StopAnimation()
    {
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Vision", false);
    }
}
