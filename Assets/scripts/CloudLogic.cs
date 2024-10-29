using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudLogic : MonoBehaviour
{
    public float movementRange = 20f; // �����ƶ���������
    public float movementSpeed = 1f; // �����ƶ����ٶ�
    private float startPosition; // �������ʼXλ��

    void Start()
    {
        startPosition = transform.position.x; // ��¼��ʼλ��
    }

    void Update()
    {
        float oscillatePosition = Mathf.Sin(Time.time * movementSpeed) * movementRange + startPosition;
        transform.position = new Vector3(oscillatePosition, transform.position.y, transform.position.z);
    }
}


    // Update is called once per frame
   


