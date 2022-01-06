using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveForwardSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.WithAny<FishTag>().WithNone<PlayerTag>().ForEach((ref Translation pos, in MoveData moveDataIn, in Rotation rotation) =>
        {
            //moveData.speed = UnityEngine.Random.Range(1, 3);
            float3 forwardDirection = math.forward(rotation.Value);
            pos.Value += forwardDirection * moveDataIn.speed * deltaTime;

        }).ScheduleParallel();
        Entities.ForEach((ref MoveData moveData) =>
        {
            moveData.speed = UnityEngine.Random.Range(1.0f, 4.0f);
        }).Run();
    }
}
