using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour
{
    public float PrintTime = 1f;
    public string text1,text2,text3,text4,text5 = "";

    private float TempTime = 0f;
    private string CurrentText;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TempTime >= PrintTime)
        {
            CurrentText = this.gameObject.GetComponent<Text>().text;
            this.gameObject.GetComponent<Text>().text = "";

            if ((text1 != "") && CurrentText != text5)
            {
                
                this.gameObject.GetComponent<Text>().text = text1;
                TempTime = 0;
                
            }
            if ((text2 != "" )&& (CurrentText == text1))
            {
                this.gameObject.GetComponent<Text>().text = text2;
                TempTime = 0;
                
            }
            if ((text3 != "") && (CurrentText == text2))
            {
                this.gameObject.GetComponent<Text>().text = text3;
                TempTime = 0;
                
            }
            if ((text4 != "") && (CurrentText == text3))
            {
                this.gameObject.GetComponent<Text>().text = text4;
                TempTime = 0;
                
            }
            if ((text5 != "") && (CurrentText == text4))
            {
                this.gameObject.GetComponent<Text>().text = text5;
                TempTime = 0;
                
            }
        }
        else
        {
            TempTime += Time.deltaTime;
        }
    }
}
