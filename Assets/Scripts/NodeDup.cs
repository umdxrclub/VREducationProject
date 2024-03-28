using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NodeDup : MonoBehaviour

{
    public NodeRep nodeRepPrefab;
    public LinkedList<NodeRep> nodes;

    // Start is called before the first frame update
    void Start()
    {
        // Duplicate();
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

    public void ListenToList<T>(EventLinkedList<T> list)
    {
        void BuildThisList()
        {
            BuildList(list);
        }
        
        list.onListUpdated += BuildThisList;
    }

    /// <summary>
    /// Given any linked list, build the list with nodes, represent their values, and attach them accordingly.
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    private void BuildList<T>(EventLinkedList<T> list)
    {
        // iterate through the linked list 
        // for each node
        //  create a NodeRep
        //  use Display() of the noderep to represent the value of the node in the linkedlist
        //  give it some starting position s.t. all nodes are evenly spaced out
        //  keep track of your previous created node, if it exists, attach the previous to this new one
        NodeRep prev = null;

        // Destroy all my children.
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var value in list)
        {
            NodeRep nodeRep = Instantiate(nodeRepPrefab, transform);
            if (prev)
            {
                nodeRep.transform.position = prev.transform.position + Vector3.right;
            }
            else
            {
                nodeRep.transform.position = (Vector3.up * 1.5f);
            }
            //get BuildList will modify local position of node to be right of position it spawned

            nodeRep.Display(value.ToString(), Color.blue);
            if (prev)
            {
                prev.Link(nodeRep);
            }

            prev = nodeRep;
        }
    }
}