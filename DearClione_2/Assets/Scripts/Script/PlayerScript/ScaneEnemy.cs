using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaneEnemy : MonoBehaviour
{
    public GameObject SpeedText;
    public GameObject[] Info_UI, Laser;
    public Animator ScaneAnimator;
    public Collider[] Enemy;
    public List<Collider> Enemy1, Enemy2, Enemy3, Enemy4, Switch;
    public LayerMask layer;
    public float ScaneRange;
    public float ColdTime;
    public bool ScaneColdDone;
    public PlayerTakeEffect takeEffect;
    public FindObjOutCam[] findObj;
    public Transform[] Link;
    void Update()
    {
        if (ScaneColdDone == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartScane();
            }
        }
        if (Enemy1.Count > 0)
        {
            Laser[0].SetActive(true);
            Laser[0].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            Laser[0].GetComponent<LineRenderer>().SetPosition(1, Enemy1[0].transform.position + new Vector3(0, 1f, 0));
        }
        if (Enemy2.Count > 0)
        {
            Laser[1].SetActive(true);
            Laser[1].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            Laser[1].GetComponent<LineRenderer>().SetPosition(1, Enemy2[0].transform.position + new Vector3(0, 1f, 0));
        }
        if (Enemy3.Count > 0)
        {
            Laser[2].SetActive(true);
            Laser[2].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            Laser[2].GetComponent<LineRenderer>().SetPosition(1, Enemy3[0].transform.position + new Vector3(0, 1f, 0));
        }
        if (Enemy4.Count > 0)
        {
            Laser[3].SetActive(true);
            Laser[3].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            Laser[3].GetComponent<LineRenderer>().SetPosition(1, Enemy4[0].transform.position + new Vector3(0, 1f, 0));
        }
    }
    void StartScane()
    {
        ScaneColdDone = false;
        Enemy = Physics.OverlapSphere(transform.position, ScaneRange, layer);
        ScaneAnimator.SetBool("turnONscan", true);
        if (Enemy.Length > 0)
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (Enemy[i].GetComponent<EnemyEffect>())
                {
                    switch (Enemy[i].GetComponent<EnemyEffect>().Effect)
                    {
                        case EnemyEffect.EnemyEffectState.thunder:
                            Enemy1.Add(Enemy[i]);
                            break;
                        case EnemyEffect.EnemyEffectState.Sticky:
                            Enemy2.Add(Enemy[i]);
                            break;
                        case EnemyEffect.EnemyEffectState.fast:
                            Enemy3.Add(Enemy[i]);
                            break;
                        case EnemyEffect.EnemyEffectState.Invisible:
                            Enemy4.Add(Enemy[i]);
                            break;

                    }
                }
                else
                {
                    Switch.Add(Enemy[i]);
                }
            }
            if (Enemy1.Count > 0)
            {
                StartCoroutine(ShowUiInfo(Info_UI[0], findObj[0].gameObject));
                Info_UI[0].GetComponent<UI_followObj>().worldPos = Enemy1[0].gameObject;
                findObj[0].target = Enemy1[0].transform;
                Enemy1[0].transform.GetChild(0).GetChild(0).gameObject.layer = 10;
            }
            if (Enemy2.Count > 0)
            {
                StartCoroutine(ShowUiInfo(Info_UI[1], findObj[1].gameObject));
                Info_UI[1].GetComponent<UI_followObj>().worldPos = Enemy2[0].gameObject;
                findObj[1].target = Enemy2[0].transform;
                Enemy2[0].transform.GetChild(0).GetChild(0).gameObject.layer = 10;
            }
            if (Enemy3.Count > 0)
            {
                StartCoroutine(ShowUiInfo(Info_UI[2], findObj[2].gameObject));
                Info_UI[2].GetComponent<UI_followObj>().worldPos = Enemy3[0].gameObject;
                findObj[2].target = Enemy3[0].transform;
                Enemy3[0].transform.GetChild(0).GetChild(0).gameObject.layer = 10;
            }
            if (Enemy4.Count > 0)
            {
                StartCoroutine(ShowUiInfo(Info_UI[3], findObj[3].gameObject));
                Info_UI[3].GetComponent<UI_followObj>().worldPos = Enemy4[0].gameObject;
                findObj[3].target = Enemy4[0].transform;
                Enemy4[0].transform.GetChild(0).GetChild(0).gameObject.layer = 10;
            }
            if (Switch.Count > 0)
            {
                StartCoroutine(ShowUiInfo(Info_UI[4], null));
                Info_UI[4].GetComponent<UI_followObj>().worldPos = Switch[0].gameObject;
            }
            if (Enemy[0].GetComponent<EnemyEffect>())
            {
                switch (Enemy[0].GetComponent<EnemyEffect>().Effect)
                {
                    case EnemyEffect.EnemyEffectState.fast:
                        takeEffect.NowEffectID = 2;
                        SpeedText.SetActive(true);
                        break;
                    case EnemyEffect.EnemyEffectState.Invisible:
                        takeEffect.NowEffectID = 3;
                        break;
                    case EnemyEffect.EnemyEffectState.Sticky:
                        takeEffect.NowEffectID = 1;
                        break;
                    case EnemyEffect.EnemyEffectState.thunder:
                        takeEffect.NowEffectID = 0;
                        break;
                }
            }
            StartCoroutine(CloseEffect(5f));
        }
        else
        {
            StartCoroutine(CloseEffect(3f));
        }
    }
    IEnumerator ShowUiInfo(GameObject UI, GameObject FindUI)
    {
        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        if (FindUI)
            FindUI.SetActive(true);
    }
    IEnumerator CloseEffect(float Time)
    {
        yield return new WaitForSeconds(Time);
        for (int i = 0; i < findObj.Length; i++)
        {
            findObj[i].target = null;
            findObj[i].arrows.gameObject.SetActive(false);
        }
        for (int i = 0; i < Info_UI.Length - 1; i++)
        {
            Info_UI[i].SetActive(false);
            Laser[i].SetActive(false);
        }
        Info_UI[4].SetActive(false);
        StartCoroutine(ScaneCold());
        ScaneAnimator.SetBool("turnONscan", false);
        if (Enemy1.Count > 0)
            Enemy1[0].transform.GetChild(0).GetChild(0).gameObject.layer = 9;
        if (Enemy2.Count > 0)
            Enemy2[0].transform.GetChild(0).GetChild(0).gameObject.layer = 9;
        if (Enemy3.Count > 0)
            Enemy3[0].transform.GetChild(0).GetChild(0).gameObject.layer = 9;
        if (Enemy4.Count > 0)
            Enemy4[0].transform.GetChild(0).GetChild(0).gameObject.layer = 9;

        Array.Clear(Enemy, 0, Enemy.Length);
        Enemy1.Clear();
        Enemy2.Clear();
        Enemy3.Clear();
        Enemy4.Clear();
        Switch.Clear();
    }
    IEnumerator ScaneCold()
    {
        yield return new WaitForSeconds(ColdTime);
        ScaneColdDone = true;
    }
}
