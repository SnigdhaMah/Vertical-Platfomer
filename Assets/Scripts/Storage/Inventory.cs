using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Inventory instance;
    public UIInventory uIInventory;
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

    }

    public void SetUIInventory (UIInventory uIInventory)
    {
        this.uIInventory = uIInventory;
    }

    public void AddItem(Item i)
    {
        if (i.IsStackable())
        {
            bool itemInInventory = false;
            Item existingItem = new Item();

            //check if i's itemtype exisits in inventory
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == i.itemType)
                {
                    itemInInventory = true;
                    existingItem = inventoryItem;
                }
            }
            //item isn't in inventory yet
            if (!itemInInventory)
            {
                itemList.Add(i);
            }
            else
            {
                //item type is in inventory
                existingItem.amount += i.amount;

            }
        }
        else
        {
            itemList.Add(i);
        }
    }

    public List<Item> getItemList()
    {
        return itemList;
    }

    public Item getItem(string name)
    {
        //convert string to itemtype
        Item.ItemType type;
        if (Enum.TryParse(name, out type))
        {
            foreach (var i in itemList)
            {
                if (i.itemType == type)
                {
                    return i;
                }
            }
        }
        return null; 
    }

    public bool FindKey ()
    {
        foreach (var i in itemList)
        {
            if (i.itemType == Item.ItemType.Key)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Item.ItemType type)
    {
               
        Debug.Log("target: " + type.ToString());

        Item itemInInventory = null;

        Debug.Log("itemList amount: " + itemList.Count);

        for (int i = 0; i < itemList.Count; i++)
        {
            itemInInventory = itemList[i];
            Debug.Log("currentItem: " + itemInInventory.itemType.ToString());


            //if found, remove and leave
            if (itemInInventory != null && itemInInventory.itemType.Equals(type))
            {
                itemList.Remove(itemInInventory);
                Debug.Log("Item removed");
                break;
            }
        }


    }

}
