using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Info : MonoBehaviour
{
    public float MaxBurstSpeed;
    public float MaxInvisibleTime;
    public int MaxThunderAttackCount;
    public float MaxCanStickyIcon;
    [Range(0,100)]
    public float Player_Health;
    public int NowHP;
    public GameObject HealthText;
    static public Player_Info player_Info;
    public Transform RestartPoint;

    private void Awake()
    {
        player_Info = this;
    }
    private void Update()
    {
        if(NowHP>Player_Health)
        {
            NowHP = (int)Player_Health;
            HealthText.SetActive(true);
        }
        else
        {
            NowHP = (int)Player_Health;
        }
        if(Player_Health<=0)
        {
            Player_Health = 100;
            transform.position = RestartPoint.position;
        }
        if(Player_Health>100)
        {
            Player_Health = 100;
        }
    }
}
