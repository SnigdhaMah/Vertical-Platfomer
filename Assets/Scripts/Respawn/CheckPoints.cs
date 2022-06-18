using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private GameMaster gm;

    public Sprite checkBefore;
    public Sprite checkAfter;
    private SpriteRenderer checkRenderer;

    Camera cam;
    public CheckPoints other;
    public SpriteRenderer otherSprite;

    // Start is called before the first frame update
    void Start()
    {
        //access main camera
        cam = cam = UnityEngine.Camera.main;

        //make reference to game object
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster> ();

        checkRenderer = GetComponent<SpriteRenderer>();

        //otherSprite = GetComponent<other.SpriteRenderer>();
    }

    void Update()
    {
        //check to see the distance between the main camera and an other checkpoint that is not this one
        //Vector3 viewPosition = cam.WorldToViewportPoint(other.transform.position);

        //if the x and y are between 0 and 1 and z > 0 then it is seen
        //if (viewPosition.x >= 0 && viewPosition.x < 1 && viewPosition.y >= 0 && viewPosition.y < 1 && viewPosition.z > 0)
        //{
            //if an other checkpoint is seen from the main camera
            //if (other.)
        //}
    }

    //if hit the check point 
    void OnTriggerEnter2D (Collider2D other)
    {
        //if hit player
        if (other.CompareTag("Player"))
        {
            //if this is the fartest up checkpoint, save so you can't resave previous checkpoints
            if (transform.position.y > gm.lastCheckpoint.y)
            {
                //set the last checkpoint to where ever this checkpoint is located
                gm.lastCheckpoint = transform.position;
            }
            
            //set the sprite from purple to blue
            checkRenderer.sprite = checkAfter;
        }
    }

    //if this object sees a higher object that is also blue, change the color of the this object back to purple
    /*void resetColor ()
    {

    }*/
}
