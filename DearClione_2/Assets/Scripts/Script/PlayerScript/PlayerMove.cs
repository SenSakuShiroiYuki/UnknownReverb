using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController m_rigidbody;
    public Transform Cam;
    public float MoveSpeed;
    public float AddSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private void Start()
    {
        m_rigidbody = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        Vector3 movement = new Vector3(h , 0, v).normalized;
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            m_rigidbody.Move(moveDir * MoveSpeed * Time.deltaTime);
        }
    }
}
