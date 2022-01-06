using Unity.Entities;
using System;
using UnityEngine;

public class InputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MoveData moveData, in InputData inputData) =>
        {
            bool isUpKey = Input.GetKey(inputData.upKey);
            bool isDownKey = Input.GetKey(inputData.downKey);
            bool isRightKey = Input.GetKey(inputData.rightKey);
            bool isLeftKey = Input.GetKey(inputData.leftKey);

            moveData.direction.x = Convert.ToInt32(isRightKey);
            moveData.direction.x -= Convert.ToInt32(isLeftKey);
            moveData.direction.z = Convert.ToInt32(isUpKey);
            moveData.direction.z -= Convert.ToInt32(isDownKey);

        }).Run();
    }
}


