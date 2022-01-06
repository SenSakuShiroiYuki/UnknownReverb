using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSetting : MonoBehaviour
{
    public PushItem push;
    public PickUp pickUp;


    void PickUpItem()
    {
        if (pickUp.AnimGameobj)
        {
            pickUp.PickedItemUp(pickUp.AnimGameobj);
            PlayerAnimation.playerAnimation.ReGrab();
        }
    }
    public void ThrowCube()
    {
        push.Push();
    }
}
