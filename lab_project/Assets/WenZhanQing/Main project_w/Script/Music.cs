using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Music : MonoBehaviour {
    public AudioSource asound;
    public Slider sd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Con_sound()
    {
        asound.volume = sd.value;
    }
}
