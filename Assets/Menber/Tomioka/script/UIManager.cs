using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject statusWindow;
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

    bool researchCustomer1 = false;
    bool researchCustomer2 = false;
    bool researchCustomer3 = false;
    bool researchCustomer4 = false;

    
    string customerName1 = "まれいたそ";
    string customerLike1 = "水素水";
    

    int product = 100;

    void Start(){
        statusWindow.SetActive(false);
        ChangeText();
    }

    //ボタンでscene移動　※移動先のsceneは未制作※

    public void OnClickShopButton(){
        SceneManager.LoadScene("");
        Debug.Log("shop画面は出ないはずだよ");
    }
    
    public void OnClickResearchButton(){
        SceneManager.LoadScene("");
        Debug.Log("research画面は出ないはずだよ");
    }

    public void OnClickStartAuctionButton(){
        SceneManager.LoadScene("Auction");
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

    public void OnClickCheckStatusButton(){
        statusWindow.SetActive(true);
    }

    public void OnClickButton(){
        statusWindow.SetActive(false);
    }

    void ChangeText(){
        Text product1_Text = product1.GetComponent<Text>();
        Text product2_Text = product2.GetComponent<Text>();
        Text product3_Text = product3.GetComponent<Text>();
        Text product4_Text = product4.GetComponent<Text>();

        Text customer1_Text = customer1.GetComponent<Text>();
        Text customer2_Text = customer2.GetComponent<Text>();
        Text customer3_Text = customer3.GetComponent<Text>();
        Text customer4_Text = customer4.GetComponent<Text>();

        Text myMoney_Text = myMoney.GetComponent<Text>();


        //myMoney_Text = 
        product1_Text.text = customerLike1 + "(" + product + "円)";
        customer1_Text.text = customerName1 + "は" + customerLike1 + "が好きだ";
    }

}
