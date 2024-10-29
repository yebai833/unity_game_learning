using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public static GameManagerLogic Instance { get; private set;}
    public GameSO gameSO;
    private RedbirdLogic[] birdlist;
    private int index = 0;
    private int PigTotalCount;
    private int PigDeadCount;
    private CameraFollow camerafollow;
    public GameOverUI gameOverui;
    private void Awake()
    {
        Instance = this;
        PigDeadCount = 0;
        LoadSelectedLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        PigTotalCount = FindObjectsOfType<PigLogic>().Length;
        birdlist = FindObjectsOfType<RedbirdLogic>();
        camerafollow = Camera.main.GetComponent<CameraFollow>();
        LoadNextBird();
    }

  private void LoadSelectedLevel()
    {
        Time.timeScale = 1;
        int mapID = gameSO.SelectedMapID;
        int levelID=gameSO.selectedLevelID;
        GameObject levelPrefab = Resources.Load<GameObject>("Map" + mapID + "/" + "Level" + levelID);
        if (levelPrefab == null)
        {
            Debug.LogError("无法加载关卡，请检查路径和资源是否存在：" + "Map" + mapID + "/" + "Level" + levelID);
        }
        else
        {
            GameObject.Instantiate(levelPrefab);
        }

    }
    public void OnPigDead()
    {
        PigDeadCount++;
        if( PigDeadCount>=PigTotalCount)
        {
            End();
        }
    }

    public void LoadNextBird()
    {
        if(index>=birdlist.Length)
            {
             End1();
            }
        else 
          {
            birdlist[index].GoStage(ShoterLogic.Instance.GetCenterPosition());
            camerafollow.GetTarget(birdlist[index].transform);
          }
        index++;
    }
    private void End()
    {
        {
            //print("游戏结束");
            //AudioManager.Instance.PlayGameEnd(Camera.main.transform.position);
            GameOver();
        }
    }
    private void End1()
    {
        //print("鸟");
        GameOver();
    }
    private void GameOver()
    {
        int doroCount = 0;
        float pigDeadPercent=PigDeadCount*1f/PigTotalCount;
        if (pigDeadPercent >=1f)
        {
            doroCount = 3;
        }else if (pigDeadPercent > 0.66f)
        {
            doroCount = 2;
        }else if (pigDeadPercent > 0.33f)
        {
            doroCount = 1;
        }
        gameOverui.Show(doroCount);
        gameSO.UpdateLevel(doroCount);
    }
    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelList()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
