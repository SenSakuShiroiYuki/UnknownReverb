using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMoveSystem : MonoBehaviour
{
    public LayerMask layer,BoomLayer;
    public Collider[] PlayerCollider,Boom;
    public Transform Arrow,JellyFishBody;
    public float speed = .1f, AttackTime, SearchRange,ReTime;
    float rotationSpeed = 4;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 1.5f;
    public bool Attacked;
    bool turning = false;
    public int testNum;
    public EnemyState enemyState;
    public GameObject JellyLighting;
    /// <summary>
    ///
    /// </summary>
    public enum EnemyState
    {
        Normal,
        Dead,
        Stop
    }
    private void Start()
    {
        speed = Random.Range(.1f, .3f);
        AttackTime = Random.Range(5, 10);
    }
    private void Update()
    {
        Boom = Physics.OverlapSphere(transform.position, SearchRange*2, BoomLayer);
        JellyFishBody.rotation = Quaternion.Lerp(JellyFishBody.rotation,Arrow.rotation, rotationSpeed * Time.deltaTime);
        if (Boom.Length>0)
        {
            enemyState = EnemyState.Stop;
        }
        else
        {
            if(enemyState == EnemyState.Stop)
            {
                ReTime -= Time.deltaTime;
                if(ReTime<=0)
                {
                    ReTime = 10;
                    enemyState = EnemyState.Normal;
                }
            }
        }
        if (enemyState == EnemyState.Normal)
        {
            if (Attacked == false)
            {
                StartCoroutine(Attack());
                Attacked = true;
            }
            if (Vector3.Distance(transform.localPosition, Vector3.zero) >= JellyFishMoveData.data.tankSize)
            {
                turning = true;
            }
            else
            {
                turning = false;
            }
            if (turning)
            {
                Vector3 direction = Vector3.zero - transform.localPosition;
                Arrow.rotation = Quaternion.Slerp(Arrow.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
                speed = Random.Range(.1f, .3f);
            }
            else
            {
                if (Random.Range(0, 5) < 1)
                {
                    ApplyRules();
                }
            }
            transform.Translate(Arrow.forward * speed * Time.deltaTime);
        }

    }
    void ApplyRules()
    {
        GameObject[] gos;
        gos = JellyFishMoveData.data.AllFish;
        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;
        Vector3 goalPos = JellyFishMoveData.data.goalPos;
        float dist;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != gameObject)
            {
                dist = Vector3.Distance(go.transform.localPosition, transform.localPosition);
                if (dist <= neighbourDistance)
                {
                    vcenter += go.transform.localPosition;
                    groupSize++;
                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (transform.localPosition - go.transform.localPosition);
                    }
                    JellyFishMoveSystem anotherFlock = go.GetComponent<JellyFishMoveSystem>();
                    if (gSpeed < .8f)
                        gSpeed += anotherFlock.speed;
                }

            }
        }
        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - transform.localPosition);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.localPosition;
            if (direction != Vector3.zero)
            {
                Arrow.rotation = Quaternion.Slerp(Arrow.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator Attack()
    {
        testNum += 1;
        yield return new WaitForSeconds(AttackTime);
        JellyLighting.SetActive(true);
        StartCoroutine(ReLighting());
        PlayerCollider = Physics.OverlapSphere(transform.position, SearchRange, layer);
        if (PlayerCollider.Length > 0)
        {
            if(PlayerCollider[0].GetComponent<PlayerMove_v2>().playerState != PlayerMove_v2.PlayerState.Stop)
            {
                PlayerCollider[0].GetComponent<Player_Info>().Player_Health -= 10;
                PlayerCollider[0].GetComponent<PlayerMove_v2>().playerState = PlayerMove_v2.PlayerState.Stop;
                PlayerCollider[0].GetComponent<PlayerMove_v2>().StopTime = 5 * .5f;
            }
        }
        Attacked = false;
    }
    IEnumerator ReLighting()
    {
        yield return new WaitForSeconds(2);
        JellyLighting.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, SearchRange);
    }
}
