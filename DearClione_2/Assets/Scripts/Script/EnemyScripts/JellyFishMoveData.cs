using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMoveData : MonoBehaviour
{
    [Header("範圍")]
    public float tankSize = 2.5f;
    [Header("魚種")]
    public GameObject fishPrefab;
    [Header("最多幾隻魚")]
    public int numFish = 10;
    [Header("-------------------以下別動--------------------")]
    public GameObject goalPrefab;
    public GameObject[] AllFish;
    public Transform FishWorld;
    public Vector3 goalPos = Vector3.zero;
    float x, y, z;
    static public JellyFishMoveData data;
    public int Mods;

    private void Awake()
    {
        data = this;
    }
    private void Start()
    {
        AllFish = new GameObject[numFish];
        if (fishPrefab != null)
        {
            if (Mods == 0)
                for (int i = 0; i < numFish; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));
                    GameObject FishPre = AllFish[i] = Instantiate(fishPrefab, FishWorld);
                    FishPre.transform.rotation = Quaternion.identity;
                    FishPre.transform.localPosition = pos;
                }
            else
                for (int i = 0; i < numFish; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), 0, Random.Range(-tankSize, tankSize));
                    GameObject FishPre = AllFish[i] = Instantiate(fishPrefab, FishWorld);
                    FishPre.transform.rotation = Quaternion.identity;
                    FishPre.transform.localPosition = pos;
                }
        }
        else
        {
            AllFish = GameObject.FindGameObjectsWithTag("JellyFishEnemy");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50)
        {
            if (Mods == 0)
            {
                x = Random.Range(-tankSize, tankSize);
                y = Random.Range(-tankSize, tankSize);
                z = Random.Range(-tankSize, tankSize);
                goalPos = new Vector3(x, 0, z);
                goalPrefab.transform.localPosition = goalPos;
            }
            else
            {
                x = Random.Range(-tankSize, tankSize);
                y = 0;
                z = Random.Range(-tankSize, tankSize);
                goalPos = new Vector3(x, 0, z);
                goalPrefab.transform.localPosition = goalPos;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, new Vector3(tankSize * 2, tankSize * 2, tankSize * 2));
    }
}
