using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjConnectToUI : MonoBehaviour
{
    public float Distence;
    public GameObject Player, MyCave;
    //public UI_ItemManager ConnectUI;
    public Sprite Myimage, MyBg;
    public string TagName, ObjName;
    public Vector3 EndPoint;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //MyCave = transform.GetChild(0).gameObject;
        //transform.rotation = Quaternion.identity;
    }
    private void Update()
    {
        if (GetComponent<CapsuleCollider>())
        {
            if (Vector3.Distance(transform.position, EndPoint) <= .5f)
            {
                GetComponent<CapsuleCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                GetComponent<CapsuleCollider>().isTrigger = true;
            }
        }
        else if(GetComponent<BoxCollider>())
        {
            if (Vector3.Distance(transform.position, EndPoint) <= 1.5f)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
}
