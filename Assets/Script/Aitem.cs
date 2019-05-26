using UnityEngine;
using UnityEngine.UI;

public enum AitemType { 絵画,彫刻,骨董品 }

[CreateAssetMenu(menuName ="Aitem/Aitemparamete",fileName = "Aitemparamete")]
public class Aitem : ScriptableObject
{

    [SerializeField]
    [HeaderAttribute("アイテムの画像")]
    public　Sprite aitemImage;
    [SerializeField]
    [HeaderAttribute("アイテム名")]
    public string aitemName;

    [SerializeField]
    [HeaderAttribute("アイテムの種類")]
    public AitemType aitemType;

    [SerializeField]
    [HeaderAttribute("購入金額")]
    public int purchasePrice =1000;

    [SerializeField]
    [HeaderAttribute("スタート時の金額")]
    public int startPrice = 700;

}
