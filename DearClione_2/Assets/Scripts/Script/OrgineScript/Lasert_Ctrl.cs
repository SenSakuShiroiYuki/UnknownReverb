using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasert_Ctrl : MonoBehaviour
{
    public float InputDamage;
    public LineRenderer line;
    public Transform FirePoint,FireEffect,Ligh;
    float Damage;
    private void Update()
    {
        FireEffect.gameObject.SetActive(line.enabled);
        Ligh.gameObject.SetActive(line.enabled);
        RaycastHit hit;
        if(Physics.Raycast(FirePoint.position, transform.forward,out hit))
        {
            FireEffect.position = Vector3.Lerp(FireEffect.position, hit.point, 20 * Time.deltaTime);
            Ligh.position = Vector3.Lerp(Ligh.position, hit.point + new Vector3(0,0,-.2f), 20 * Time.deltaTime);
            line.SetPosition(0, FirePoint.position);
            line.SetPosition(1, hit.point);
            if(hit.collider.CompareTag("Player") && line.enabled)
            {
                Damage += InputDamage * Time.deltaTime;
                hit.collider.GetComponent<Player_Info>().Player_Health -= Damage * Time.deltaTime;
            }
            else
            {
                Damage = 0;
            }
        }
    }
}
