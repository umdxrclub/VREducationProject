using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRepStylizer : MonoBehaviour
{
    public NodeRep node;


    // Start is called before the first frame update
    void Start()
    {
        node.Display(42.ToString(), Color.blue); 
        LinkedList<int> list = new LinkedList<int>();
        list.AddFirst(5);
        list.AddAfter(list.First, 10);
        list.AddAfter(list.Last, 15);
        list.AddAfter(list.Last, 20);
        list.AddAfter(list.Last, 25);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
