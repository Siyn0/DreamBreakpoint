using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //无敌时间
    //private float wuditime = 1;
    //无敌计时器
    //private float wuditimer;
    //无敌状态
    //private bool isWudi;

    //最大健康值
    private int maxHealth = 100;//改为2;
    //当前健康值
    private int currentHealth;


    //其他脚本可获取最大健康值
    public int MyMaxHealth { get { return maxHealth; } }
    //其他脚本可获取当前健康值
    public int MyCurrentHealth { get { return currentHealth; } }


    // Start is called before the first frame update
    void Start()
    {

        //初始化生命值
        currentHealth = 100;
        //初始化无敌时间
        //wuditimer = 0;
        //更新生命条与子弹数量
        HPBar.instance.UpdateHP(currentHealth, maxHealth);

    }
    public void changeHealth(int amount)
    {
        //可能是受到伤害，也可能是加血
        if (amount < 0)
        {
            /*
            //如果是受伤，设置无敌状态，则2秒内不能受伤
            if (isWudi == true)
            {
                return;
            }
            isWudi = true;
            Debug.Log("无敌");
            //为无敌计时器赋值
            wuditimer = wuditime;
            */
        }
        //更改HP
        //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        currentHealth += amount;
        //更新血条
        HPBar.instance.UpdateHP(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            SendMessage("You Died");
            SceneManager.LoadScene("0");
        }
        //测试
        Debug.Log("HP"+currentHealth);
    }


    // Update is called once per frame
    void FiexedUpdate()
    {
        /*
        //如果处于无敌状态，就计时
        if (isWudi)
        {
            wuditimer -= Time.deltaTime;
            Debug.Log(wuditimer);
            //计时器归0，就不处于无敌状态了
            if (wuditimer <= 0)
            {
                isWudi = false;
            }
        }
        */

    }
}
