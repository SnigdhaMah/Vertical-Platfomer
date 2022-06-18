using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //stores positions
    GameObject[] tiles;
    ArrayList leftSides = new ArrayList();
    ArrayList rightSides = new ArrayList();
    ArrayList elevation = new ArrayList();

    int index;

    //location when iterating thru tiles
    public Edges edge;

    public PlayerController player;
    GameObject option;
    public GameObject optionL;
    public GameObject optionR;

    public Portal portalLeft;
    public Portal portalRight;

    public Portal start;
    public Portal end;

    //where player wants the portal
    public Vector2 finalLocation;

    public Camera main;
    public Camera seeOptions;

    //portal states
    public enum PortalState
    {
        None,
        PortalEnabled, // maps to key 1
        PortalLocationShopping, // maps to key 2
        PortalPlaced // maps to key 3
    };

    private PortalState state = PortalState.None;


    // Start is called before the first frame update
    void Start()
    {
        //find the locations of the end of each tile and save coordinate

        //all of the grass tiles
        tiles = GameObject.FindGameObjectsWithTag("Grass");


        //iterate through and store possible places to put portal
        foreach (GameObject tile in tiles)
        {
            edge = tile.GetComponent<Edges>();

            //Arraylists contain positions
            leftSides.Add(edge.leftEdge.position.x);
            rightSides.Add(edge.rightEdge.position.x);

            //the y value is always 1.76 ABOVE THE TILE
            //the elevation is equal on both sides.
            elevation.Add(edge.transform.position.y + 1.76f);
        }

    }


    // Update is called once per frame
    void Update()
    {

        //if nothing is pressed, do nothing
        if (!Input.anyKeyDown) return;

        //something must have been pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnablePortal();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowNextPortalLocation();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlacePortal();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DeletePortals();
        }

    }


    void EnablePortal()
    {
        //if nothing has been done yet
        if (state == PortalState.None)
        {
            state = PortalState.PortalEnabled;

            //place first portal at first position
            index = 0;

            if (player.facingRight)
            {
                // O ->      )
                Debug.Log("true");

                Vector2 playerLocation = new Vector2(player.transform.position.x + 2, player.transform.position.y);
                start = Instantiate(portalLeft, playerLocation, transform.rotation);

                Vector2 position = new Vector2((float)rightSides[index], (float)elevation[index]);
                option = Instantiate(optionL, position, transform.rotation);

            }
            else
            {
                // (          <- O
                //make the initial portal 
                Debug.Log("false");

                Vector2 playerLocation = new Vector2(player.transform.position.x - 2, player.transform.position.y);
                start = Instantiate(portalLeft, playerLocation, transform.rotation);

                //for some reason this is showing the rightsides, optionL combo...
                Vector2 position = new Vector2((float)leftSides[index], (float)elevation[index]);
                option = Instantiate(optionR, position, transform.rotation);

            }

        }
    }

    void ShowNextPortalLocation()
    {
        //if the 1 or 2 (loop) has been pressed
        if (state == PortalState.PortalEnabled || state == PortalState.PortalLocationShopping)
        {
            state = PortalState.PortalLocationShopping;

            //change camera
            seeOptions.enabled = true;
            main.enabled = false;

            CameraType();

            // remember the previous location and just increment it by 1
            //move to the next option
            if (index < rightSides.Count)
            {
                index++;
                Debug.Log(index);

                Vector2 next = new Vector2((float)rightSides[index], (float)elevation[index]);
                option.transform.position = next;
            }
            else if (index == tiles.Length - 1)
            {
                //if at the end, cycle back to the beginning
                index = -1;
            }


        }
    }

    void PlacePortal()
    {
        //if one of two has been pressed
        if (state == PortalState.PortalEnabled || state == PortalState.PortalLocationShopping)
        {

            //go back to waiting
            state = PortalState.None;

            // actually place the portal

            //place portal where the option is currently
            finalLocation = option.transform.position;

            //get rid of option
            Destroy(option.gameObject);


            if (player.facingRight)
            {
                end = Instantiate(portalLeft, finalLocation, transform.rotation);
            }
            else
            {
                end = Instantiate(portalRight, finalLocation, transform.rotation);

            }

            start.connection = end;
            end.connection = start;

            StartCoroutine("cameraDelay");
        }
    }

    void DeletePortals()
    {
        if (start != null && end != null)
        {
            //delete recent portals
            Destroy(start.gameObject);
            Destroy(end.gameObject);
        }
        else if (start != null && option != null)
        {
            //if accidentally started portal creation
            //delete recent portals
            Destroy(start.gameObject);
            Destroy(option.gameObject);

            StartCoroutine("cameraDelay");

        }
        else
        {
            GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
            foreach (GameObject p in portals)
            {
                Destroy(p.gameObject);
            }
        }
        state = PortalState.None;

    }

    public IEnumerator cameraDelay()
    {
        //if you want to go back to normal
        yield return new WaitForSeconds(1f);

        //revert camera to normal
        seeOptions.enabled = false;
        main.enabled = true;


    }

    public Camera CameraType()
    {
        if (main.enabled == true)
        {
            return main;
        } else
        {
            return seeOptions;
        }
    }
}
