using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothspeed=1;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (target != null)
        {
            Vector3 position = transform.position;
            position.x = target.position.x;
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothspeed);
        }
        
    }
    public void GetTarget(Transform trans)
    {
        this.target = trans;
    }
}
