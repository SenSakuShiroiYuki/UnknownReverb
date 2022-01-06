using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OP_b2c : MonoBehaviour
{


    public Volume vo1;
    public ColorAdjustments cad;

    bool open=false;
    float sat;
    float pose;
    float cal = 0;
    // Start is called before the first frame update
    void Start()
    {
        vo1.profile.TryGet(out cad);

    }

    // Update is called once per frame
    void Update()
    {




        if (open==true)
        {
            cal += Time.deltaTime;

            sat = Mathf.Lerp(-100f, 8f, 0.2f * cal);
            pose = Mathf.Lerp(-1f, 0f, 0.2f * cal);

            cad.saturation.Override(sat);
            cad.postExposure.Override(pose);


            if(sat>=7.98f)
            {
                cad.saturation.Override(8f);
                cad.postExposure.Override(0f);
                open = false;
            }
        }
        
    }



    void openChange()
    {
        open = true;
    }


    void  sst()
    {
        cad.saturation.Override(-100f);
        cad.postExposure.Override(-1f);
    }
}
