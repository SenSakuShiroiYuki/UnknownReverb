using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator PlayerAnim;
    static public PlayerAnimation playerAnimation;
    public bool TestGrab, TestThrow;
    private void Awake()
    {
        playerAnimation = this;
    }
    public void Grab()
    {
        PlayerAnim.SetBool("Grab", true);
    }
    public void ReGrab()
    {
        PlayerAnim.SetBool("Grab", false);
    }
    public void Throw()
    {
        PlayerAnim.SetBool("Throw", true);
    }
    public void HaveCount()
    {
        PlayerAnim.SetBool("HaveCount", false);
    }
    public void ReHaveCount()
    {
        PlayerAnim.SetBool("HaveCount", true);
    }
    public void ReThrow()
    {
        PlayerAnim.SetBool("Throw", false);
    }
}
