using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRun : MonoBehaviour
{

    public Material mms;
    Texture2D t2d;
    int count = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Demo());
    }


    IEnumerator Demo()
    {
        t2d = Resources.Load<Texture2D>("Monitor/LoadingIcon/frame-" + count);
        mms.SetTexture("_PlayerMonitor", t2d);

        count++;
    

        if(count>=30)
        {
            count = 1;
        }

        yield return new WaitForSeconds(0.04f);

    }
}
