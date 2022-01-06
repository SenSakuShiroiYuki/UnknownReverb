using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOther : MonoBehaviour
{
    public Animator Explostion;
    public float ExplostionPower, ExplostionRange;
    public GameObject BoomEffect;
    public RespownCube respownCube;
    public GameObject[] Wall;
    public Collider[] InRangeObj, BoomObj;
    public LayerMask layer, layer2,CD;
    public float SearchRange;
    public MoveToTarget toTarget;
    public PlayerTakeEffect takeEffect;
    public bool Sticky;
    public bool Go = true;
    private Rigidbody rb;
    bool InputBoomList = true;
    float Timer = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        takeEffect = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeEffect>();
        Wall = GameObject.FindGameObjectsWithTag("Wall");
    }
    void Update()
    {
        InRangeObj = Physics.OverlapSphere(transform.parent.position, SearchRange, layer);
        BoomObj = Physics.OverlapSphere(transform.parent.position, SearchRange, layer2);
        if (takeEffect.NowEffectID == 1)
        {
            Sticky = true;
        }
        if (transform.parent.parent == null)
        {
            Go = true;
            rb.isKinematic = false;
            if (Go)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 1)
                {
                    Explostion.SetBool("open", true);
                    toTarget.enabled = false;
                    if (Timer <= 0)
                    {
                        Destroy(transform.parent.gameObject, 6.6f);
                        Timer = 10;
                        Go = false;
                    }
                }
            }
            if (BoomObj.Length > 0)
            {
                toTarget.enabled = false;
                Explostion.SetBool("open", true);
                foreach(GameObject collider in Wall)
                {
                    collider.layer = 14;
                }
            }
            else
            {
                if (InRangeObj.Length > 0)
                {
                    if (Sticky == false)
                    {
                        for (int i = 0; i < InRangeObj.Length; i++)
                        {
                            if (InRangeObj[i].gameObject == gameObject)
                            {
                                return;
                            }
                            else
                            {
                                toTarget.enabled = false;
                                Explostion.SetBool("open", true);
                                Destroy(transform.parent.gameObject, 6.6f);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < InRangeObj.Length; i++)
                        {
                            if (InRangeObj[i].gameObject == gameObject || InRangeObj[i].gameObject.tag == "Player")
                            {
                                return;
                            }
                        }
                        transform.parent.SetParent(InRangeObj[0].transform);
                        toTarget.enabled = false;
                        Explostion.SetBool("open", true);
                        Destroy(transform.parent.gameObject, 6.6f);
                    }
                }
            }
        }
    }
    public void ExplostionFunction()
    {
        Go = false;
        toTarget.enabled = false;
        if (Wall.Length > 0)
        {
            foreach (GameObject BoomWall in Wall)
            {
                Rigidbody rb = BoomWall.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(ExplostionPower, transform.position, ExplostionRange);
                    Destroy(rb.gameObject, 5);
                }

            }
            print("Boom");
            Destroy(transform.parent.gameObject, 6.6f);
        }
    }
}
