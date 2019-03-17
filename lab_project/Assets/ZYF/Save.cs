using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1111111");
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 save_position = collision.transform.position;
            collision.gameObject.GetComponent<PlayerRe>().saveposition(save_position);
            Debug.Log(save_position);
        }
    }
}
