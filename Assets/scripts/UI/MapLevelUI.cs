using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelUI : MonoBehaviour
{
    public GameObject mapListGo;
    public GameObject LevelListGo;
    public List<MapUI> mapUIList;
    public GameObject levelTemplatePrefab;
    public GameObject levelGridGo;
  public void ShowMapList(MapSO[] mapArray)
    {
        mapListGo.SetActive(true);
        LevelListGo.SetActive(false);
        UpdateMapUIList(mapArray);
    }
    private void UpdateMapUIList(MapSO[] mapArray)
    {
        for(int i = 0; i < mapArray.Length; i++)
        {
            mapUIList[i].Show(mapArray[i].doronum,this,i+1);
        }
    }
    public void OnMapButtonClick(int mapID)
    {
       LevelSelectManager.Instance.SetSelectedMap(mapID);
        print(mapID);
        ShowLevelGrid();
    }
    private void ShowLevelGrid()
    {
        mapListGo.SetActive(false );
        LevelListGo.SetActive(true);
        int[] levelof_doronum=LevelSelectManager.Instance.GetSelectedMap();
        foreach(Transform child in levelGridGo.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0;i<levelof_doronum.Length;i++)
        {
            GameObject go=Instantiate(levelTemplatePrefab);
            go.GetComponent<RectTransform>().SetParent(levelGridGo.transform);
            go.GetComponent<LevelUI>().Show(levelof_doronum[i],i+1,this);
        }
    }
    public void OnLevelButtonClick(int levelID)
    {
        LevelSelectManager.Instance.SetSelectedLevel(levelID);
    }
    public void OnReturnButtonClick()
    {
        mapListGo.SetActive(true);
        LevelListGo.SetActive(false);
    }
}
