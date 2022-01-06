using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeEffect : MonoBehaviour
{
    public int NowEffectID;
    public bool StopChange;
    public PlayerMove_v2 move_V2;
    public float MaxSpeedBurstTime, MaxCanStickyIcon, MaxInvisibleTime, ThunderAttackCount;
    public GameObject FastEffectIcon, CanStickyIcon, ThunderAttackIcon, InvisibleIcon;
    public GameObject SpeedDownText,AttackEffect;
    public Transform ShootPoint;
    private void Start()
    {
        MaxSpeedBurstTime = Player_Info.player_Info.MaxBurstSpeed;
        MaxCanStickyIcon = Player_Info.player_Info.MaxCanStickyIcon;
        MaxInvisibleTime = Player_Info.player_Info.MaxInvisibleTime;
        ThunderAttackCount = Player_Info.player_Info.MaxThunderAttackCount;
    }
    void Update()
    {
        switch (NowEffectID)
        {
            case -1:

                break;
            case 0:
                ThunderAttack();
                
                break;
            case 1:
                BoxCanSticky();
                break;
            case 2:
                SpeedBurst();
                break;
            case 3:
                Invisible();
                break;

        }
    }
    void Invisible()
    {
        if (StopChange == false)
        {
            InvisibleIcon.SetActive(true);
            InvisibleIcon.GetComponent<SkillKeepTime>().KeepTime = Player_Info.player_Info.MaxInvisibleTime;
            StopChange = true;
        }
        MaxInvisibleTime -= Time.deltaTime;
        if (MaxInvisibleTime <= 0)
        {
            InvisibleIcon.SetActive(false);
            MaxInvisibleTime = Player_Info.player_Info.MaxInvisibleTime;
            StopChange = false;
            NowEffectID = -1;
        }
    }
    void ThunderAttack()
    {
        if (StopChange == false)
        {
            ThunderAttackIcon.SetActive(true);
            ThunderAttackCount = Player_Info.player_Info.MaxThunderAttackCount;
            StopChange = true;
        }
        if (ThunderAttackCount <= 0)
        {
            StopChange = false;
            ThunderAttackIcon.SetActive(false);
            NowEffectID = -1;
        }
        if(ThunderAttackCount>0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(AttackEffect, ShootPoint.position, ShootPoint.rotation);
                ThunderAttackCount -= 1;
            }
        }
    }
    void BoxCanSticky()
    {
        if (StopChange == false)
        {
            CanStickyIcon.SetActive(true);
            CanStickyIcon.GetComponent<SkillKeepTime>().KeepTime = Player_Info.player_Info.MaxCanStickyIcon;
            StopChange = true;
        }
        MaxCanStickyIcon -= Time.deltaTime;
        if (MaxCanStickyIcon <= 0)
        {
            MaxCanStickyIcon = Player_Info.player_Info.MaxCanStickyIcon;
            CanStickyIcon.SetActive(false);
            StopChange = false;
            NowEffectID = -1;
        }
    }
    void SpeedBurst()
    {
        if (StopChange == false)
        {
            FastEffectIcon.SetActive(true);
            FastEffectIcon.GetComponent<SkillKeepTime>().KeepTime = Player_Info.player_Info.MaxBurstSpeed;
            StopChange = true;
        }
        MaxSpeedBurstTime -= Time.deltaTime;
        if (MaxSpeedBurstTime > 0)
        {
            move_V2.AddSpeed = 15;
            move_V2.FaseSpeed = 4;
        }
        else
        {
            move_V2.AddSpeed = 8;
            move_V2.FaseSpeed = 1;
            MaxSpeedBurstTime = Player_Info.player_Info.MaxBurstSpeed;
            SpeedDownText.SetActive(true);
            StopChange = false;
            NowEffectID = -1;
        }
    }
}
