using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereValues : MonoBehaviour {
    public int PointValue = 1;
    bool sphereRespawn;
    float collectableRespawn = 0;
    [SerializeField]
    float collectableCooldown = 5f;
    Vector3 startPosition;
    // Use this for initialization
    void Start () {
        startPosition = this.transform.position;
        sphereRespawn = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (sphereRespawn == true)
        {
            respawn();
        }
    }

    public void startRespawn()
    {
        collectableRespawn = Time.time + collectableCooldown;
        sphereRespawn = true;
    }

    void respawn()
    {
        if (collectableRespawn <= Time.time)
        {
            this.transform.position = startPosition;
            sphereRespawn = false;
        }
    }
}
