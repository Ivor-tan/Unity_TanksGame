using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public Sprite Image_GameOver;

    //重开倒计时
    private float RestartTime = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.Player_Health <= 0 || PlayerManager.Instance.isOver)
        {
            GetComponent<Image>().sprite = Image_GameOver;
            RestartTime -= Time.deltaTime;
            if (RestartTime <= 0)
            {
                //Application.Quit();
                SceneManager.LoadScene("Main");
            }
        }
    }
}
