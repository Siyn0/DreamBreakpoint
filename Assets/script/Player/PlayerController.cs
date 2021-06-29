using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_rg;

    public Sprite player;

    public float MoveSpeed;

    public float dashSpeed;
    public float dashTime;
    private float startDashTimer;
    bool isDashing = false;
    public GameObject dashObj;

    private bool isRight;//面朝右
    private bool isLeft;//面朝左
    private bool isUp;//面朝上
    private bool isDown;//面朝下


    public bool PlayerIsLeft { get { return isLeft; } }
    public bool PlayerIsDown { get { return isDown; } }


    void Start()
    {

        m_rg = gameObject.GetComponent<Rigidbody2D>();

    }

    
    public string GetDirection()
    {
        if (isLeft)
        {
            return ("Left");
        }
        else if (isRight)
        {
            return ("Right");
        }
        else if (isUp)
        {
            return ("Up");
        }
        else if(isDown)
        {
            return ("Down");
        }
        else
        {
            return ("None");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Input.GetAxisRaw没有小数值，只有整数
        //水平方向移动：
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            m_rg.velocity = new Vector2(MoveSpeed, m_rg.velocity.x);
            isRight = true;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            m_rg.velocity = new Vector2(-MoveSpeed, m_rg.velocity.x);
            isLeft = true;
        }

        else
        {
            m_rg.velocity = new Vector2(0, m_rg.velocity.x);
            isRight = false;
            isLeft = false;
        }

        //垂直方向移动：
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x , -MoveSpeed);
            isDown = true;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, MoveSpeed);
            isUp = true;
        }
        else
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, 0);
            isUp = false;
            isDown = false;
        }

        //Dash
        if(!isDashing)
        {
            if(Input.GetAxisRaw("Jump") > 0)
            {
                dashObj.SetActive(true);
                isDashing = true;
                startDashTimer = dashTime;
            }
        }
        else
        {
            startDashTimer -= Time.deltaTime;
            if (startDashTimer <= 0)
            {
                isDashing = false;
                dashObj.SetActive(false);
            }
            else
            {
                if (isLeft)
                {
                    m_rg.velocity = transform.right * -dashSpeed;
                }
                else if(isRight)
                {
                    m_rg.velocity = transform.right * dashSpeed;
                }
                else if(isUp)
                {
                    m_rg.velocity = transform.up * dashSpeed;
                }
                else if (isDown)
                {
                    m_rg.velocity = transform.up * -dashSpeed;
                }
            }
        }
    }

}
