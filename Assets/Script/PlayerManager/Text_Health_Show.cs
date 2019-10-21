using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Health_Show : MonoBehaviour
{
    private GameObject Health_Show;

    private void Awake()
    {
        Health_Show = GameObject.Find("Text_Health_Show");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health_Show.GetComponent<Text>().text = "Health:" + PlayerManager.Instance.Player_Health;
    }
}
