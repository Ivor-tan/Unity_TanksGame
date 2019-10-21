using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject[] MapItem;// 0 AirWall 1 Bairrar 2 Grees 3 Wall 4 Heart  5  Rivers  6 player01 7 Enemys
    private List<Vector3> mapPos = new List<Vector3> { };

    //private int EnemysNubmer = 3;

    //刷新敌人计时器
    public float EnemysBronTime = 0;



    public void Awake()
    {
        MyMapCreate();
    }

    private void MyMapCreate()
    {
        initHeart();

        initPlayer();

        initEnemys();

        initMap(25, 25, 80, 15);

    }

    private void initEnemys()
    {
        CreateItem(MapItem[7], new Vector3(-9, 8, 0), Quaternion.identity);
        CreateItem(MapItem[7], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(MapItem[7], new Vector3(9, 8, 0), Quaternion.identity);

        mapPos.Add(new Vector3(-9, 8, 0));
        mapPos.Add(new Vector3(0, 8, 0));
        mapPos.Add(new Vector3(9, 8, 0));
    }

    private void CreateItem(GameObject Item, Vector3 vector3, Quaternion quaternion)
    {
        GameObject gameItem = Instantiate(Item, vector3, Quaternion.identity);
        gameItem.transform.SetParent(gameObject.transform);

    }

    private void initHeart()
    {

        CreateItem(MapItem[4], new Vector3(0, -8, 0), Quaternion.identity);

        CreateItem(MapItem[3], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(MapItem[3], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(MapItem[3], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(MapItem[3], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(MapItem[3], new Vector3(-1, -8, 0), Quaternion.identity);

        mapPos.Add(new Vector3(0, -7, 0));
        mapPos.Add(new Vector3(-1, -7, 0));
        mapPos.Add(new Vector3(1, -7, 0));
        mapPos.Add(new Vector3(1, -8, 0));
        mapPos.Add(new Vector3(-1, -8, 0));


    }

    private void initPlayer()
    {
        CreateItem(MapItem[6], new Vector3(-2, -8, 0), Quaternion.identity);
        mapPos.Add(new Vector3(-2, -8, 0));
    }

    private void initMap(int Bairrar, int Grees, int Wall, int Rivers)
    {
        for (int i = 0; i < Bairrar; i++)
        {
            CreateItem(MapItem[1], CreatePos(), Quaternion.identity);
        }
        for (int i = 0; i < Grees; i++)
        {
            CreateItem(MapItem[2], CreatePos(), Quaternion.identity);
        }
        for (int i = 0; i < Wall; i++)
        {
            CreateItem(MapItem[3], CreatePos(), Quaternion.identity);
        }
        for (int i = 0; i < Rivers; i++)
        {
            CreateItem(MapItem[5], CreatePos(), Quaternion.identity);
        }

    }
    private Vector3 CreatePos()
    {
        mapPos.Add(new Vector3(0, -8, 0));
        mapPos.Add(new Vector3(-2, -8, 0));

        while (true)
        {
            Vector3 pos = new Vector3(Random.Range(-9, 10), Random.Range(-8, 9), 0);

            if (!hasPos(pos))
            {
                mapPos.Add(pos);
                return pos;
            }
        }

    }

    private bool hasPos(Vector3 pos)
    {
        for (int i = 0; i < mapPos.Count; i++)
        {
            if (pos == mapPos[i])
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemysBronTime += Time.deltaTime;

        if (EnemysBronTime > 10)
        {

            if (EnemysManger.Instance.EnemysTotal < 15)
            {
                EnemysManger.Instance.EnemysTotal++;
                initEnemys();
            }
            EnemysBronTime = 0;
        }

    }
}
