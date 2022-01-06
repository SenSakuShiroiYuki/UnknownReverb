using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lmpulse_Contral : MonoBehaviour
{
    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    public bool Lmpulsing;
    void Start()
    {
        MyInpulse = GetComponent<Cinemachine.CinemachineCollisionImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lmpulsing == true)
            MyInpulse.GenerateImpulse();
    }
}
