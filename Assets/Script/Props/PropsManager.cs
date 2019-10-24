using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{


    //道具列表
    public GameObject[] Props;//0 命+1   1 静止   2老家保护  3消灭当前所有  4减少攻击间隔  5玩家保护  6 子弹升级

    private static PropsManager instance;

    public static PropsManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void CreateProps(Vector3 position)
    {

        int PropsNumber = Random.Range(0, 7);
        //print("CreateProps==========="+ PropsNumber+"=======" +position);
        //Instantiate(Item, vector3, Quaternion.identity);
        //Instantiate(Props[0], position, Quaternion.identity);
        Instantiate(Props[PropsNumber], position, Quaternion.identity).transform.SetParent(gameObject.transform);

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
