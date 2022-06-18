using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //this is what the camera will follow
    public GameObject target;
    
    Camera cam;

    public Vector2 cameraBoundaries;

    void Start()
    {
        //access the main camera
        cam = UnityEngine.Camera.main;

        cameraBoundaries = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //just moves with player
        transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);

    }
}
