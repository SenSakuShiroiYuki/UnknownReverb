using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcsFlock : MonoBehaviour
{
    public Collider[] wall;
    public LayerMask layer;
    public float speed = 0.001f;
    public float rotationSpeed = 4;
    public float minSpeed = .8f;
    public float maxSpeed = 2.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    public float neighbourDistance = 3.0f;
    public Vector3 newGoalPos;
    public bool turning = false;
    public Animator anim;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        //anim = transform.GetChild(0).GetComponent<Animator>();
       // anim.speed = speed;
    }
}
