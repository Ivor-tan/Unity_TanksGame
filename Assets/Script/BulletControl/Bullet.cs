using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 10;
    private GameObject Bullet_0;
    private int from = 0; // 0  自己    1  敌人
    private int level = 0; // 0  摧毁墙    1  摧砖
    public GameObject ExplodePerfeb;

    public int Level { get => level; set => level = value; }

    public void Awake()
    {
     
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {

        transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {

            case ("Bullet"):

                Destroy(gameObject);
                break;

            case ("Tank"):
               
                if (from == 1)
                {
                    collision.SendMessage("Die");
                    Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                
                break;
            case ("Enemys"):
               
                if (from == 0)
                {
                    collision.SendMessage("Die");
                    Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                    Destroy(gameObject);
                }

                break;
            case ("Bairrar"):
                print("Bairrar=====" + level+"======"+Level);
                if (level == 1) {
                    Destroy(collision.gameObject);
                }
                    Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case ("Grees"):
              

                break;
            case ("Heart"):
                collision.SendMessage("GameOver");
                Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case ("Rivers"):

              
                break;
            case ("Wall"):
                Destroy(collision.gameObject);
                Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case ("AirWall"):
                Instantiate(ExplodePerfeb, transform.position, transform.rotation);
                Destroy(gameObject);
                break;

        }

    }

    public void SetFrom(int from)
    {
        this.from = from;
    }
    public int GetFrom()
    {
        return from;
    }

}
