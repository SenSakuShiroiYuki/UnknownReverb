using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCam : MonoBehaviour
{
    public CinemachineBrain brain;
    public GameObject V1, V2;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            brain.m_DefaultBlend.m_Time = 2;
            V2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            V2.SetActive(false);
        }
    }
}
