using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanEffectSwitch : MonoBehaviour
{

    public Camera mainc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ToScanMode()
    {
        UnityEngine.Rendering.Universal.UniversalAdditionalCameraData additionalCameraData = mainc.transform.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();

        additionalCameraData.SetRenderer(2);
    }


    void ToOriMode()
    {
        UnityEngine.Rendering.Universal.UniversalAdditionalCameraData additionalCameraData = mainc.transform.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();

        additionalCameraData.SetRenderer(1);
    }
}
