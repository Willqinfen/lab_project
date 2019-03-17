using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class TalkSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Say()
    {
        Fungus.Flowchart.BroadcastFungusMessage("FirstSay");
    }
}
