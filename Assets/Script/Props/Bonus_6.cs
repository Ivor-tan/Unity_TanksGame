using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_6 : MonoBehaviour
{
    public AudioClip GetBonsAudioSource;

    public float IsDefendedTime = 25;//无敌时间

    private int BulletLevelMax = 1;
    //消失倒计时
    private float GoneTime = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GoneTime -= Time.deltaTime;
        if (GoneTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tank")
        {
            AudioSource.PlayClipAtPoint(GetBonsAudioSource, gameObject.transform.position);

           
            collision.gameObject.GetComponent<Player1>().BulletLevel = BulletLevelMax;
            print("OnTriggerEnter2D" + collision.gameObject.GetComponent<Player1>().BulletLevel);
            //PlayerManager.Instance.Player_Health++;
            Destroy(gameObject);
        }
    }
}
