using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [Header("-----�o�g�O��-----")]
    public float Power = 10;
    [Header("-----�o�g����-----")]
    public float Angle = 45;
    [Header("-----���O-----")]
    public float Gravity = -10;
    public Rigidbody rb;
    private Vector3 MoveSpeed;
    private Vector3 GritySpeed = Vector3.zero;
    private float dTime;
    
    void Start()
    {
       //Destroy(transform.parent.gameObject, 10);
        MoveSpeed = Quaternion.Euler(new Vector3(-Angle, 0, 0)) * Vector3.forward * Power;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //transform.parent.Translate(transform.parent.forward * Power * Time.fixedDeltaTime);
        transform.parent.GetComponent<Rigidbody>().MovePosition(transform.parent.position + transform.parent.forward * Power * Time.fixedDeltaTime);
    }
}
