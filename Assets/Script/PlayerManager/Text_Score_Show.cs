using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Score_Show : MonoBehaviour
{
    private GameObject Socre_Show;

    private void Awake()
    {
        Socre_Show = GameObject.Find("Text_Score_Show");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Socre_Show.GetComponent<Text>().text = "Score:" + PlayerManager.Instance.Score;
    }
}
