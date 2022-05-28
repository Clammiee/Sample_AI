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
        if(WithinVisionCheck() == true) aI_System.exclamation.SetActive(true);
        else aI_System.exclamation.SetActive(false);
    }
    private bool hitPlayer = false;

    private bool WithinVisionCheck()
    {
        if(aI_System.player != null)
        {
            Collider[] visionRangeChecks = Physics.OverlapSphere(aI_System.transform.position, aI_System.visionRange, aI_System.playerMask);

            if(visionRangeChecks.Length > 0)
            {
                Transform playerTarget = visionRangeChecks[0].transform;
                Vector3 direction = (playerTarget.position - aI_System.transform.position).normalized;

                if (Vector3.Angle(aI_System.transform.forward, direction) < aI_System.field_Of_View_Angle / 2)
                {
                    float distanceToPlayer = Vector3.Distance(aI_System.transform.position, playerTarget.position);

                    if(Physics.Raycast(aI_System.transform.position, direction, distanceToPlayer, aI_System.obstacleMask) == false)
                    {
                        hitPlayer = true;
                    }
                    else hitPlayer = false;
                }
                else hitPlayer = false;
            }
            else if(hitPlayer == true) hitPlayer = false;
        }
        else hitPlayer = false;

        return hitPlayer;
    }

    public override void End()
    {
    }

    public override void StopAnimation()
    {
    }
}
