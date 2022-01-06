using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Animator Anim;
    public Collider[] InRangeObj;
    public Transform PickedPoint;
    public LayerMask layerMask;
    static public bool NextAction;
    public int ItemCount;
    public float RotateSpeed,SearchRange;
    public Quaternion Rotation;
    public Vector3 targetPoint;
    public Vector3 EuAngle;
    float ReBackTime = 2;
    public Material[] itemMaterial;
    public bool StartRotate,BackRotate;
    public GameObject AnimGameobj;
    void Update()
    {
        ChangeMaterial();
        PlayerRotate();
        InRangeObj = Physics.OverlapSphere(transform.position, SearchRange, layerMask);
        if (InRangeObj.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && ItemCount < 3 && NextAction == false)
            {
                Rotation = transform.rotation;
                EuAngle = transform.eulerAngles;
                targetPoint = InRangeObj[0].gameObject.transform.parent.position;
                if (PickedPoint.childCount<1)
                {
                    StartCoroutine(NextAct(InRangeObj[0].transform.parent.gameObject));
                    AnimGameobj = InRangeObj[0].transform.parent.gameObject;
                    StartRotate = true;
                    BackRotate = false;
                }
                else
                {
                    StartCoroutine(ItemCountChange(InRangeObj[0].transform.parent.gameObject));
                }
                NextAction = true;
            }
        }
    }
    void ChangeMaterial()
    {
        /*switch(ItemCount)
        {
            case 1:
                PickedPoint.GetChild(0).GetChild(3).GetChild(0).GetComponent<MeshRenderer>().material = itemMaterial[0];
                break;
            case 2:
                PickedPoint.GetChild(0).GetChild(3).GetChild(0).GetComponent<MeshRenderer>().material = itemMaterial[1];
                break;
            case 3:
                PickedPoint.GetChild(0).GetChild(3).GetChild(0).GetComponent<MeshRenderer>().material = itemMaterial[2];
                break;
        }*/
    }
    void PlayerRotate()
    {
        if(StartRotate == true )
        {
            Vector3 target = (targetPoint + new Vector3(0,0.5f,0)) - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, target, RotateSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else if(BackRotate == true)
        {
            ReBackTime -= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Rotation, RotateSpeed * Time.deltaTime);
            if(transform.rotation == Rotation || ReBackTime<=0)
            {
                BackRotate = false;
                ReBackTime = 2;
                transform.rotation = Quaternion.Euler(0, EuAngle.y, 0);
            }
        }
       
    }
    /*void UseItemEffect()
    {
        if (PickedPoint.childCount > 0)
        {
           
        }
    }*/
    public void PickedItemUp(GameObject gameObject)
    {
        gameObject.transform.SetParent(PickedPoint);
        ItemCount += 1;
        gameObject.transform.position = PickedPoint.position;
        StartRotate = false;
        BackRotate = true;
        //gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator NextAct(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        PlayerAnimation.playerAnimation.Grab();
        NextAction = false;
    }
    IEnumerator ItemCountChange(GameObject gameObject)
    {
        yield return new WaitForSeconds(.15f);
        NextAction = false;
        ItemCount += 1;
        Destroy(gameObject);
    }
}
