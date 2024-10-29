using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLogic : MonoBehaviour
{
    public GameObject boomfrefab;
    public float boomRadius = 5f;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
            foreach (Collider2D collider in colliders)
            {
                Distructiable des = collider.GetComponent<Distructiable>();
                PigLogic pig=collider.GetComponent<PigLogic>();
                if (des != null)
                {
                    des.TakeDamage(Int32.MaxValue);
                }
                if(pig != null)
            {
                    pig.TakeDamage(10);
            }
            }
            AudioManager.Instance.PlayBoom(transform.position);
            GameObject.Instantiate(boomfrefab, transform.position,Quaternion.identity);
            Destroy(gameObject);
    }

}
        
    
