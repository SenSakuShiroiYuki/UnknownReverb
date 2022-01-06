using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using System.Collections;
using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;

public class RandomSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref RandomData randomData) =>
        {
           // if(deltaTime>10)
            {
                deltaTime = 0;
                randomData.x = UnityEngine.Random.Range(240, 270);
                randomData.y = UnityEngine.Random.Range(0, 0);
                randomData.z = UnityEngine.Random.Range(-134, -20);
            }
        }).Run();
    }
}
