using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDup : MonoBehaviour

{
    public NodeRep nodeRepPrefab;
    public LinkedList<NodeRep> nodes;

    public NodeRep a;
    public NodeRep b;


    // Start is called before the first frame update
    void Start()
    {
        // Duplicate();
        a.Attach(b);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Duplicate()
    {
        NodeRep nodeRep = Instantiate(nodeRepPrefab);
        nodes.AddLast(nodeRep);
    }

    /// <summary>
    /// Given any linked list, build the list with nodes, represent their values, and attach them accordingly.
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    public void BuildList<T>(LinkedList<T> list)
    {
        // iterate through the linked list 
        // for each node
        //  create a NodeRep
        //  use Display() of the noderep to represent the value of the node in the linkedlist
        //  give it some starting position s.t. all nodes are evenly spaced out
        //  keep track of your previous created node, if it exists, attach the previous to this new one
        NodeRep prev = null;

        foreach (var value in list)
        {
            NodeRep nodeRep = Instantiate(nodeRepPrefab);


            nodeRep.Display(value.ToString(), Color.blue);
            if (prev)
            {
                prev.Attach(nodeRep);
            }

            prev = nodeRep;
        }
    }
}