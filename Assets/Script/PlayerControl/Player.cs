using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int isMove = 0; //0 no Move  1  up  2 down  3 lift  4 right
    public int direction = 1;   //1  up  2 down  3 lift  4 right
    public int Speed = 3;
    public GameObject ExplodePerfab;
    public GameObject Defendedfab;
    public GameObject BornPerfab;
  


    private bool isDefended = true;
    private float isDefendedTime = 4;
    private float BornTime =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefended)
        {
           
            isDefendedTime -= Time.deltaTime;
            BornTime -= Time.deltaTime;

            Defendedfab.SetActive(true);
            BornPerfab.SetActive(true);

            if (BornTime <= 0)
            {

                BornPerfab.SetActive(false);
               
            }

            if (isDefendedTime <= 0)
            {
                
                Defendedfab.SetActive(false);
                isDefended = false;
            }
        }
       
    }

    private void Die()
    {
        if (isDefended)
        {
            return;
        }

        PlayerManager.Instance.Player_Health--;
        PlayerManager.Instance.isDead = true;

        Instantiate(ExplodePerfab, transform.position,transform.rotation);

        Destroy(gameObject);

    }

    private void Recover() {
       


    }

}
