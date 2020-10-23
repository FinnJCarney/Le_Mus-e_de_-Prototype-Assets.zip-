using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSprite : MonoBehaviour
{
    public int timerLimit;
    int timer;

    public Sprite[] sprs;
    int sprsNum;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.me.timer > timer)
        {
            timer = GameManager.me.timer + timerLimit;
            if(sprsNum + 1 != sprs.Length)
            {
                sprsNum++;
            }
            else
            {
                sprsNum = 0;
            }

            sr.sprite = sprs[sprsNum];
        }
    }
}
