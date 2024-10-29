using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject doroUI;
    public TextMeshProUGUI doroCountTextUI;
    private MapLevelUI mapLevelUI;
    private int mapID;
 
    public void Show(int doroCount,MapLevelUI mapLevelUI,int mapID)
    {
        this.mapLevelUI = mapLevelUI; 
        this.mapID = mapID;
        if (doroCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            lockUI.GetComponent<Image>().sprite=GetComponent<Image>().sprite;
            doroUI.SetActive(false);
        }
        else
        {
            lockUI.SetActive(false);
            doroUI.SetActive(true);
            doroCountTextUI.text = doroCount.ToString();
        }
    }
    public void OnClick()
    {
        mapLevelUI.OnMapButtonClick(mapID);
    }
}
