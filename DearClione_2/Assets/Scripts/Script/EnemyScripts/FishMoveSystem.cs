using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoveSystem : MonoBehaviour
{
    public Transform Arrow, JellyFishBody;
    public float speed = .1f;
    float rotationSpeed = 4;
    public float MinSpeed = .5f;
    public float MaxSpeed = 1.5f;
    private Vector3 averageHeading;
    private Vector3 averagePosition;
    public Vector3 newGoalPos;
    float neighbourDistance = 1.5f;
    public bool Attacked;
    bool turning = false;
    public int testNum;
    public GameObject JellyLighting;
    public Collider[] Stop;
    public float StopSerchRange;
    public LayerMask layer;
    bool InWall, T;
    /// <summary>
    ///
    /// </summary>

    private void Start()
    {
        speed = Random.Range(MinSpeed, MaxSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (InWall == true)
        {
            other.gameObject.transform.parent = transform.parent;
            if (!turning)
            {
                newGoalPos = transform.localPosition - other.gameObject.transform.localPosition;
            }
            turning = true;
            T = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (InWall == true)
        {
            turning = false;
            T = false;
            other.gameObject.transform.parent = null;
        }

    }
    private void Update()
    {
        JellyFishBody.rotation = Quaternion.Lerp(JellyFishBody.rotation, Arrow.rotation, rotationSpeed * Time.deltaTime);
        //Stop = Physics.OverlapSphere(transform.localPosition, StopSerchRange, layer);
        if (Vector3.Distance(transform.localPosition, newGoalPos) >= JellyFishMoveData.data.tankSize)
        {
            turning = true;
        }
        else
        {

            turning = false;
        }
        if (turning)
        {
            Vector3 direction = newGoalPos - transform.localPosition;
            Arrow.rotation = Quaternion.Slerp(Arrow.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            speed = Random.Range(MinSpeed, MaxSpeed);
        }
        else
        {
            if (Random.Range(0, 10) < 1)
            {
                ApplyRules();
            }
        }
        transform.Translate(Arrow.forward * speed * Time.deltaTime);

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
                    if (dist < 2f)
                    {
                        vavoid = vavoid + (transform.localPosition - go.transform.localPosition);
                    }
                    FishMoveSystem anotherFlock = go.GetComponent<FishMoveSystem>();
                    //if (gSpeed < 2f)
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
}
