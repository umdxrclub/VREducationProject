using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDup : MonoBehaviour
    
{
    public NodeRep nodeRepPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Duplicate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Duplicate()
    {
        NodeRep nodeRep = Instantiate(nodeRepPrefab);
      
    }
    
}
