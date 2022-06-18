using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;
    public UIInventory uIInventory;
    public KeyScript key;
    public Restore rocks;
    public HealthRestore healthCoin;
    public EndDoor endDoor;

    void Start()
    {
        inventory = new Inventory();
        uIInventory.SetInventory(inventory);
        key.SetInventory(inventory);
        rocks.SetInventory(inventory);
        healthCoin.SetInventory(inventory);
        endDoor.SetInventory(inventory);
    }
}
