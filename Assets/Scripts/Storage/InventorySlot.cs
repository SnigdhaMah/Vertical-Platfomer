using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    //reference to iteself
    public Transform itemSlotTemplate;
    public UIInventory uiInventory;
    public Inventory inventory;

    RectTransform slotRectTransform;
    Image image;

    public PlayerHealth health;

    public PlayerController player;
    public NumberOfRocks rockDisplay;

    Item.ItemType type;

    public void Start()
    {
        inventory = uiInventory.GetInventory();

           
    }

    public void Update()
    {
        //if (Camera.main != null)
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //    if (hit.collider != null)
        //    {
        //        Debug.Log("Hit");
        //        Debug.Log("hit size: " + hit.collider.GetComponentInParent<RectTransform>().sizeDelta);
        //    }
        //}

        slotRectTransform = this.GetComponent<RectTransform>();
        image = slotRectTransform.Find("image").GetComponent<Image>();

        
        if (Input.GetMouseButtonDown(0))
        {
            if (image != null)
            {
                if (image.sprite.name.Equals("Key"))
                {
                    type = Item.ItemType.Key;

                }
                else if (image.sprite.name.Equals("HealthCoin"))
                {
                    type = Item.ItemType.HealthCoin;
                }
                else if (image.sprite.name.Equals("RestoreRocks"))
                {
                    type = Item.ItemType.RestoreRocks;
                }
                else
                {
                    Debug.Log("type not found");
                }

                //Debug.Log(type.ToString());
            }

            //use item
            Debug.Log(image.sprite.name + " leftclicked");

            useItem();

            uiInventory.RefreshInventory();


        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (image != null)
            {
                if (image.sprite.name.Equals("Key"))
                {
                    type = Item.ItemType.Key;

                }
                else if (image.sprite.name.Equals("HealthCoin"))
                {
                    type = Item.ItemType.HealthCoin;
                }
                else if (image.sprite.name.Equals("RestoreRocks"))
                {
                    type = Item.ItemType.RestoreRocks;
                }
                else
                {
                    Debug.Log("type not found");
                }

                //Debug.Log(type.ToString());
            }


            //right click => drop item
            Debug.Log(type.ToString() + " rightclicked");

            uiInventory.itemDrop(type);

            inventory.RemoveItem(type);

            uiInventory.RefreshInventory();

        }
    }
    public void useItem()
    {
        //Item removing = null;

        if (type == Item.ItemType.HealthCoin)
        {
            //restore Health
            health.instance.Restore();
            Debug.Log("health restored");

            //removing = new Item { itemType = Item.ItemType.HealthCoin };
            inventory.RemoveItem(type);

        }
        else if (type == Item.ItemType.RestoreRocks)
        {
            //restore ammo
            player.numOfRocks = 3;
            rockDisplay.changeDisplay(3);

            Debug.Log("rocks restored");

            //removing = new Item { itemType = Item.ItemType.HealthCoin };
            inventory.RemoveItem(type);

        } else
        {
            Debug.Log("Wait and keep the key in your inventory so you can unlock the door. The door will open just by hitting the door"
                + " with the key in the inventory.");
        }

    }

}
