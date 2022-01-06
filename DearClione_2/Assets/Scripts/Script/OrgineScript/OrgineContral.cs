using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgineContral : MonoBehaviour
{
    bool Go = false;
    private void Update()
    {
        if(Go)
        {
            transform.parent.Translate(Vector3.down * Time.deltaTime * 1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LightinfBall"))
        {
            Go = true;
            Destroy(transform.parent.gameObject, 10);
        }
    }
}
