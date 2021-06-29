using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class EnemySmal : MonoBehaviour
{
    public Image HpBar;//血条
    public float speed = 3f;//机器人要运动肯定要有一个速度
    Animator anim;//创建一个动画状态集的变量，用来设定动画状态集的值，利用Animator参数，要决定到底播放左边的动画还是右边的动画
    Rigidbody2D rbody;//为了防止角色抖动，用刚体的moveposition来确定位置
    public bool isVertical;//设定一个参数，判断是水平移动还是垂直移动
    Vector2 moveDirection;//设定一个运动方向的变量

    float changeTimer;//设定一个计时器，每过一段时间，机器人换一个方向运动
    public float changeDirectionTime = 2f;//计时器长度

    public static int isFixed;

    public ParticleSystem brokeneffect;

    public AudioClip fixedClip;

    GameObject collectObject;

    //public static GameObject AIObject;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();//获取动画组件，一会儿要修改它的参数
        rbody = GetComponent<Rigidbody2D>();//获取2d刚体，一会儿要修改它的位置
        moveDirection = isVertical ? Vector2.up : Vector2.right;//初始状态下判断运动方向
        changeTimer = changeDirectionTime;//计时器初始化
        isFixed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isFixed==0) return;//如果被修复则不执行以下代码//这句导致第二个机器人不能运行
        changeTimer -= Time.deltaTime;//计时器每一帧都减小
        if (changeTimer < 0)
        {
            moveDirection *= -1;//如果小于0，改变方向
            changeTimer = changeDirectionTime;//改变方向后计时器重新初始化
        }

        Vector2 position = rbody.position;//定义一个二维向量位置坐标来获取刚体坐标
        position.x += moveDirection.x * speed * Time.deltaTime;//改变水平方向位置
        position.y += moveDirection.y * speed * Time.deltaTime;//改变垂直方向位置

        rbody.MovePosition(position);//为了防止抖动，调用刚体的moveposition，里面是二维向量的位置

        //设定动画状态集的参数，把moveDirection的值传递给move X/Y
        anim.SetFloat("move X", moveDirection.x);
        anim.SetFloat("move Y", moveDirection.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStatus ps = collision.gameObject.GetComponent<PlayerStatus>();

        if (ps != null)
        {
            ps.changeHealth(-10);
        }
    }

    public void Fixed()
    {
        isFixed--;
        Debug.Log("IsFixed:" + isFixed);
        if (isFixed % 2 == 0)
        {
            AIoff();
            //ScriptSelect.closeAI();
            if (brokeneffect.isPlaying == true)
            {
                brokeneffect.Stop();
            }
            rbody.simulated = false;//禁用物理
            anim.SetTrigger("fix");//播放被修复（打）的动画

        }
    }



    public void AIoff()
    {
        
        gameObject.GetComponent<EnemySmal>().enabled = true;
    }
    public static void AIon()//无法在此实现
    {
        //gameObject.GetComponent<AIPath>().enabled = true;
        //gameObject.GetComponent<RobotControl>().enabled = false;
    }

}