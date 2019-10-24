using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonFire : MonoBehaviour
{
    //音效
    public AudioClip FireAudioSource;


    private GameObject buttonFire;
    public GameObject bullet;
    private GameObject player;
    private float timeVal;

    /*  private GameObject player;*/


    private void Awake()
    {
        buttonFire = GameObject.Find("ButtonFire");

    }

    // Start is called before the first frame update
    void Start()
    {
        Fire();
    }
    // Update is called once per frame
    void Update()
    {
        timeVal = timeVal + Time.deltaTime;
        if (player == null && PlayerManager.Instance.Player_Health > 0)
        {
            player = GameObject.FindGameObjectWithTag("Tank");
        }
    }

    private void Fire()
    {

        buttonFire.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (timeVal > PlayerManager.Instance.TimeVal)
            {

                //PropsManager.Instance.CreateProps(player.transform.position);
                //player.GetComponent<Player1>().BulletLevel

                //音效
                AudioSource.PlayClipAtPoint(FireAudioSource, player.transform.position);

                timeVal = 0;

                print("Fire====" + player.GetComponent<Player1>().BulletLevel);

                GameObject CreateBullet;

                switch (player.GetComponent<Player1>().direction)
                {
                    case (1):
                        CreateBullet = Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 0)));
                        CreateBullet.GetComponent<Bullet>().SetFrom(0);
                        CreateBullet.GetComponent<Bullet>().Level = player.GetComponent<Player1>().BulletLevel;
                        break;
                    case (2):
                        CreateBullet = Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 180)));
                        CreateBullet.GetComponent<Bullet>().SetFrom(0);
                        CreateBullet.GetComponent<Bullet>().Level = player.GetComponent<Player1>().BulletLevel;

                        break;
                    case (3):
                        CreateBullet = Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 90)));
                        CreateBullet.GetComponent<Bullet>().SetFrom(0);
                        CreateBullet.GetComponent<Bullet>().Level = player.GetComponent<Player1>().BulletLevel;

                        break;
                    case (4):
                        CreateBullet = Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, -90)));
                        CreateBullet.GetComponent<Bullet>().SetFrom(0);
                        CreateBullet.GetComponent<Bullet>().Level = player.GetComponent<Player1>().BulletLevel;
                        break;
                }



            }

            //Instantiate(bullet, player.GetComponent<Transform>().position, transform.rotation);
            //player.transform.Translate(Vector3.right*3*Time.deltaTime,Space.World);

        }
      );

    }

}
