﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginSceneManager : SingletonMonoBehaviour<OriginSceneManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void GoShop()
    {
        SceneManager.LoadScene("BuyAitem");
    }

    public void GoAuction()
    {
        SceneManager.LoadScene("Auction");
    }

    public void CheckClear()
    {
        if (AitemBox.Instance.money <= 1000) { SceneManager.LoadScene("GameOver"); }
        else if (AitemBox.Instance.money >= 20000) { SceneManager.LoadScene("Clear"); }
        else { SceneManager.LoadScene("menu"); }

    }

}
