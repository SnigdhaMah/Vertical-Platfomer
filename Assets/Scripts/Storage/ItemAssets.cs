using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    //to access the script
    public static ItemAssets instance { get; private set; }

    void Start()
    {
        instance = this;
    }

    //all the assets 
    public Sprite key;
    public Sprite healthCoin;
    public Sprite restoreRocks;
}
