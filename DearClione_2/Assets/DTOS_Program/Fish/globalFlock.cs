using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{
    public float tankSize = 4,tankSize2 = 14;
    public GameObject FishPrefab;
    //public GameObject goalPrefab;
    public static int MaxFish = 200;
    public GameObject[] AllFish = new GameObject[MaxFish];
    public  Vector3 goalPos = Vector3.zero;

    public static globalFlock global;

    private void Awake()
    {
        global = this;
    }
    void Start()
    {
        /*for(int i=0;i<MaxFish;i++)
        {
            Vector3 pos = new Vector3(Random.Range(-5, 15), Random.Range(45, 60), Random.Range(-1, 18));
            AllFish[i] =Instantiate(FishPrefab, pos, Quaternion.identity);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000)<50)
        {
            goalPos = new Vector3(Random.Range(-5, 15), Random.Range(35, 50), Random.Range(-1, 18));           
        }
    }
}
