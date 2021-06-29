using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class EnemySmal : MonoBehaviour
{
    public Image HpBar;//Ѫ��
    public float speed = 3f;//������Ҫ�˶��϶�Ҫ��һ���ٶ�
    Animator anim;//����һ������״̬���ı����������趨����״̬����ֵ������Animator������Ҫ�������ײ�����ߵĶ��������ұߵĶ���
    Rigidbody2D rbody;//Ϊ�˷�ֹ��ɫ�������ø����moveposition��ȷ��λ��
    public bool isVertical;//�趨һ���������ж���ˮƽ�ƶ����Ǵ�ֱ�ƶ�
    Vector2 moveDirection;//�趨һ���˶�����ı���

    float changeTimer;//�趨һ����ʱ����ÿ��һ��ʱ�䣬�����˻�һ�������˶�
    public float changeDirectionTime = 2f;//��ʱ������

    public static int isFixed;

    public ParticleSystem brokeneffect;

    public AudioClip fixedClip;

    GameObject collectObject;

    //public static GameObject AIObject;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();//��ȡ���������һ���Ҫ�޸����Ĳ���
        rbody = GetComponent<Rigidbody2D>();//��ȡ2d���壬һ���Ҫ�޸�����λ��
        moveDirection = isVertical ? Vector2.up : Vector2.right;//��ʼ״̬���ж��˶�����
        changeTimer = changeDirectionTime;//��ʱ����ʼ��
        isFixed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isFixed==0) return;//������޸���ִ�����´���//��䵼�µڶ��������˲�������
        changeTimer -= Time.deltaTime;//��ʱ��ÿһ֡����С
        if (changeTimer < 0)
        {
            moveDirection *= -1;//���С��0���ı䷽��
            changeTimer = changeDirectionTime;//�ı䷽����ʱ�����³�ʼ��
        }

        Vector2 position = rbody.position;//����һ����ά����λ����������ȡ��������
        position.x += moveDirection.x * speed * Time.deltaTime;//�ı�ˮƽ����λ��
        position.y += moveDirection.y * speed * Time.deltaTime;//�ı䴹ֱ����λ��

        rbody.MovePosition(position);//Ϊ�˷�ֹ���������ø����moveposition�������Ƕ�ά������λ��

        //�趨����״̬���Ĳ�������moveDirection��ֵ���ݸ�move X/Y
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
            rbody.simulated = false;//��������
            anim.SetTrigger("fix");//���ű��޸����򣩵Ķ���

        }
    }



    public void AIoff()
    {
        
        gameObject.GetComponent<EnemySmal>().enabled = true;
    }
    public static void AIon()//�޷��ڴ�ʵ��
    {
        //gameObject.GetComponent<AIPath>().enabled = true;
        //gameObject.GetComponent<RobotControl>().enabled = false;
    }

}