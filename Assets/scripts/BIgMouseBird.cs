using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIgMouseBird : RedbirdLogic 
{
    protected override void FullTimeSkill()
    {
        Vector2 velocity=rgd.velocity;
        if(rgd.velocity.x<2)
        {
            velocity .x =-velocity.x*100;
        }
        else if(rgd.velocity.x>2)
        {
            velocity.x = -velocity.x * 3;
        }
        rgd.velocity=velocity;
        Vector3 scale=transform.localScale;
        scale.x=-scale.x;
        transform.localScale = scale;
    }
}
