using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLaser : MonoBehaviour
{
    public LaserManager laserManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightinfBall"))
        {
            Destroy(other.gameObject);
            laserManager.enabled = false;
            foreach (GameObject Laser in laserManager.Laser_B)
            {
                Laser.SetActive(false);
                Laser.transform.parent.GetComponent<LineRenderer>().enabled = false;
            }
            foreach (GameObject Laser in laserManager.Laser_R)
            {
                Laser.SetActive(false);
                Laser.transform.parent.GetComponent<LineRenderer>().enabled = false;
            }
        }
    }
}
