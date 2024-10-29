using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Animator anim;
    private int doroCount = 0;
    public GameObject failmission;
    public DoroUI doroUI1;
    public DoroUI doroUI2;
    public DoroUI doroUI3;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
   
    public void Show(int doroCount)
    {
        anim.SetTrigger("IsShow");
        this.doroCount = doroCount;
    }
    public void ShowDoro()
    {
        if(doroCount== 0)
        {
            failmission.SetActive(true);
        }
        if (doroCount >= 1)
        {
            doroUI1.Show();
        }
        if (doroCount >= 2)
        {
            doroUI2.Show();
        }
        if (doroCount >= 3)
        {
            doroUI3.Show();
        }
    }
    public void OnRestartButtonClick()
    {
        GameManagerLogic.Instance.Restart();
    }
    public void OnLevelListButtonClick()
    {
        GameManagerLogic.Instance.LevelList();
    }
}
