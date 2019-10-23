using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject player;
    //是否按下
    private bool isPointerDown = false;
    private SpriteRenderer playerImage;
    public Sprite image;

    private int speed;


    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Tank");

        //playerImage = player.GetComponent<SpriteRenderer>();

        //speed = player.GetComponent<Player>().Speed;

    }

    // Start is called before the first frame update
    void Start()
    {     
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && PlayerManager.Instance.Player_Health > 0)
        {
            FindPlayer();
        }
    }


    private void FindPlayer()
    {

        player = GameObject.FindGameObjectWithTag("Tank");

        playerImage = player.GetComponent<SpriteRenderer>();

        speed = player.GetComponent<Player>().Speed;

    }


    private void FixedUpdate()
    {
        if (isPointerDown && player.GetComponent<Player>().isMove == 4)
        {
            player.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        player.GetComponent<Player>().direction = 4;

        if (player.GetComponent<Player>().isMove == 0)
        {
            playerImage.sprite = image;
            player.GetComponent<Player>().isMove = 4;
        }
     

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        player.GetComponent<Player>().isMove = 0;
    }

}
