using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject status;
    [SerializeField]
    private GameObject myMoney;
    [SerializeField]
    private GameObject product1;
    [SerializeField]
    private GameObject product2;
    [SerializeField]
    private GameObject product3;
    [SerializeField]
    private GameObject product4;
    [SerializeField]
    private GameObject customer1;
    [SerializeField]
    private GameObject customer2;
    [SerializeField]
    private GameObject customer3;
    [SerializeField]
    private GameObject customer4;

    void Start()
    {
        status.SetActive(false);
    }

    //ボタンでscene移動　※移動先のsceneは未制作※

    public void OnClickShopButton()
    {
        SceneManager.LoadScene("");
        Debug.Log("shop画面は出ないはずだよ");
    }

    public void OnClickResearchButton()
    {
        SceneManager.LoadScene("");
        Debug.Log("research画面は出ないはずだよ");
    }

    public void OnClickStartAuctionButton()
    {
        SceneManager.LoadScene("");
        Debug.Log("オークション画面は出ないはずだよ");
    }

    //ここまでsceneの移動

    /// <summary>
    ///ボタンを押したらステータス画面を出す
    ///
    ///客の金額(非公開)
    ///客の好み(調査したら公開)
    ///自分の金
    ///商品の種類(商品の金額)
    ///例
    ///銅像(100)・絵画（100）～
    ///Aさん ？？？が好き (boolで管理)
    ///Bさん Fが好き
    ///Cさん Gが好き
    ///Dさん ？？？が好き
    ////// </summary>

    public void OnClickCheckStatusButton()
    {
        status.SetActive(true);
    }

    public void OnClickButton()
    {
        status.SetActive(false);
    }



}
