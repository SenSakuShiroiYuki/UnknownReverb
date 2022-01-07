using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public int Mods;
    public LaserManager laserManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LightinfBall"))
        {
            Destroy(other.gameObject);
            switch(Mods)
            {
                case 0:
                    laserManager.Timer = 0;
                    laserManager.Change = false;
                    foreach (GameObject game in laserManager.Laser_B)
                    {
                        game.SetActive(true);
                        game.transform.parent.GetComponent<LineRenderer>().enabled = true;
                    }
                    foreach (GameObject game in laserManager.Laser_R)
                    {
                        game.SetActive(false);
                        game.transform.parent.GetComponent<LineRenderer>().enabled = false;
                    }
                    break;
                case 1:
                    laserManager.Timer = 10;
                    laserManager.Change = true;
                    foreach (GameObject game in laserManager.Laser_B)
                    {
                        game.SetActive(false);
                        game.transform.parent.GetComponent<LineRenderer>().enabled = false;
                    }
                    foreach (GameObject game in laserManager.Laser_R)
                    {
                        game.SetActive(true);
                        game.transform.parent.GetComponent<LineRenderer>().enabled = true;
                    }
                    break;

            }
        }
    }
}
