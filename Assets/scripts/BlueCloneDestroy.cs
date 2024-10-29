using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCloneDestroy : MonoBehaviour
{
    protected Rigidbody2D rgd;
    public GameObject boom;
    private bool isLoad=false;
   void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rgd.velocity.magnitude<=0.1f&&isLoad == false)
          {
            Destroy(gameObject, 1f);
            GameObject.Instantiate(boom, rgd.transform.position, Quaternion.identity);
            LoadNext();
            isLoad = true;
        }
             
    }
    protected virtual void LoadNext()
    { 
    }
}
