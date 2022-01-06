using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.
           WithAll<PlayerTag>().
                ForEach((ref Translation pos, in MoveData moveData, in RandomData randomData, in TimerData timerData) =>
                {
                    float3 normalizedDir = math.normalizesafe(moveData.direction);
                    //pos.Value += normalizedDir * moveData.speed * deltaTime;
                    if (timerData.Timer <= 0)
                        pos.Value = new float3(randomData.x, randomData.y, randomData.z);

                }).Run();
    }
}
