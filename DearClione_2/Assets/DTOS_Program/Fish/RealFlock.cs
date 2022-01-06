using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RealFlock : ComponentSystem
{
    struct Components
    {
        public EcsFlock ecsFlock;
        public Transform transform;
    }
    protected override void OnUpdate()
    {
        Entities.ForEach((EcsFlock ecsFlock,Transform flockTrans) =>
        {
            flockTrans.transform.Rotate(0,Time.DeltaTime * ecsFlock.rotationSpeed, 0);
            /*ecsFlock.wall = Physics.OverlapSphere(flockTrans.position, .5f, ecsFlock.layer);
            if (ecsFlock.wall.Length > 0)
            {
                if (!ecsFlock.turning)
                {
                    ecsFlock.newGoalPos = flockTrans.position - ecsFlock.wall[0].gameObject.transform.position;
                }
                ecsFlock.turning = true;
            }
            else
            {
                ecsFlock.turning = false;
            }
            if (ecsFlock.turning)
            {
                Vector3 direction = ecsFlock.newGoalPos - flockTrans.position;
                flockTrans.rotation = Quaternion.Slerp(flockTrans.rotation, Quaternion.LookRotation(direction), ecsFlock.rotationSpeed * Time.DeltaTime);
                ecsFlock.speed = Random.Range(ecsFlock.minSpeed, ecsFlock.maxSpeed);
                ecsFlock.anim.speed = ecsFlock.speed;
            }
            else
            {
                if (Random.Range(0, 10) < 1)
                {
                    GameObject[] gos;
                    gos = globalFlock.global.AllFish;
                    Vector3 vcentre = Vector3.zero;
                    Vector3 vavoid = Vector3.zero;
                    float gSpeed = .1f;
                    Vector3 goalPos = globalFlock.global.goalPos;
                    float dist;
                    int groupSize = 0;
                    foreach (GameObject Go in gos)
                    {
                        if (Go != ecsFlock.gameObject)
                        {
                            dist = Vector3.Distance(Go.transform.position, flockTrans.position);
                            if (dist <= ecsFlock.neighbourDistance)
                            {
                                vcentre += Go.transform.position;
                                groupSize++;
                                if (dist < 2.0f)
                                {
                                    vavoid = vavoid + (flockTrans.position - Go.transform.position);
                                }
                                EcsFlock anotherFlock = Go.GetComponent<EcsFlock>();
                                gSpeed = gSpeed + anotherFlock.speed;
                            }
                        }
                    }
                    if (groupSize > 0)
                    {
                        vcentre = vcentre / groupSize + (goalPos - flockTrans.position);
                        ecsFlock.speed = gSpeed / groupSize;
                        ecsFlock.anim.speed = ecsFlock.speed;
                        Vector3 direction = (vcentre + vavoid) - flockTrans.position;
                        if (direction != Vector3.zero)
                        {
                            flockTrans.rotation = Quaternion.Slerp(flockTrans.rotation, Quaternion.LookRotation(direction), ecsFlock.rotationSpeed * Time.DeltaTime);
                        }
                    }
                }
                    
            }
            flockTrans.Translate(0, 0, Time.DeltaTime * ecsFlock.speed);*/
        });
    }
}
