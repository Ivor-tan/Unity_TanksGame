using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_5 : MonoBehaviour
{
    public AudioClip GetBonsAudioSource;

    public float IsDefendedTime = 25;//无敌时间

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

            PlayerManager.Instance.IsDefended = true;
            PlayerManager.Instance.IsDefendedTime = IsDefendedTime;
            //PlayerManager.Instance.Player_Health++;
            Destroy(gameObject);
        }
    }
}
