using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MatchItem : MonoBehaviour
{
    public ItemData itemData; 

    private void Start()
    {
        Debug.Log($"[MatchItem] {gameObject.name} - Start() called");

        if (itemData != null && itemData.material != null)
        {
            GetComponent<Renderer>().material = itemData.material;
            Debug.Log($"[MatchItem] {gameObject.name} - Material set to {itemData.material.name}");
        }
        else
        {
            Debug.LogWarning($"[MatchItem] {gameObject.name} - Missing itemData or material!");
        }
    }


    public ColorType GetColorType()
    {
        return itemData != null ? itemData.colorType : ColorType.Red;
    }

    public int GetScore()
    {
        return itemData != null ? itemData.score : 0;
        
    }
}
