using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

class Rotato : MonoBehaviour
{
    public int Speed;
}
class RotateSystem : ComponentSystem
{
   /* struct Grup
    {
        public Rotato Rotator;
        public Transform transform;
    }*/
     protected override void OnUpdate()
    {

        Entities.ForEach((Rotator rotator, Transform transform) =>
        {
            transform.Rotate(0, rotator.Speed * Time.DeltaTime, 0);
        });

    }
}

