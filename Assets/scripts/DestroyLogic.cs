using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLogic : MonoBehaviour
{
    public float time=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,time);
    }

    // Update is called once per frame
   
}
