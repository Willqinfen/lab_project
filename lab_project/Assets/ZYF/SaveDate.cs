using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDate : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1111111");
        if (other.gameObject.tag.Equals("Player"))
        {
            Vector3 save_position = other.transform.position;
            other.gameObject.GetComponent<PlayerRe>().saveposition(save_position);
            Debug.Log(save_position);
        }
    }
}
