using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JFlightning : MonoBehaviour
{
    public ParticleSystem pty;
    float timestart = 0;
    public AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        pty = this.gameObject.GetComponent<ParticleSystem>();
        ad = this.gameObject.GetComponent<AudioSource>();
        timestart = Random.Range(0.1f, 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        timestart += Time.deltaTime;
        if (timestart >= 2.6f)
        {
            pty.Play();
            ad.Play();
            timestart = 0;
        }
    }
}
