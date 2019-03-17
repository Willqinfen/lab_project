using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyJiance : MonoBehaviour
{

    public float EyeViewDistance; //视野距离
    public float viewAngle = 120f; //视野角度

    private Rigidbody rb;
    private Collider[] SpottedEnemies; //附近的敌人

    public float radius;                             //自动行走最大的半径
    public int radius_max;                           //随机数上限
    public int radius_min;                           //随机数下限

    public bool Is_Reach = true;                     //是否达到目的地
    public bool Is_AdjustNext = false;               //是否需要进行圈内调整

    public NavMeshAgent self;                        //自身的NavMeshAgent组件

    public Vector3 self_position;                    //自身坐标
    public Vector3 initial_position;                 //初始坐标
    public Vector3 newdest;                          //新目的地
    public GameObject Img;
   
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        self = this.GetComponent<NavMeshAgent>();
        initial_position = GetComponent<Transform>().position;    //获取原始坐标
      
    }


    private void FixedUpdate()
    {
        DetectEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        self_position = GetComponent<Transform>().position;
        if ( self_position.x - newdest.x < 0.02f && self_position.z - newdest.z < 0.02f)       //判读是否进入目的地范围
        {
            Is_Reach = true;
        }
        if (Is_Reach)
        {
            if (Is_AdjustNext)
                Adjust_Next();
            else
                SetPosition();                                         //设置坐标
            Adjust();                                                  //对坐标进行调整
            Setdest();                                                 //设置目的地
        }
        Debug.DrawLine(transform.position, transform.forward * 100, Color.red); //红色射线，面对的方向
    }




    void DetectEnemy()  //探测敌人
    {
        //OverlapSphere内的敌人
        SpottedEnemies = Physics.OverlapSphere(transform.position, EyeViewDistance, LayerMask.GetMask("Player"));
        for (int i = 0; i < SpottedEnemies.Length; i++) //检测每一个敌人是否在视野区中
        {
            Vector3 EnemyPosition = SpottedEnemies[i].transform.position; //敌人的位置

            //Debug.Log(transform.forward + " 面对的方向");
            //Debug.Log("夹角为:" + Vector3.Angle(transform.forward, EnemyPosition - transform.position));

            Debug.DrawRay(transform.position, EnemyPosition - transform.position, Color.yellow); //玩家位置到敌人位置的向量
            if (Vector3.Angle(transform.forward, EnemyPosition - transform.position) <= viewAngle / 2)  //这个敌人是否在视野内
            {
                //如果在视野内
                RaycastHit info = new RaycastHit();
                int layermask = LayerMask.GetMask("Player", "Obstacles"); //指定射线碰撞的对象
                Physics.Raycast(transform.position, EnemyPosition - transform.position, out info, EyeViewDistance); //向敌人位置发射射线

                if (info.collider == SpottedEnemies[i]) //如果途中无其他障碍物，那么射线就会碰撞到敌人
                {
                    DiscoveredEnemy(SpottedEnemies[i]);
                }
            }
        }
    }

    void DiscoveredEnemy(Collider Enemy) //发现敌人
    {
        //Do something
        if (Enemy.GetComponent<PlayerRe>() != null)
        {
            Img.SetActive(true);
            Enemy.GetComponent<PlayerRe>().Replay();
            StartCoroutine(Wait());
        }

    }

    private void Setdest()
    {
        self.SetDestination(newdest);                                //进行寻路
        Is_Reach = false;
    }

    private void SetPosition()
    {
        float x = Random.Range(radius_min, radius_max);
        int sign_x = Random.Range(0, 2);
        if (sign_x == 1)
            x = -x;
        float z = Random.Range(radius_min, radius_max);
        int sign_z = Random.Range(0, 2);
        if (sign_z == 1)
            z = -z;
        newdest = new Vector3((self_position.x) + x, self_position.y, (self_position.z) + z);
    }

    private void Adjust()
    {
        float dis = (newdest - initial_position).sqrMagnitude;
        if (dis <= radius)
            return;
        else
        {
            float angle = Vector3.Angle(newdest - initial_position, new Vector3(initial_position.x + 1, initial_position.y, initial_position.z));
            newdest = new Vector3(initial_position.x + radius * Mathf.Cos(angle), newdest.y, initial_position.z + radius * Mathf.Sin(angle));
            Is_AdjustNext = true;
        }
    }
    private void Adjust_Next()
    {
        float x = Random.Range(0, (float)(radius * 1.4));
        int sign_x = Random.Range(0, 2);
        if (sign_x == 1)
            x = -x;
        float z = Random.Range(0, (float)(radius * 1.4));
        int sign_z = Random.Range(0, 2);
        if (sign_z == 1)
            z = -z;
        newdest = new Vector3(initial_position.x + x, initial_position.y, initial_position.z + z);
        Is_AdjustNext = false;
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(2);

        Img.SetActive(false);

    }
}
