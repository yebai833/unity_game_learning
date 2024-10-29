using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot,
    WaitToDie

}
public class RedbirdLogic : MonoBehaviour
{
    //public static RedbirdLogic Instance { get; private set; }

    public BirdState state= BirdState.BeforeShoot;
    private bool isMouseDown = false;
    private float maxDistance = 3f;
    public float flySpeed = 30.0f;
    protected Rigidbody2D rgd;
    public float angularV = 3f;
    public float angularDrag=0.5f;
    public float drag = 0.1f;
    public GameObject boom;
    private bool isFlying=true;
    private bool isHaveUsedSkill=false;
    protected bool isplayBird = true;
    //private void Awake()
    //{
    //    Instance = this;
    //}
    // Start is called before the first frame update
     protected virtual void Start()
    {
        rgd= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MoveContral();
                break;
            case BirdState.AfterShoot:
                SkillControl();
                StopControl(); 
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }
    }
    public void OnMouseDown ()
    { 
        if(state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject()==false) 
        { 
            isMouseDown = true;
            AudioManager.Instance.PlayShooter(transform.position);
            ShoterLogic.Instance.StartDraw(transform);
        }
        
    }
    protected virtual void OnShooterSkill()
    {
        
    }

    public void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject() == false)
        {
            isMouseDown = false;
            ShoterLogic.Instance.EndDraw();
            AudioManager.Instance.PlayBirdFlying(transform.position,isplayBird);
            Fly();
        }
    }
    private void MoveContral()
    {
        if(isMouseDown)
        {
            transform.position = GetMousePosition();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnShooterSkill();
            }
        }
    }
    
    private Vector3 GetMousePosition()
    {
        Vector3 centerpos = ShoterLogic.Instance.GetCenterPosition();
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        float distance=(mp-centerpos).magnitude;

        if(distance>maxDistance)
        {
            mp = (mp-centerpos).normalized * maxDistance+centerpos;
        }
        return mp;
    }
    private void Fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = ((ShoterLogic.Instance.GetCenterPosition() - transform.position).normalized * flySpeed);
        rgd.angularVelocity = angularV;
        rgd.angularDrag = angularDrag;
        rgd.drag = drag;
        state= BirdState.AfterShoot;
    }
    public void GoStage(Vector3 pos)
    {
        state = BirdState.BeforeShoot;
        transform.position= pos;
    }
    private void StopControl()
    {
        if(rgd.velocity.magnitude<=0.5f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird1", 2f);
        }
    }
    public void SkillControl()
    {
        if(isHaveUsedSkill==true) return;
       
        if (isFlying==true && Input.GetMouseButtonDown(0))
        {
            isHaveUsedSkill = true;
            ShowSkill();
        }
        if(Input .GetMouseButtonDown(0)) 
        {
            isHaveUsedSkill = true;
            FullTimeSkill();    
        }
    }
    protected virtual void ShowSkill()
    {

    }
    protected virtual void FullTimeSkill()
    {

    }
    protected void LoadNextBird1()
    {
        Destroy(gameObject);
        GameObject.Instantiate(boom, transform.position, Quaternion.identity);
        GameManagerLogic.Instance.LoadNextBird();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == BirdState.AfterShoot)
        {
            isFlying = false;
        }
    }
}
