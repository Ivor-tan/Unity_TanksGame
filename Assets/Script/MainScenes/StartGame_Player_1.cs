using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame_Player_1 : MonoBehaviour
{

    private GameObject Start_Player_1;

    private void Awake()
    {
        Start_Player_1 = GameObject.Find("Button_StartGame_Player_1");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        Start_Player_1.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(1);
        }
);

    }
}
