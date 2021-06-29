using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject player;
    public GameObject Left;
    public GameObject Right;
    public GameObject Up;
    public GameObject Down;

    private float timer1 = 0;//计时器，用于防止攻击时长过高，导致游戏难度太低
    private float timer2 = 0;//计时器，用于防止攻击频率过高，导致游戏难度太低
    public float Attack_Time = 0.5f;
    public float Attack_Interval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer2 += Time.deltaTime;
        if (Input.GetAxisRaw("Attack") > 0)
        {
            if (timer2>Attack_Interval)
            {
                timer2 = 0;
                timer1 = 0;
                timer1 += Time.deltaTime;
                PlayerController pc = player.GetComponent<PlayerController>();
                if (pc.PlayerIsLeft)
                {
                    Left.SetActive(true);
                    Right.SetActive(false);
                }
                else
                {
                    Right.SetActive(true);
                    Left.SetActive(false);
                }

                //水平方向的攻击和垂直方向的攻击不冲突
                if (pc.PlayerIsDown)
                {
                    Down.SetActive(true);
                    Up.SetActive(false);
                }
                else
                {
                    Up.SetActive(true);
                    Down.SetActive(false);
                }
            }
            else
            {
                Left.SetActive(false);
                Right.SetActive(false);
                Up.SetActive(false);
                Down.SetActive(false);
                timer1 = 0;
            }
        }
        else
        {
            Left.SetActive(false);
            Right.SetActive(false);
            Up.SetActive(false);
            Down.SetActive(false);
            timer1 = 0;
        }
    }
}
