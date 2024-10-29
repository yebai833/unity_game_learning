using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBirdLogic : RedbirdLogic 
{
    public GameObject anotherme;
    private Rigidbody2D rd;
    private GameObject me;
    protected override void FullTimeSkill()
    {
        ShowAnotherMe();
    }
    private void ShowAnotherMe()
    {
        Destroy(gameObject);
        me = GameObject.Instantiate(anotherme,transform.position,transform.rotation);
        rd = me.GetComponent<Rigidbody2D>();
        rd.bodyType = RigidbodyType2D.Dynamic;
        rd.velocity=rgd.velocity;
    }

}
