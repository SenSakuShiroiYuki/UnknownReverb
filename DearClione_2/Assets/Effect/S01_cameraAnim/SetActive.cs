using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject ob;



    void turnOn()
    {
        ob.SetActive(true);
    }

    void turnOff()
    {
        ob.SetActive(false);
    }
}
