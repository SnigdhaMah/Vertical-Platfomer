using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;
    //the only point of this class is to store the last checkpoint location, and let other scripts reference it.
    public Vector2 lastCheckpoint;

    public int savedScore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            //make sure the object is not destroyed when the scene reloads
            DontDestroyOnLoad(instance);

        }
        else
        {
            //destroy this game object if there is alreay one in the scene
            Destroy(gameObject);
        }
    }
}

