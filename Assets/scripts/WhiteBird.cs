using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBird : RedbirdLogic 
{
   public GameObject eggprefab;
    private GameObject egg;
    public float speed;
    public float createdistance=5f;
    public float fallspeed = 15f;
    public float fall_length = 3f;
    public bool isShoot=false;
    
    protected override void ShowSkill()
    {
        ShowEgg();
        
    }
    private void ShowEgg()
    {
        Vector3  pos = transform.position + -transform.up * createdistance;
        Vector3 towards=Vector3.down * fall_length;
        GameObject.Instantiate(boom, transform.position, Quaternion.identity);
        AudioManager.Instance.PlayBoomShoot(transform.position);
        egg=GameObject.Instantiate(eggprefab,pos,Quaternion.identity);
        Rigidbody2D rd=egg.GetComponent<Rigidbody2D>();
        if (rd != null)
        {
            rd.bodyType = RigidbodyType2D.Dynamic;
            rd.velocity = towards * fallspeed;
        }
        isShoot = true;
    }
}
