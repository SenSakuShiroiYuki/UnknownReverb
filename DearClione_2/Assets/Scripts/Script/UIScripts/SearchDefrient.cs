using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchDefrient : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 1)
            for (int i = 1; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<SelectEffect>().EffectIndex == transform.GetChild(i-1).GetComponent<SelectEffect>().EffectIndex)
                {
                    Destroy(transform.GetChild(i-1).gameObject);
                }
            }
    }
}
