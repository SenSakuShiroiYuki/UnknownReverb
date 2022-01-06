using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class FaceDirction : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.
            WithAll<PlayerTag>().
            ForEach((ref Rotation rotation, in Translation pos, in MoveData moveData) =>
            {
                FaceDirection(ref rotation, moveData);

            }).Schedule();
        Entities.
            WithNone<PlayerTag>().
            WithAll<FishTag>().ForEach((ref MoveData moveData,ref Rotation rot,in Translation pos,in TargetData targetData) =>
            {
                ComponentDataFromEntity<Translation> allTranslation = GetComponentDataFromEntity<Translation>(true);
               
                Translation targetPos = allTranslation[targetData.targetEntity];
                float3 dirToTarget = targetPos.Value - pos.Value;
                moveData.direction = dirToTarget;
                FaceDirection(ref rot, moveData);

            }).Run();
    }

    private static void FaceDirection(ref Rotation rotation, MoveData moveData)
    {
        if (!moveData.direction.Equals(float3.zero))
        {
            quaternion targetRotation = quaternion.LookRotationSafe(moveData.direction, math.up());
            rotation.Value = math.slerp(rotation.Value, targetRotation, moveData.turnSpeed);
        }
    }
}
