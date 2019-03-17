using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    private Animator anim;
    public float run = 1.0f;
    private float speed = 1.0f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        
        float v = Input.GetAxisRaw("Vertical");//垂直方向 
        float h = Input.GetAxis("Horizontal"); //水平方向
        float a = Input.GetAxis("Mouse X"); //水平方向
        anim.SetInteger("Vertical", (int)v);
        transform.Translate(Vector3.forward * Time.deltaTime * 3 * v * speed);
        transform.Rotate(Vector3.up * h * 150 * Time.deltaTime);
        if(Input.GetKey(KeyCode.Mouse1))
            transform.Rotate(Vector3.up * a * 100 * Time.deltaTime);
        Jump();
        Run();
        Sneak();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            anim.SetBool("Jump", true);
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            anim.SetBool("Jump", false);
    }
    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            speed = run;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1.0f;
            anim.SetBool("Run", false);
        }
    }
    private void Sneak()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Sneak", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Sneak", false);
        }
    }
}
