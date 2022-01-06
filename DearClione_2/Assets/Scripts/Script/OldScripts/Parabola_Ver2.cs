using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola_Ver2 : MonoBehaviour
{
    public Rigidbody projectile;
    public GameObject cursor;
    public Transform shootPoint, PickedPoiint;
    public LayerMask layer;
    public LineRenderer lineVisual;
    public int lineSegment;
    public Vector3 FinalHit;
    private new Camera camera;
    public bool EndShoot;
    private void Start()
    {
        lineVisual.positionCount = lineSegment;
        camera = Camera.main;
    }
    private void Update()
    {
        //Debug.Log(PickUp.NextAction);
       // if (PickedPoiint.childCount > 0)
        {
            if ((Input.GetKey(KeyCode.E)/* || EndShoot == false) && PickUp.NextAction == false*/))
            {
                LaunchProjectile();
            }
            else
            {
                lineVisual.enabled = false;
            }
        }
    }
    public Ray TRay;
    public RaycastHit Thit;
    void LaunchProjectile()
    {
        lineVisual.enabled = true;
        EndShoot = false;
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            //cursor.SetActive(true);
            if (Physics.Raycast(TRay, out Thit, 100))
            {
                if (Thit.point != hit.point)
                {
                    //cursor.transform.position = Thit.point/*.normalized+ Vector3.up * 1f*/;
                    Vector3 vo = CaculateVelocty(Thit.point, shootPoint.position, 1);
                    visualize(vo);
                    //transform.rotation = Quaternion.LookRotation(vo);
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        PickUp.NextAction = true;
                        lineVisual.enabled = false;
                        StartCoroutine(ContinuEnd());
                        if (PickedPoiint.childCount > 0)
                        {
                            Rigidbody obj = PickedPoiint.GetChild(0).GetComponent<Rigidbody>();
                            obj.useGravity = true;
                            //obj.GetComponent<ObjConnectToUI>().EndPoint = Thit.point;
                            obj.transform.SetParent(null);
                            obj.velocity = vo;
                        }
                    }
                }
                else
                {
                   // cursor.transform.position = hit.point/*.normalized+ Vector3.up * 1f*/;
                    Vector3 vo = CaculateVelocty(hit.point, shootPoint.position, 1);
                    visualize(vo);
                    //transform.rotation = Quaternion.LookRotation(vo);
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        PickUp.NextAction = true;
                        lineVisual.enabled = false;
                        StartCoroutine(ContinuEnd());
                        if (PickedPoiint.childCount > 0)
                        {
                            Rigidbody obj = PickedPoiint.GetChild(0).GetComponent<Rigidbody>();
                            obj.useGravity = true;
                            //obj.GetComponent<ObjConnectToUI>().EndPoint = hit.point;
                            obj.transform.SetParent(null);
                            obj.velocity = vo;
                        }
                    }
                }
            }
            TRay = new Ray(shootPoint.position, hit.point - shootPoint.position);
            if (Physics.Raycast(TRay, out Thit, 100))
            {
                //Debug.DrawRay(shootPoint.position, hit.point - shootPoint.position, Color.red);
            }
        }
    }
    IEnumerator ContinuEnd()
    {
        yield return new WaitForSeconds(.5f);
        PickUp.NextAction = false;
        EndShoot = true;
    }
    void visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CaculatePosInTime(vo, i / (float)lineSegment);
            lineVisual.SetPosition(i, pos);
        }
    }
    Vector3 CaculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
    Vector3 CaculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;
        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;
        result.y = sY;
        return result;
    }
}
