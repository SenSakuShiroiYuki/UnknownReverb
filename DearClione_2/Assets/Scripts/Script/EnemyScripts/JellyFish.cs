using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    JellyFishMoveSystem JellyFishMoveSystem;
    MeshRenderer meshRenderer;
    float seedtime;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        JellyFishMoveSystem = transform.parent.parent.GetComponent<JellyFishMoveSystem>();
        seedtime += Random.Range(1.0f, 5.0f);
    }
    void Update()
    {
        seedtime += Time.deltaTime * JellyFishMoveSystem.speed * 2;
        meshRenderer.material.SetFloat("_TimeSetp", seedtime);
    }
}
