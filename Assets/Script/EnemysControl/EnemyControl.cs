using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public GameObject ExplodePerfab;
    public GameObject BulletPerfab;
    public int Speed = 3;
    public int Moveing = 0;
    public int direction = 2;   //1  up  2 down  3 lift  4 right

    //图片渲染
    private SpriteRenderer EnemysImage;
    public List<Sprite> Images; //up   down  lift  right

    //计时器
    public float transformVectorTime = 0;
    public float FireTime = 0;

    private void Awake()
    {
        EnemysImage = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        TimeUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag.Equals("Enemys") ){
  
            VectorChange();
        }
    }

    private void TimeUp()
    {
        transformVectorTime = transformVectorTime + Time.deltaTime;
        FireTime = FireTime + Time.deltaTime;

        if (transformVectorTime > 2)
        {
            transformVectorTime = 0;

            VectorChange();
        }

        if (FireTime > 2.5)
        {
            FireTime = 0;

            Fire();
        }

        Move();
    }

    private void Fire()
    {

        switch (direction)
        {
            case (1):
                Instantiate(BulletPerfab, GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 0))).GetComponent<Bullet>().SetFrom(1);
                break;
            case (2):
                Instantiate(BulletPerfab, GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 180))).GetComponent<Bullet>().SetFrom(1);
                break;
            case (3):
                Instantiate(BulletPerfab, GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, 90))).GetComponent<Bullet>().SetFrom(1);
                break;
            case (4):
                Instantiate(BulletPerfab, GetComponent<Transform>().position, Quaternion.Euler(new Vector3(0, 0, -90))).GetComponent<Bullet>().SetFrom(1);
                break;
        }

    }


    private void VectorChange()
    {
        Moveing = Random.Range(0, 120);

        if (0 <= Moveing && Moveing < 15)
        {
            direction = 1;

        }
        else if (15 <= Moveing && Moveing < 55)
        {
            direction = 2;

        }
        else if (55 <= Moveing && Moveing < 75)
        {
            direction = 3;

        }
        else if (75 <= Moveing && Moveing < 100)
        {
            direction = 4;

        }
        else if (100 <= Moveing && Moveing < 120)
        {

        }
    }

    private void Move()
    {

        switch (direction)
        {
            case 1:
                EnemysImage.sprite = Images[0];
                transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
                break;
            case 2:
                EnemysImage.sprite = Images[1];
                transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);
                break;
            case 3:
                EnemysImage.sprite = Images[2];
                transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
                break;
            case 4:
                EnemysImage.sprite = Images[3];
                transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
                break;

        }





    }

    public void Die()
    {

        PlayerManager.Instance.Score++;

        Instantiate(ExplodePerfab, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}
