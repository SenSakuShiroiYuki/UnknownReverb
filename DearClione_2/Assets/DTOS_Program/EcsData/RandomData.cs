using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct RandomData : IComponentData
{
    public float x;
    public float y;
    public float z;
}
