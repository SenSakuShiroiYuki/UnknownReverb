using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject[] Laser_B, Laser_R;
    public float Timer;
    public bool Change;
    void Update()
    {
        if (Change == true)
            Timer -= Time.deltaTime;
        else
            Timer += Time.deltaTime;




        if (Timer <= 0)
        {
            Change = false;
            foreach (GameObject game in Laser_B)
            {
                game.SetActive(true);
                game.transform.parent.GetComponent<LineRenderer>().enabled = true;
            }
            foreach (GameObject game in Laser_R)
            {
                game.SetActive(false);
                game.transform.parent.GetComponent<LineRenderer>().enabled = false;
            }

        }
        else if (Timer >= 10)
        {
            Change = true;
            foreach (GameObject game in Laser_B)
            {
                game.SetActive(false);
                game.transform.parent.GetComponent<LineRenderer>().enabled = false;
            }
            foreach (GameObject game in Laser_R)
            {
                game.SetActive(true);
                game.transform.parent.GetComponent<LineRenderer>().enabled = true;
            }
        }
    }
}
