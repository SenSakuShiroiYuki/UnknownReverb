using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnentToPlayer : MonoBehaviour
{
    public PickUp pickUp;
    public GameObject[] NumIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(pickUp.ItemCount)
        {
            case 0:
                NumIndex[0].SetActive(true);
                NumIndex[1].SetActive(false);
                NumIndex[2].SetActive(false);
                NumIndex[3].SetActive(false);
                break;
            case 1:
                NumIndex[1].SetActive(true);
                NumIndex[0].SetActive(false);
                NumIndex[2].SetActive(false);
                NumIndex[3].SetActive(false);
                break;
            case 2:
                NumIndex[2].SetActive(true);
                NumIndex[0].SetActive(false);
                NumIndex[1].SetActive(false);
                NumIndex[3].SetActive(false);
                break;
            case 3:
                NumIndex[3].SetActive(true);
                NumIndex[0].SetActive(false);
                NumIndex[1].SetActive(false);
                NumIndex[2].SetActive(false);
                break;
        }
    }
}
