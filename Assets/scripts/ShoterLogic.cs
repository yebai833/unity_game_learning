using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterLogic : MonoBehaviour
{
    public static ShoterLogic Instance {  get; private set; }
    private LineRenderer leftLineRender;
    private LineRenderer rightLineRender;
    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;
    private bool isDrawing=false;
    private Transform birdtransform;
    private void Awake()
    {
        Instance = this;
        leftLineRender = transform.Find("Line/line1").GetComponent<LineRenderer>();
        rightLineRender = transform.Find("Line/line2").GetComponent<LineRenderer>();
        leftPoint = GameObject.Find("target/target_left").transform;
        rightPoint = GameObject.Find("target/target_right").transform;
        centerPoint = GameObject.Find("target/target_center").transform;
        HideLine();
    }
    // Start is called before the first frame update
    //void Start()
    //{
       
    //}

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }
    public void StartDraw(Transform birdtransform)
    {
        isDrawing = true;
        this.birdtransform = birdtransform;
        ShowLine();
    }
    public void EndDraw()
    {
        isDrawing=false;
        HideLine();
    }
    public void Draw()
    {
        Vector3 birdpos = birdtransform.position;
        birdpos = (birdpos-centerPoint.position).normalized*0.5f+birdpos;
        leftLineRender.SetPosition(0,birdpos);
        leftLineRender.SetPosition(1,leftPoint.position); 
        rightLineRender.SetPosition(0,birdpos);
        rightLineRender.SetPosition(1,rightPoint.position);
    }
    public Vector3 GetCenterPosition()
    {
        return centerPoint.position;
    }
    private void HideLine()
    {
        leftLineRender.enabled = false;
        rightLineRender.enabled = false;
    }
    private void ShowLine()
    {
        leftLineRender.enabled = true ;
        rightLineRender.enabled = true;
    }
}
