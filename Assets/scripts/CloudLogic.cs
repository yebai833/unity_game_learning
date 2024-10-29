using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudLogic : MonoBehaviour
{
    public float movementRange = 20f; // 物体移动的最大距离
    public float movementSpeed = 1f; // 物体移动的速度
    private float startPosition; // 物体的起始X位置

    void Start()
    {
        startPosition = transform.position.x; // 记录起始位置
    }

    void Update()
    {
        float oscillatePosition = Mathf.Sin(Time.time * movementSpeed) * movementRange + startPosition;
        transform.position = new Vector3(oscillatePosition, transform.position.y, transform.position.z);
    }
}


    // Update is called once per frame
   


