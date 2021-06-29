using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    public GameObject player;
    public float MoveSpeed = 1.5f;

    //private float timer = 0f;
    private Transform target;
    private Rigidbody2D rg;
    private Vector2 Dir;
    [Range(0, 10f)] public float ChaseStrenth;

    /*
     * Lerp��������ͨ������������ȡһ�����Բ�ֵ��ͨ�����Lerp�������Եõ���������ֵ������

�õ������������Ϊ����Ҫ���õ������ϵ��µķ���

��ν�����˼�������ʵ��ƽ����׷�ٹ켣��
    */

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        rg = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerStatus>().changeHealth(-10);
    }

        // Update is called once per frame
        void FixedUpdate()
    {

        Vector2 direction = target.transform.position - transform.position;
        direction = direction.normalized;
        Dir = Vector2.Lerp(Dir, direction, ChaseStrenth / 100);
        Dir = Dir.normalized;
        rg.velocity = Dir * MoveSpeed;
    }
}
