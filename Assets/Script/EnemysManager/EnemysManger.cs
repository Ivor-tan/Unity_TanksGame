using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManger : MonoBehaviour
{



    //敌人总数
    private int enemysTotal = 12;

    //敌人属性
    private int speed = 2;
    private bool isFire = true;

    //影响敌人道具属性
    private float StopTime = 15;

    //属性初始化
    private static EnemysManger instance;

    public static EnemysManger Instance { get => instance; set => instance = value; }
    public int EnemysTotal { get => enemysTotal; set => enemysTotal = value; }
    public int Speed { get => speed; set => speed = value; }
    public bool IsFire { get => isFire; set => isFire = value; }


    //敌人静止
    public void AllStop()
    {
        Speed = 0;
        IsFire = false;
    }

    private void EnemysRecover()
    {
        Speed = 3;
        IsFire = true;
        StopTime = 15;
    }

    public void AllDie()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemys");

        for (int i = 0; i < Enemys.Length; i++)
        {
            Destroy(Enemys[i]);
        }

        //for(GameObject game:Enemys)
        //{

        //}

    }


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //敌人静止    恢复
        if (Speed == 0)
        {
            StopTime -= Time.deltaTime;
            if (StopTime <= 0)
            {
                EnemysRecover();
            }
        }
    }

    public void CreateProps(Vector3 position)
    {
        //刷道具概率1/8
        int create = Random.Range(1, 9);

        if (create == 8)
        {
            PropsManager.Instance.CreateProps(position);
            //Instantiate(Props[0], position, Quaternion.identity);

        }
    }

}
