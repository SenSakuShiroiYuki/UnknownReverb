using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMechine_Manager : MonoBehaviour
{
    public int CubeCount;
    public GameObject CubeObj;
    public Transform CubeParen;
    public float BornTime;
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CubeCount > 0 || CubeParen.childCount != 0)
        {
            animator.SetBool("open", true);
        }
        else
        {
            animator.SetBool("open", false);
        }
        if (CubeCount > 0 && CubeParen.childCount < 1)
        {
            GameObject game = Instantiate(CubeObj, CubeParen);
            game.transform.localPosition = new Vector3(0, 0, 0);
            game.transform.eulerAngles = new Vector3(0, 0, 0);
            CubeCount -= 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightinfBall"))
        {
            Destroy(other.gameObject);
            if (CubeCount < 2)
                CubeCount += 1;
        }
    }
}
