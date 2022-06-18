using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public Item instance;
    public Item()
    {
        instance = this;
    }

    public enum ItemType
    {
        Key,
        HealthCoin,
        RestoreRocks,

    }

    public ItemType itemType;
    public int amount; 
    
    public Sprite GetSprite ()
    {
        switch(itemType)
        {
            default:
            case ItemType.Key:              return ItemAssets.instance.key;
            case ItemType.HealthCoin:       return ItemAssets.instance.healthCoin;
            case ItemType.RestoreRocks:     return ItemAssets.instance.restoreRocks;

        }
    }
 
    //is stackable?
    public bool IsStackable()
    {
        switch(itemType)
        {
        default:
        case ItemType.HealthCoin:
        case ItemType.RestoreRocks:
            return true;
        case ItemType.Key:
            return false;

        }
    }

}
