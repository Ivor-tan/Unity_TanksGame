using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public int isMove = 0; //0 no Move  1  up  2 down  3 lift  4 right
    public int direction = 1;   //1  up  2 down  3 lift  4 right
    public int Speed = 3;
    public GameObject ExplodePerfab;
    public GameObject Defendedfab;
    public GameObject BornPerfab;
    private int bulletLevel = 0;// 0  摧毁墙    1  摧砖

    //音效

    public AudioClip ExplodeAudioSource;

    //private bool isDefended;
    //private float isDefendedTime;
    private float BornTime = 1;

    public int BulletLevel { get => bulletLevel; set => bulletLevel = value; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.IsDefended = true;
    }

    // Update is called once per frame
    void Update()
    {

        Defend();

    }

    private void Defend()
    {
   
        if (PlayerManager.Instance.IsDefended)
        {

            PlayerManager.Instance.IsDefendedTime -= Time.deltaTime;

            BornTime -= Time.deltaTime;

            Defendedfab.SetActive(true);

            if (BornTime <= 0)
            {
                BornPerfab.SetActive(false);
                //BornTime = 1;
            }


            if (PlayerManager.Instance.IsDefendedTime <= 0)
            {

                Defendedfab.SetActive(false);

                PlayerManager.Instance.IsDefended = false;

                PlayerManager.Instance.IsDefendedTime = 4;

            }
        }
    }

    private void Die()
    {
        if (PlayerManager.Instance.IsDefended)
        {
            return;
        }

        bulletLevel = 0;

        AudioSource.PlayClipAtPoint(ExplodeAudioSource, gameObject.transform.position);

        PlayerManager.Instance.Player_Health--;

        PlayerManager.Instance.isDead = true;

        PlayerManager.Instance.PlayerDateRecover();

        Instantiate(ExplodePerfab, transform.position, transform.rotation);

        Destroy(gameObject);

    }

    private void Recover()
    {



    }

}
