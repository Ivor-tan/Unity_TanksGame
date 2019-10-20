using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysBorn : MonoBehaviour
{
    public GameObject[] EnemysPerfab;

    //敌人出生计时器
    public float EnemysBronTime = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemysBronTime += Time.deltaTime;
        if (EnemysBronTime > 1.5)
        {
            EnemysBronTime = 0;
            EnemysBron();
        }
    }


    public void EnemysBron()
    {
        Instantiate(EnemysPerfab[0], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
