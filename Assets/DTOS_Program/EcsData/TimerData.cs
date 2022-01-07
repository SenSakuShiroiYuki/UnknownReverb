using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct TimerData : IComponentData
{
    public float Timer;
    public float MaxTime, MineTime;
}
