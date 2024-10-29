using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distructiable : MonoBehaviour
{
    public int maxHP = 200;
    public int currentHP;
    public List<Sprite> injuredSpriteList;
    public float hardship = 0.002f;
    private SpriteRenderer SpriteRenderer;
    public GameObject boomPrefab;
    // Start is called before the first frame update
    public virtual  void Start()
    {
        //boomPrefab = Resources.Load<GameObject>("Boom1");
         //SpriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
    }
    public void Deadd()
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Update is called once per frame
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        currentHP -= (int)(collision.relativeVelocity.magnitude * hardship);
        if(currentHP <=0)
        {
            Deadd();
        }
        //else
        //{
        //    int index = (int)((maxHP - currentHP) / (maxHP /(injuredSpriteList.Count+1.0f))-1);
        //    if(index!=-1)
        //    {
        //        SpriteRenderer.sprite = injuredSpriteList[index];
        //    }
        //}
    }
    public void TakeDamage(int  damage)
    {
        currentHP -= damage;
       
        if (currentHP >0) 
        {
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f)) - 1);
            if (index != -1)
            {
                SpriteRenderer.sprite = injuredSpriteList[index];
            }
        }
        else if (currentHP <= 0)
        {
            Deadd();
        }
    }
    
}
