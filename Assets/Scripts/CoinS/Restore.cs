using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : MonoBehaviour
{

    public PlayerController player;
    public NumberOfRocks rockDisplay;
    public float respawnDelay;
    public Inventory inventory;
    public UIInventory uiInventory;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f));
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Item i = new Item { itemType = Item.ItemType.RestoreRocks, amount = 1 };
            inventory.AddItem(i);
            uiInventory.RefreshInventory();

            //hide object
            this.gameObject.SetActive(false);

        }
    }

}
