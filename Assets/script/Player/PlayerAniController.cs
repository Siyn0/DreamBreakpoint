using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniController : MonoBehaviour
{
    public GameObject player;
    public Sprite player_Left;
    public Sprite player_Right;
    public Sprite player_Dash;
    public Sprite player_none;

    private SpriteRenderer PlayerImg;

    private bool isWalking = false;

    private float i = 0;//¼ÆÊ±Æ÷


    // Start is called before the first frame update
    void Start()
    {
        PlayerImg = player.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        //Walking
        if(isWalking)
        {
            if (i >= 0.3)
            {
                PlayerImg.sprite = player_Left;
            }
            if(i >= 0.6)
            {
                PlayerImg.sprite = player_Right;
                i = 0;
            }
            i += Time.deltaTime;
        }
        else
        {
            PlayerImg.sprite = player_none;
        }

        if (Input.GetAxisRaw("Jump") > 0)
        {
            PlayerImg.sprite = player_Dash;
        }
    }
}
