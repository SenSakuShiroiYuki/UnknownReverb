using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEffect : MonoBehaviour
{
    public int EffectIndex;
    public GameObject Player;
    public void Click()
    {
        switch (EffectIndex)
        {
            case 0:
                Debug.Log("Have Thund Attack");
                Player.GetComponent<PlayerTakeEffect>().NowEffectID = 0;
                break;
            case 1:
                Debug.Log("Can Sticky in Other Object");
                Player.GetComponent<PlayerTakeEffect>().NowEffectID = 1;
                break;
            case 2:
                Debug.Log("Can Move Fast");
                Player.GetComponent<PlayerTakeEffect>().NowEffectID = 2;
                break;
            case 3:
                Debug.Log("Enemy can`t see you");
                Player.GetComponent<PlayerTakeEffect>().NowEffectID = 3;
                break;
        }
    }
}
