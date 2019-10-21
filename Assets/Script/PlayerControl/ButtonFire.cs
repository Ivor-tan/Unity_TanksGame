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
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Tank");
        }
    }

    private void Fire()
    {

        buttonFire.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (timeVal > 1)
            {
                print("音效");
                //音效
                AudioSource.PlayClipAtPoint(FireAudioSource, player.transform.position);

                timeVal = 0;
               
                switch (player.GetComponent<Player>().direction)
                {
                    case (1):
                        Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 0))).GetComponent<Bullet>().SetFrom(0);                   
                        break;
                    case (2):
                        Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 180))).GetComponent<Bullet>().SetFrom(0);
                        break;
                    case (3):
                        Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 90))).GetComponent<Bullet>().SetFrom(0);
                        break;
                    case (4):
                        Instantiate(bullet, player.GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, -90))).GetComponent<Bullet>().SetFrom(0);
                        break;
                }
            }

                //Instantiate(bullet, player.GetComponent<Transform>().position, transform.rotation);
                //player.transform.Translate(Vector3.right*3*Time.deltaTime,Space.World);

            }
      );

    }

}
