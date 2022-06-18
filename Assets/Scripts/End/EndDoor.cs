using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    public Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        Debug.Log(inventory);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inventory.FindKey())
        {
            Destroy(this.gameObject);
        }
    }
}
