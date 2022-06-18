using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    public PlayerHealth health;
    public Inventory inventory;
    public UIInventory uiInventory;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerHealth>();

    }
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
            //Destroy(gameObject);

            //add to inventory
            Item i = new Item { itemType = Item.ItemType.HealthCoin, amount = 1 };
            inventory.AddItem(i);
            uiInventory.RefreshInventory();

            this.gameObject.SetActive(false);

        }
    }

}


