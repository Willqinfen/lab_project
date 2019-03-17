using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_w : MonoBehaviour
{
    public GameObject image;
    private Transform player;
    private Transform Cube;
    bool is_down=false;
    private Vector3 m;
    private Vector3 n;
    public GameObject Obs;
    private Animator Obs_anim;
    // Use this for initialization
    public GameObject Empty;
    public AudioSource bt_music;
    void Start () {
        player= GameObject.FindGameObjectWithTag("Player").transform;
        Cube = GameObject.FindGameObjectWithTag("Cube").transform;
        Obs_anim = Obs.GetComponent<Animator>();
        Obs_anim.speed = 0;
        bt_music.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        m = player.position;
        n = Cube.position;
        Coll();
        if (is_down)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bt_music.Play();
                Obstacle.speed = 0;
                Obs_anim.speed = 1;
                Destroy(Empty, 2);
            }
  
               
        }
    }
   void Coll()
    {
       
        if (Vector3.Distance(m,n)<3)
        {
            image.SetActive(true);
            is_down = true;
        }
        else
        {
            is_down = false;
            image.SetActive(false);
            bt_music.Stop();
        }
    }
}
