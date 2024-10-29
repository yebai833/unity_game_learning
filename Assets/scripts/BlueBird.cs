using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : RedbirdLogic 
{
    public float cloneDistance = 2f;
    public GameObject clonePrefab;
    private GameObject aclone;
    private GameObject bclone;
    private bool isFenshen=false;
    
    protected override void ShowSkill()
    {
        if (isFenshen == false)
        {
            GameObject.Instantiate(boom, rgd.transform.position, Quaternion.identity);
            CloneOnHead();
            CloneOnBottom();
        }
        isFenshen = true;
       
    }

    private void CloneOnHead()
    {
        Vector3 top = transform.position+transform.up*cloneDistance;
        GameManagerLogic.Instantiate(boom, top, Quaternion.identity);
        aclone=GameObject.Instantiate(clonePrefab,top,transform.rotation);
        if (aclone.GetComponent<Rigidbody2D>() != null)
        { 
            Rigidbody2D topclonerigid = aclone.GetComponent<Rigidbody2D>();
            if (topclonerigid != null)
            {
                topclonerigid.bodyType = RigidbodyType2D.Dynamic;
                topclonerigid.velocity = rgd.velocity;
            }
        }
        
    }
    private void CloneOnBottom()
    {
        Vector3 top = transform.position + -transform.up * cloneDistance;
        GameManagerLogic.Instantiate(boom, top, Quaternion.identity);
        bclone =GameObject.Instantiate(clonePrefab, top, transform.rotation);

        if (bclone.GetComponent<Rigidbody2D>()!= null) 
        {
            Rigidbody2D bottomclonerigid = bclone.GetComponent<Rigidbody2D>();
            if (bottomclonerigid != null)
            {
                bottomclonerigid.bodyType = RigidbodyType2D.Dynamic;
                bottomclonerigid.velocity = rgd.velocity;
            }
            
        }
        
    } 
}
