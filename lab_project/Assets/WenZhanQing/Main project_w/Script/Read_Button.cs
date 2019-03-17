using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class Read_Button : MonoBehaviour {
    public GameObject imag;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
    public void ReadOver()
    {
        imag.SetActive(false);
        Fungus.Flowchart.BroadcastFungusMessage("SecondSay");
    }
}
