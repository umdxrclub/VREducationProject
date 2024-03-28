using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListLoader : MonoBehaviour
{
    public NodeDup duplicator;

    private void Start()
    {
        var ll = new LinkedList<int>();
        for (var i = 0; i < 5; i++)
        {
            ll.AddLast(i + 1);
        }
    }
}
