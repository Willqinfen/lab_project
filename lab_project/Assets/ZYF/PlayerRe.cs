using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRe : MonoBehaviour {

    private Vector3 self_postion;
    

    public void saveposition(Vector3 vector)
    {
        self_postion = vector;
    }


    public void Replay()
    {
        GetComponent<Transform>().position = self_postion;
    
    }
}
