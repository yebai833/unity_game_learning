using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        anim.SetBool("IsShow",true);
    }
    public void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        anim.SetBool("IsShow", false);
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
