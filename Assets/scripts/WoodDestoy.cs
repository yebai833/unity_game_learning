using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDestoy : Distructiable
{
    private SpriteRenderer SpriteRenderer1;
    public override void Start()
    {
        base.Start();
        SpriteRenderer1 = GetComponent<SpriteRenderer>();
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentHP > 0)
        {
            Sprite beforesprite = SpriteRenderer1.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f)) - 1);
            if (index != -1)
            {
                SpriteRenderer1.sprite = injuredSpriteList[index];
            }
            if (beforesprite != SpriteRenderer1.sprite)
            {
                PlayAudioSourse();
            }
        }
        base.OnCollisionEnter2D (collision);
        
        
    }
    public virtual void PlayAudioSourse()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);
    }
}
