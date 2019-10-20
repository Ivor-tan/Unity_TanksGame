using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject Player;

    //玩家属性设定
    public int Player_Health = 3;
    public int Score = 0;

    public bool isDead = false;

    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }

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
        if (isDead) {
            Recover();
        }
    }

    private void Recover()
    {
        if (Player_Health <= 0)
        {
            //结束



        }
        else
        {
            Instantiate(Player, new Vector3(-2, -8, 0), Quaternion.identity);
            isDead = false;
        }

    }
}
