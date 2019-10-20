using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer GG;
    public Sprite Broken;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        GG = GetComponent<SpriteRenderer>();
        
    }


    private void GameOver()
    {
        GG = GetComponent<SpriteRenderer>();
        
        GG.sprite = Broken;
        Instantiate(explosionPrefab, transform.position, transform.rotation);

    }
}
