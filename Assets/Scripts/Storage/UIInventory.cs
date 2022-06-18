using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    public UIInventory instance;

    public Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    public GameObject healthCoin;
    public GameObject restoreRocks;
    public GameObject key;

    public Camera cam;

    float slotWidth;
    float slotHeight;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        RectTransform container = itemSlotTemplate.Find("itemContainer").GetComponent<RectTransform>();

        //get the slot dimentions
        slotWidth = container.sizeDelta.x * container.localScale.x;
        slotHeight = container.sizeDelta.y * container.localScale.y;
    }

    public void Update()
    {
        //RefreshInventory();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    //render the inventory
    public void RefreshInventory()
    {
        //get rid of all items to then re add correct ones 
        foreach (Transform child in itemSlotContainer)
        {
            //delete everything that is not the template
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 120f;

        //for each item, make a box
        foreach (Item item in inventory.getItemList())
        {
            //get reference to the container
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();

            //set it to active (it starts as inactive
            itemSlotRectTransform.gameObject.SetActive(true);

            //set location moving to the right
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            //set the sprite on the transform to the correct sprite 
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();

            image.sprite = item.GetSprite();

            RectTransform imageSize = itemSlotRectTransform.Find("image").GetComponent<RectTransform>();

            float width = imageSize.sizeDelta.x * imageSize.localScale.x;
            float height = imageSize.sizeDelta.y * imageSize.localScale.y;

            //move to next location
            x++;

            if (x > 4)
            {
                x = 0;
                y++;
            }


        }
    }

    //drop an item
    public void itemDrop(Item.ItemType type)
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        //show the gameobject again near the player
        if (type == Item.ItemType.HealthCoin)
        {
            healthCoin.SetActive(true);
            healthCoin.transform.position = new Vector2(player.transform.position.x + 2, player.transform.position.y);

        }
        else if (type == Item.ItemType.RestoreRocks)
        {
            restoreRocks.SetActive(true);
            restoreRocks.transform.position = new Vector2(player.transform.position.x + 2, player.transform.position.y);

        }
        else if (type == Item.ItemType.Key)
        {
            key.SetActive(true);
            key.transform.position = new Vector2(player.transform.position.x + 2, player.transform.position.y);

        }

        Debug.Log("Item dropped");
    }
}
