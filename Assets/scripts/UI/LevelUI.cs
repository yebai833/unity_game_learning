using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject unlockGo;
    public GameObject lockGo;

    public TextMeshProUGUI levelNumberText;
    public GameObject doro0Go;
    public GameObject doro1Go;
    public GameObject doro2Go;
    public GameObject doro3Go;
  
    private MapLevelUI mapLevelUI;
    private int levelID;
    public void Show(int doroCount,int levelID,MapLevelUI mapLevelUI)
    {
        this.levelID = levelID;
        this.mapLevelUI = mapLevelUI;
        levelNumberText.text = levelID.ToString();
        doro0Go.SetActive(false);
        doro1Go.SetActive(false);
        doro2Go.SetActive(false);
        doro3Go.SetActive(false);
        if(doroCount<=-1)
        {
            unlockGo.SetActive(false);
            lockGo.SetActive(true);
        }
        else
        {
            unlockGo.SetActive(true) ;
            lockGo.SetActive(false);
            if(doroCount==3)
            {
                doro3Go.SetActive(true);
            }
            else if(doroCount==2)
            {
                doro2Go.SetActive(true);
            }
            else if(doroCount==1)
            {
                doro1Go.SetActive(true);
            }
            else if (doroCount == 0)
            {
                doro0Go.SetActive(true);
            }
        }
    }
    public void OnClick()
    {
        mapLevelUI.OnLevelButtonClick(levelID);
    }
}
