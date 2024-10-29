using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigLogic :MonoBehaviour
{
    public int score = 3000;
    public int maxHP = 30;
    private int currentHP;
    public List<Sprite> injuredSpriteList;
    public float hardsh = 0.5f;
    private SpriteRenderer SpriteRenderer;
    public GameObject boomPref;
    public GameObject biyan;
   // public float waiting_time=20.0f;
    //Start is called before the first frame update
    void Start()
    {
       // boomPref = Resources.Load<GameObject>("Boom1");
        SpriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHP -= (int)(collision.relativeVelocity.magnitude * hardsh);
        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f)) - 1);
            if (index != -1)
            {
                SpriteRenderer.sprite = injuredSpriteList[index];
            }
        }
        //if(Time .time%waiting_time==0)
        //{
        //    Biyan();
        //}
    }
    
    private void Dead()
    {
        GameManagerLogic.Instance.OnPigDead();
        Instantiate(boomPref, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScoreManager.Instance.ShowScore(transform.position, score);
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        
         if (currentHP > 0) 
        {
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f)) - 1);
            if (index != -1)
            {
                SpriteRenderer.sprite = injuredSpriteList[index];
            }
        }
        else if (currentHP <= 0)
        {
            Dead();
        }
    }
    //private void Biyan()
    //{
    //    GameObject.Instantiate(biyan, transform.position, Quaternion.identity);
    //}
}
