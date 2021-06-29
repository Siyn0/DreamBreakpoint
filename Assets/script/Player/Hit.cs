using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public GameObject WinText;
    public GameObject boss;
    public GameObject SayText1,SayText2;

    private int boss_HP = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Kill Enemy"+collision.gameObject.tag);
            
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.CompareTag("boss"))
        {
            boss_HP -= 1;
            if (boss_HP <= 0)
            {
                SendMessage("ÓÎÏ·Ê¤Àû£¡");
                WinText.SetActive(true);
                SayText1.SetActive(false);
                SayText2.SetActive(false);
                boss.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
