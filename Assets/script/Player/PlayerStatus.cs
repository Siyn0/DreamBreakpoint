using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //�޵�ʱ��
    //private float wuditime = 1;
    //�޵м�ʱ��
    //private float wuditimer;
    //�޵�״̬
    //private bool isWudi;

    //��󽡿�ֵ
    private int maxHealth = 100;//��Ϊ2;
    //��ǰ����ֵ
    private int currentHealth;


    //�����ű��ɻ�ȡ��󽡿�ֵ
    public int MyMaxHealth { get { return maxHealth; } }
    //�����ű��ɻ�ȡ��ǰ����ֵ
    public int MyCurrentHealth { get { return currentHealth; } }


    // Start is called before the first frame update
    void Start()
    {

        //��ʼ������ֵ
        currentHealth = 100;
        //��ʼ���޵�ʱ��
        //wuditimer = 0;
        //�������������ӵ�����
        HPBar.instance.UpdateHP(currentHealth, maxHealth);

    }
    public void changeHealth(int amount)
    {
        //�������ܵ��˺���Ҳ�����Ǽ�Ѫ
        if (amount < 0)
        {
            /*
            //��������ˣ������޵�״̬����2���ڲ�������
            if (isWudi == true)
            {
                return;
            }
            isWudi = true;
            Debug.Log("�޵�");
            //Ϊ�޵м�ʱ����ֵ
            wuditimer = wuditime;
            */
        }
        //����HP
        //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        currentHealth += amount;
        //����Ѫ��
        HPBar.instance.UpdateHP(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            SendMessage("You Died");
            SceneManager.LoadScene("0");
        }
        //����
        Debug.Log("HP"+currentHealth);
    }


    // Update is called once per frame
    void FiexedUpdate()
    {
        /*
        //��������޵�״̬���ͼ�ʱ
        if (isWudi)
        {
            wuditimer -= Time.deltaTime;
            Debug.Log(wuditimer);
            //��ʱ����0���Ͳ������޵�״̬��
            if (wuditimer <= 0)
            {
                isWudi = false;
            }
        }
        */

    }
}
