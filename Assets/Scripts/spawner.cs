using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script tied to the spawner object
public class spawner : MonoBehaviour
{
    public NodeRep cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        // Hard coded linked list. This will be pulled from interpreter in the future
        // go over the linked list and spawn a cube for each node
    }

    // Update is called once per frame
    void Update()
    {
        // not using it for the moment
    }


    void spawn()
    {
        Instantiate(cubePrefab); // spawn a cube and arrow
        // move spawner to the right
    }
}
