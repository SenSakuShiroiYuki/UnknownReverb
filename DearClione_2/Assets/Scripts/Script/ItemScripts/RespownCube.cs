using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespownCube : MonoBehaviour
{
    public Transform OtherRespown;
    public float RespownTime;
    public Transform TargetPoint;
    public GameObject Cube;
    public void Call()
    {
       
        StartCoroutine(Res());
    }
    IEnumerator Res()
    {
        yield return new WaitForSeconds(RespownTime);
        if (transform.GetChild(2).childCount > 0)
        {
            GameObject GG = Instantiate(Cube, OtherRespown.position, Quaternion.identity, OtherRespown);
            GG.transform.localPosition = new Vector3(0, -.238f, 0);
            GG.transform.localRotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else
        {
            GameObject GG = Instantiate(Cube, TargetPoint.position, Quaternion.identity, TargetPoint);
            GG.transform.localPosition = new Vector3(0, -.238f, 0);
            GG.transform.localRotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
    }
}
