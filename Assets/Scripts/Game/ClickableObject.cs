using UnityEngine;

[RequireComponent(typeof(MatchItem))]//Guarantees that matchitem component is present thus errors are prevented.
public class ClickableObject : MonoBehaviour
{
    private MatchItem item;

    private void Awake()
    {
        item = GetComponent<MatchItem>();
    }

    private void OnMouseDown()
    {
        
        if (MatchManager.Instance.selectedItems.Contains(item)) //Does nothing if selected item is alredy on the list
            return;

        MatchManager.Instance.SelectItem(item); //Selects the item if it is not on the list
        
        Debug.Log($"{gameObject.name} clicked — {item.GetColorType()}"); //For debugging purposes

        if (item.itemData != null)
        {
            UIManager.Instance.ShowItemIcon(item.itemData.icon);
        }
    }

}
