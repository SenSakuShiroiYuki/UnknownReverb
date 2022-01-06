using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class POSTCtrol_lightning : MonoBehaviour
{
    public Volume vo1;

    public Bloom cas;
    // Start is called before the first frame update
    void Start()
    {
        vo1.profile.TryGet(out cas);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void high()
    {
        cas.intensity.Override(3.6f);
    }
    void low()
    {
        cas.intensity.Override(1.2f);
    }


}
