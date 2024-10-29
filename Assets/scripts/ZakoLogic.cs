using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoLogic : MonoBehaviour
{
    public GameObject boom;
    private float boomRadius=9f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rgd=GetComponent<Rigidbody2D>();
        Distructiable dist=collision.gameObject.GetComponent<Distructiable>();
        PigLogic pi=collision.gameObject.GetComponent<PigLogic>();

        if (dist!=null||pi!=null||rgd.velocity.magnitude<=3f)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
            foreach (Collider2D collider in colliders)
            {
                Distructiable des = collider.GetComponent<Distructiable>();
                PigLogic pig = collider.GetComponent<PigLogic>();
                if (des != null)
                {
                    des.TakeDamage(100000);
                }
                if (pig != null)
                {
                    pig.TakeDamage(20);
                }
            }
            AudioManager.Instance.PlayBoom(transform.position);
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
