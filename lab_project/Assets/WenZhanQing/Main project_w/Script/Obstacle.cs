using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public static int speed = 10;
    private GameObject Obs;

    void Start()
    {
        Obs = GameObject.FindGameObjectWithTag("Obs");
    }
	// Update is called once per frame
	void Update () {
        Obs.transform.Rotate(Vector3.up * speed);
    }
   
}
