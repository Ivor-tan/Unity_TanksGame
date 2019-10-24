using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLift : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject player;

    //是否按下
    private bool isPointerDown = false;
    private SpriteRenderer playerImage;
    public Sprite image;
    private int speed;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Tank");

        playerImage = player.GetComponent<SpriteRenderer>();

        speed = player.GetComponent<Player1>().Speed;

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

        speed = player.GetComponent<Player1>().Speed;

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        player.GetComponent<Player1>().direction = 3;
        if (player.GetComponent<Player1>().isMove == 0)
        {
            playerImage.sprite = image;
            player.GetComponent<Player1>().isMove = 3;
        }


    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        player.GetComponent<Player1>().isMove = 0;
    }

    private void FixedUpdate()
    {

        if (isPointerDown && player.GetComponent<Player1>().isMove == 3)
        {
            player.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

}
