using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPage : MonoBehaviour
{
    [SerializeField] private Item itemPrefab;
    [SerializeField] private RectTransform chestContent;
    [SerializeField] private RectTransform barContent;
    List<Item> listOfChestItems = new List<Item>();
    List<Item> listOfBarItems = new List<Item>();

    public void InitializeUI(int cSize, int hbSize){
        for(int i = 0; i < cSize; i++)
        {
            Item item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(chestContent);
            listOfChestItems.Add(item);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
        }
        for(int i = 0; i < hbSize; i++)
        {
            Item item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(barContent);
            listOfBarItems.Add(item);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
        }
    }

    public void HandleItemSelection(Item obj)
    {
        
    }

    public void HandleBeginDrag(Item obj)
    {

    }

    public void HandleSwap(Item obj)
    {

    }

    public void HandleEndDrag(Item obj)
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
