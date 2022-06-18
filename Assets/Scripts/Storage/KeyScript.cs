using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Item key;
    public Inventory inventory;
    public UIInventory uiInventory;

    public bool hit;

    void Start()
    {
        //make a key item
        if (key == null)
        {
            key = new Item { itemType = Item.ItemType.Key, amount = 1 };
        }
        hit = false;
    
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hit = true;
            //add to inventory
            inventory.AddItem(key);
            uiInventory.RefreshInventory();
            
            this.gameObject.SetActive(false);

            //remove key from world
            //Destroy(this.gameObject);
        }
    }
}
