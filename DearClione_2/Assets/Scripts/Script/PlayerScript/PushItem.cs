using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    public PickUp pickUp;
    public Transform Handle,ThrowPoint;
    public Animator PlayerAnim;
    public bool CanChange;
    private void Update()
    {
        if (pickUp.BackRotate == false && pickUp.StartRotate == false && PickUp.NextAction == false)
        {
            if (pickUp.ItemCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerAnimation.playerAnimation.Throw();
                }
            }
        }
    }
    public void Push()
    {
        if (pickUp.ItemCount > 1)
        {
            pickUp.ItemCount -= 1;
            GameObject game = Instantiate(Handle.GetChild(0).gameObject, ThrowPoint.position, ThrowPoint.rotation);
            game.transform.GetChild(3).GetChild(0).GetComponent<MeshRenderer>().material = pickUp.itemMaterial[0];
            game.transform.GetChild(3).GetComponent<MoveToTarget>().enabled = true;
            CanChange = false;
            StartCoroutine(enumerator());
        }
        else if (pickUp.ItemCount == 1)
        {
            if (Handle.GetChild(0).GetChild(3).GetComponent<MoveToTarget>() == null)
            {
                return;
            }
            PlayerAnimation.playerAnimation.Throw();
            PlayerAnimation.playerAnimation.ReGrab();
            pickUp.ItemCount -= 1;
            CanChange = false;
            Handle.GetChild(0).transform.position = ThrowPoint.position;
            Handle.GetChild(0).GetChild(3).GetComponent<MoveToTarget>().enabled = true;
            Handle.GetChild(0).transform.SetParent(null);
            StartCoroutine(enumerator());
        }
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerAnimation.playerAnimation.ReThrow();
        CanChange = true;
    }
}
