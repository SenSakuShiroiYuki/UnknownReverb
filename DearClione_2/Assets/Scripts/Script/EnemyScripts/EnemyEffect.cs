using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    public EnemyEffectState Effect;
    
    public enum EnemyEffectState
    {
        thunder,
        Sticky,
        Invisible,
        fast
    }
}
    
