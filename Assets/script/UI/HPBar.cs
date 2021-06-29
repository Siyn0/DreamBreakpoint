using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image HPBarIMG;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateHP(int curAmount, int maxAmount)
    {
        HPBarIMG.fillAmount = (float)curAmount / (float)maxAmount;
    }

    public static HPBar instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

}