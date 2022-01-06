using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_followObj : MonoBehaviour
{
    [SerializeField]
    public GameObject worldPos;//3D����]�H���^
    [SerializeField]
    RectTransform rectTrans;//UI�����]�p�G������^
    public Vector2 offset;//�����q
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos.transform.position);
        rectTrans.position = Vector3.Lerp(rectTrans.position, screenPos + offset, Speed * Time.deltaTime) ;
    }
}
