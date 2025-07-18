using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Match3/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;     //Just a  indicator in case of need
    public ColorType colorType; //Color type for clustering
    public Material material;   //Setting the Material
    public int score;           //Point
    public Sprite icon;         //Sprite for selection Menu 
   
}
