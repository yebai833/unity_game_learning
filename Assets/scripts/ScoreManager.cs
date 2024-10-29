using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public GameObject scoreprefab;
    public Sprite[] score1000;
    public Sprite[] score3000;
    public Sprite[] score5000;
    public Sprite[] score10000;
    public Dictionary<int, Sprite[]> scoreDict;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreDict = new Dictionary<int,Sprite[]>();
        scoreDict.Add(1000,score1000);
        scoreDict.Add(3000,score3000);
        scoreDict.Add(5000,score5000);
        scoreDict.Add(10000,score10000);

    }

    void Update()
    {
        
    }
    public void ShowScore(Vector3 position,int score)
    {
        GameObject ScoreGo=GameObject.Instantiate(scoreprefab,position,Quaternion.identity);
        Sprite[] scoreArray;
        scoreDict.TryGetValue(score, out scoreArray);
        int index=Random.Range(0,scoreArray.Length);
        Sprite sprite = scoreArray[index];
        ScoreGo.GetComponent<SpriteRenderer>().sprite = sprite;
        Destroy(ScoreGo,1f);
    }
}
