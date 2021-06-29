using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallAI : MonoBehaviour
{

    public GameObject player;
    public float speed = 0.4f;

    private Rigidbody2D Enemy_rb;
    private float time = 0;//¼ÆÊ±Æ÷
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        PlayerStatus ps = collision.gameObject.GetComponent<PlayerStatus>();

        if (ps != null)
        {
            ps.changeHealth(-10);
        }
        */
        player.GetComponent<PlayerStatus>().changeHealth(-10);
        Debug.Log("Åö×²");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAlive)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                Enemy_rb.velocity = new Vector2(speed, 0);
                Enemy_rb.transform.localScale = new Vector2(1, 1);
            }
            if (time >= 2)
            {
                Enemy_rb.velocity = new Vector2(-speed, 0);
                Enemy_rb.transform.localScale = new Vector2(-1, 1);
                time = 0;
            }
        }
        
        
    }
}
