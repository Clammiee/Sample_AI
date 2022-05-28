using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionState : State
{
    public VisionState(AISystem aISystem) : base(aISystem)
    {        

    }

    public float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    public float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
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
            //Vector3 reference_Forward = aI_System.transform.forward;
            //Vector3 reference_Right = aI_System.transform.right;
            //Vector3 newDir = (aI_System.player.transform.position - aI_System.transform.position).normalized;
            //float starter_Angle = Vector3.Angle(newDir, reference_Forward);
            //float sign = Mathf.Sign(Vector3.Dot(newDir, reference_Right));
            //float angle = sign * starter_Angle;
            //Vector3 direction = newDir;

            //RaycastHit hit;

            //if(angle < aI_System.field_Of_View_Angle && angle > -aI_System.field_Of_View_Angle)
            //{
            //    if(Physics.Raycast(aI_System.transform.position, direction, out hit, aI_System.visionRange))
            //    {
            //        if(hit.collider.CompareTag("Player"))
            //        {
            //            hitPlayer = true;
            //        }
            //        else hitPlayer = false;
            //    } 
            //    else hitPlayer = false;
            //} 
            //else hitPlayer = false;

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
