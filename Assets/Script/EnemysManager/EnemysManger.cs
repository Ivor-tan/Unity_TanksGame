using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManger : MonoBehaviour
{


    //敌人总数
    public int EnemysTotal = 12;

    //道具列表
    public GameObject[] Props;//0 命+1   

    private static EnemysManger instance;

    public static EnemysManger Instance { get => instance; set => instance = value; }

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
        
    }

    public void CreateProps( Vector3 position)
    {
        int create = Random.Range(1,11);
        if (create==10)
        {
            Instantiate(Props[0], position, Quaternion.identity);

        }
    }
}
