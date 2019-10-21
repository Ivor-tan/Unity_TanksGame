using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public AudioClip GetBonsAudioSource;

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

            PlayerManager.Instance.Player_Health++;
            Destroy(gameObject);
        }
    }
}
