using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplostionAnimCtrl : MonoBehaviour
{
    public TouchOther TouchOther;
   public void CallExplostion()
    {
        TouchOther.ExplostionFunction();
    }
}
