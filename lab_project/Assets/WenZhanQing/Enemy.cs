using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HideCoolDown = 0.3f; //隐藏自己的冷却时间
    public float AppearTime;   //最后一次被发现的时刻
    private MeshRenderer mr;
    // Use this for initialization
    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - AppearTime < HideCoolDown)
            return;
        if (mr.enabled)
            mr.enabled = false;
    }

    public void BeDiscovered() //被发现了
    {
        mr.enabled = true;
        AppearTime = Time.time;
    }
}