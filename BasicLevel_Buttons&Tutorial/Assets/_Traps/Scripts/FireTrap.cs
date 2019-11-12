using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {

    private ParticleSystem ps;
    public int timer = 0;
    public bool isActive = false;
    public int trapduration = 200;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == false)
        {
            ps.Play();
            isActive = true;
        }
        if (timer == trapduration)
        {
            ps.Stop();
            timer = 0;
            isActive = false;
        }
        timer++;
    }
}
