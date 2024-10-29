using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : RedbirdLogic 
{
    private float boomRadius = 10f;
    protected override void FullTimeSkill()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);

        foreach (Collider2D collider in colliders)
        {
            Distructiable des = collider.GetComponent<Distructiable>();
            PigLogic pig= collider.GetComponent<PigLogic>();
            if (des != null) 
            {
                des.TakeDamage(1000000);
            }
            if (pig != null)
            {
                pig.TakeDamage(30);
            }
        }
        AudioManager.Instance.PlayBoom(transform.position);
        state = BirdState.WaitToDie;
        LoadNextBird1();
    }
}
