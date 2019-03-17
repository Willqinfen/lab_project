using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class Portal : MonoBehaviour {
    public GameObject image;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.tag == "Floor")
        {
            image.SetActive(true);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(2);
       
        SceneManager.LoadScene("Depth_planet");
        
    }
   


}
