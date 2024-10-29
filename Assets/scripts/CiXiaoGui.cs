using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiXiaoGui : RedbirdLogic
{
    public List<GameObject> zakoprefab;
    private float[] uptoward = {6f,3f,0f,-3f,-6f};
    //private float forward = 9f;
    public int MaxShoot=20;
    public float rightspeed=5f;
    //private float right_length = 6f;
    private int count = 0;
    private Vector3 createpos;
    private Vector3 toward1;
    private Vector3 along_way;

    protected override void OnShooterSkill()
    {  
        if (count * 5 >= MaxShoot)
        {
            return;
        }
        for (int i = 0; i < 5; i++)
        {
            Invoke("ZakoShoot", 0.1f);
        }
        count++;
    }
    private void ZakoShoot()
    {
        toward1 =(ShoterLogic.Instance.GetCenterPosition() - transform.position).normalized;
        along_way = Vector3.Cross(Vector3.forward, toward1).normalized;
        Vector3 vec = toward1*6f + along_way * uptoward[Random.Range(0, 5)];
        createpos =vec+transform.position;
        Instantiate(boom, createpos, Quaternion.identity);
        GameObject zako = GameObject.Instantiate(zakoprefab[Random.Range(0,5)], createpos, Quaternion.identity);
        Rigidbody2D zrd = zako.GetComponent<Rigidbody2D>();
        if(zrd!=null)
        {
            zrd.bodyType = RigidbodyType2D.Dynamic;
            zrd.velocity = vec.normalized * rightspeed;
            Quaternion targetRotation = Quaternion.LookRotation(vec);
            zrd.MoveRotation(targetRotation);
        }
    }
    
}
