using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Video;

public class OpOnly : MonoBehaviour
{
    [SerializeField]
    private GameObject BGPlent,OceanAudio,PlayerInfo;
    [SerializeField]
    private VideoPlayer Video;
    [SerializeField]
    private Rigidbody PlayerRb;
    [SerializeField]
    private CinemachineVirtualCamera OpABC;
    [SerializeField]
    private CinemachineBrain OpABC_Brain;
    [SerializeField]
    private Transform Lightpoint, Dolly,Player;
    [SerializeField]
    private Animator OpAnim, PlayerAnim,MainCamAnim,UDAnim;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Player.position = new Vector3(256.5f, -0.03f, -180.2f);
            Player.eulerAngles = new Vector3(0, 0, 0);
            Video.gameObject.SetActive(false);
            BGPlent.SetActive(false);
            OceanAudio.SetActive(true);
            Lightpoint.gameObject.SetActive(true);
            OpABC.gameObject.SetActive(false);
            Destroy(OpAnim);
            OpABC_Brain.m_DefaultBlend.m_Time = 5;
            PlayerInfo.SetActive(true);
            UDAnim.enabled = true;
            Lightpoint.gameObject.SetActive(false);
            PlayerRb.isKinematic = false;
            PlayerRb.useGravity = true;
            PlayerAnim.enabled = true;
            Destroy(Dolly.gameObject);
            Destroy(this);
        }
        if (Video.time >= 36.2f)
        {
            Video.gameObject.SetActive(false);
            BGPlent.SetActive(false);
            OpAnim.enabled = true;
            MainCamAnim.enabled =true;
            OceanAudio.SetActive(true);
        }
    }
    public void LookLight()
    {
        Lightpoint.gameObject.SetActive(true);
        OpABC.gameObject.SetActive(false);
        Destroy(OpAnim);
        StartCoroutine(SetVcam());
    }
    IEnumerator SetVcam()
    {
        OpABC_Brain.m_DefaultBlend.m_Time = 5;
        Destroy(Dolly.gameObject);
        yield return new WaitForSeconds(4);
        PlayerInfo.SetActive(true);
        UDAnim.enabled = true;
        Lightpoint.gameObject.SetActive(false);
        PlayerRb.isKinematic = false;
        PlayerRb.useGravity = true;
        PlayerAnim.enabled = true;
        Destroy(this);
    }

}
