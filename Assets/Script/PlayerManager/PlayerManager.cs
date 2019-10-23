using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject ImageGameOver;

    //玩家属性设定
    public int Player_Health = 3;
    public int Score = 0;
    private double timeVal = 1.5;
    private float isDefendedTime = 4;
    private bool isDefended = true;
    private float bornTime = 1;

    //玩家是否存活
    public bool isDead = false;

    //老家是否存活
    public bool isOver = false;

    //重开倒计时
    private float RestartTime = 3;

    //玩家信息初始化
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }
    public double TimeVal { get => timeVal; set => timeVal = value; }
    public float IsDefendedTime { get => isDefendedTime; set => isDefendedTime = value; }
    public bool IsDefended { get => isDefended; set => isDefended = value; }
    public float BornTime { get => bornTime; set => bornTime = value; }

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
        if (isDead)
        {
            Recover();
        }
        if (isOver)
        {
            GameOver();
        }
    }

    private void Recover()
    {
        if (Player_Health <= 0)
        {
            //结束
            GameOver();

        }
        else
        {
            Instantiate(Player, new Vector3(-2, -8, 0), Quaternion.identity);
            isDead = false;
        }

    }

    private void GameOver()
    {
        Instantiate(ImageGameOver, new Vector3(0, 0, 0), Quaternion.identity);

        RestartTime -= Time.deltaTime;
        if (RestartTime <= 0)
        {

            //Application.Quit();
            SceneManager.LoadScene("Main");
        }

    }

    public void PlayerDateRecover()
    {
         timeVal = 1.5;
    }

}
