using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSetting : MonoBehaviour
{
    public LayerMask layer;
    public PushItem pushItem;
    public Transform Follow;
    private void Start()
    {
        pushItem = GameObject.FindGameObjectWithTag("Player").GetComponent<PushItem>();
        Follow = GameObject.Find("Player").transform.GetChild(4);
    }
    void Update()
    {
        if (transform.parent.parent != null)
        {
            if (transform.parent.parent == Follow)
                transform.localRotation = Quaternion.identity;
        }
        if (transform.parent.parent == null && pushItem.CanChange == true)
        {
            gameObject.layer = 7;
        }
        else
        {
            if (transform.parent.parent == Follow)
                gameObject.layer = 8;
        }
    }
    IEnumerator ResetCanChange()
    {
        yield return new WaitForSeconds(.1f);
        pushItem.CanChange = false;
    }
}
