using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraManager : MonoBehaviour
{
    public int count;
    //public int SakuraMoney;

    void Start()
    {
        count = 0;
    //  SakuraMoney = 0;
    }

    public void Update()
    {
        this.GetComponent<Text>().text = count.ToString() + "円";
    }
}
