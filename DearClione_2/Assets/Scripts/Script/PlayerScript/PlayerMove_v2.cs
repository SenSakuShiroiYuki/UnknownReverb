using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove_v2 : MonoBehaviour
{
    public Rigidbody m_RigidBody;
    public float speed = 6f;
    public float FaseSpeed;
    public float turnSpeed;
    public float AddSpeed;
    public float MineSpeed;
    public PickUp pickUp;
    bool RestSpeed;
    //
    [Header("-----Audio-----")]
    public AudioSource MoveAudio;
    [Header("-----速度計算-----")]
    public Vector3 LastPos = Vector3.zero;
    public float velocity = 0;
    float Timer = 0;
    //
    [Header("-----牆壁檢測-----")]
    public float rayLength = 5;
    RaycastHit hit_forward, hit_Back, hit_Down;
    public LayerMask wallLayer;
    public bool ForwardHaveWall;
    public bool BackHaveWall;
    public Transform[] ForwardPoint;
    public Transform[] BackPoint;
    [Header("-----傾斜物件-----")]
    public Transform ChileObj;
    public Terrain terrain;
    public Vector3 G_Normal;
    [Header("-----DeBugText-----")]
    //public Text text;
    [Header("-----動畫-----")]
    public Animator ChaterAnim;
    public float IdelWaitTime;
    public float MaxWaitTime;
    [Header("-----角色狀態-----")]
    public PlayerState playerState;
    public float StopTime;
    bool StateChanged;
    public enum PlayerState
    {
        Stop,
        Dead,
        Normal
    }
    private void Start()
    {
        MaxWaitTime = Random.Range(30, 60);
        IdelWaitTime = MaxWaitTime;
    }
    private void Update()
    {
        TriggerWall();
        StateIsChange();
        WaitIdel();
        //SpeedShow();
    }
    private void FixedUpdate()
    {
        if (pickUp.StartRotate == false && pickUp.BackRotate == false)
        {
            if (playerState == PlayerState.Normal)
            {
                Move();
                Turn();
            }
        }
    }
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        MoveAudio.volume = speed / AddSpeed;

        if (speed == 0)
        {
            ChaterAnim.SetBool("Start", false);
            ChaterAnim.SetBool("Stop", false);
        }
        else if (speed > 0)
        {
            ChaterAnim.SetBool("Start", true);
            ChaterAnim.SetBool("Stop", false);
        }
        else
        {
            ChaterAnim.SetBool("Start", false);
            ChaterAnim.SetBool("Stop", true);
        }

        if (v == 0)
        {
            if (speed != 0)
                if (speed < 0)
                {
                    speed += Time.deltaTime * 30;
                    if (speed > 0)
                    {
                        speed = 0;
                    }
                }
                else if (speed > 0)
                {
                    speed -= Time.deltaTime * 30;
                    if (speed < 0)
                    {
                        speed = 0;
                    }
                }
        }
        else
        {
            if (ForwardHaveWall == true && BackHaveWall == false)
            {
                if (v < 0)
                {
                    speed += v * Time.deltaTime * FaseSpeed;
                    if (speed >= AddSpeed)
                    {
                        speed = AddSpeed;
                    }
                    else if (speed <= -MineSpeed)
                    {
                        speed = -MineSpeed;
                    }
                }
                else
                {
                    speed = 0;
                }
            }
            if (ForwardHaveWall == false && BackHaveWall == true)
            {
                if (v > 0)
                {
                    speed += v * Time.deltaTime * FaseSpeed;
                    if (speed >= AddSpeed)
                    {
                        speed = AddSpeed;
                    }
                    else if (speed <= -MineSpeed)
                    {
                        speed = -MineSpeed;
                    }
                }
                else
                {
                    speed = 0;
                }
            }
            if (ForwardHaveWall == false && BackHaveWall == false)
            {
                if (speed > 0)
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        speed += v * Time.deltaTime * 60f;
                    }
                    else
                    {
                        speed += v * Time.deltaTime * FaseSpeed;
                    }
                }
                else if (speed < 0)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        speed += v * Time.deltaTime * 60f;
                    }
                    else
                    {
                        speed += v * Time.deltaTime * FaseSpeed;
                    }
                }
                else
                {
                    speed += v * Time.deltaTime * FaseSpeed;
                }

                if (speed >= AddSpeed)
                {
                    speed = AddSpeed;
                }
                if (speed <= -MineSpeed)
                {
                    speed = -MineSpeed;
                }

            }
        }
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        m_RigidBody.MovePosition(m_RigidBody.position + movement);
    }
    void WaitIdel()
    {
        if (IdelWaitTime <= 0)
        {
            ChaterAnim.SetTrigger("Wait");
            MaxWaitTime = Random.Range(30, 60);
            IdelWaitTime = MaxWaitTime;
        }
        if (speed == 0)
        {
            IdelWaitTime -= Time.deltaTime;
        }
        else
        {
            IdelWaitTime = MaxWaitTime;
        }
    }
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        ChileObj.eulerAngles = new Vector3(ChileObj.eulerAngles.x, ChileObj.eulerAngles.y, -(h * 15));
        float turn = h * turnSpeed * Time.deltaTime;
        Vector3 Point_dir = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, Point_dir, out hit_Down, 50f, wallLayer))
        {
            ChileObj.rotation = m_RigidBody.rotation * Quaternion.Euler(hit_Down.normal.x, 0, 0);
        }
        else
        {
            G_Normal = Vector3.zero;
        }
        if (speed < 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0, -turn, 0f);
            m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
        }
        else if (speed == 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0f);
            m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
        }
        else
        {
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0f);
            m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
        }
    }
    void TriggerWall()
    {
        for (int i = 0; i < ForwardPoint.Length; i++)
        {
            Vector3 fwd = ForwardPoint[i].TransformDirection(Vector3.forward);
            if (Physics.Raycast(ForwardPoint[i].position, ForwardPoint[i].forward, out hit_forward, rayLength, wallLayer))
            {
                ForwardHaveWall = true;
            }
            else
            {
                ForwardHaveWall = false;
            }
        }
        for (int i = 0; i < BackPoint.Length; i++)
        {
            Vector3 back = BackPoint[i].TransformDirection(-Vector3.forward);
            if (Physics.Raycast(BackPoint[i].position, -BackPoint[i].forward, out hit_Back, rayLength, wallLayer))
            {
                BackHaveWall = true;
            }
            else
            {
                BackHaveWall = false;
            }
        }
    }
    /* void SpeedShow()
     {
         Timer += Time.deltaTime;
         if (Timer > 0.016f)
         {
             velocity = Velocity() / 0.016f;
             text.text = (velocity * 10).ToString("0");
             Timer = 0;
         }
     }*/
    /*private float Velocity()
    {
        if (LastPos != transform.position)
        {

            velocity = Vector3.Distance(LastPos, transform.position);
        }
        else
        {
            velocity = 0;
        }
        LastPos = transform.position;
        return velocity;
    }*/

    void StateIsChange()
    {
        if (playerState == PlayerState.Stop && StateChanged == false)
        {
            speed = 0;
            StartCoroutine(ReSetState());
            StateChanged = true;
        }
    }
    IEnumerator ReSetState()
    {
        yield return new WaitForSeconds(StopTime);
        playerState = PlayerState.Normal;
        StateChanged = false;
    }
}
