using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoroUI : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Show()
    {
        anim.SetTrigger("IsShow");
    }
}
