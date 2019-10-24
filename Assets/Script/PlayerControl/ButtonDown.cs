using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject player;

    //是否按下
    private bool isPointerDown = false;
    private SpriteRenderer playerImage;
    public Sprite image;
    private int speed;

    private void Awake()
    {



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

    private void FixedUpdate()
    {
        if (isPointerDown && player.GetComponent<Player1>().isMove == 2)
        {
            player.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
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
        player.GetComponent<Player1>().direction = 2;
        if (player.GetComponent<Player1>().isMove == 0)
        {
            playerImage.sprite = image;
            player.GetComponent<Player1>().isMove = 2;
        }


    }
    public void OnPointerUp(PointerEventData eventData)
    {

        isPointerDown = false;
        player.GetComponent<Player1>().isMove = 0;
    }

}
