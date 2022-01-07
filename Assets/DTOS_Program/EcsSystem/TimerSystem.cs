using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class TimerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref TimerData timerData) => {
            if(timerData.Timer>0)
            {
                timerData.Timer -= deltaTime;
                return;
            }
            timerData.Timer = UnityEngine.Random.Range(timerData.MineTime,timerData.MaxTime);
        }).Run();
    }
}
