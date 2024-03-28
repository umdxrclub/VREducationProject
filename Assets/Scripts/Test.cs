using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public NodeDup dup;
    
    public void Start()
    {
        var ll = new EventLinkedList<int>();
        dup.ListenToList(ll);
        ll.onAddToLast += NewElementWasAdded;

        StartCoroutine(AddToLastCoroutine(ll));
    }

    private IEnumerator AddToLastCoroutine(EventLinkedList<int> list)
    {
        for (var i = 0; i < 5; i ++)
        {
            list.AddLast(i + 1);
            yield return new WaitForSeconds(1f);
        }
        
        for (var i = 0; i < 5; i ++)
        {
            list.RemoveLast();
            yield return new WaitForSeconds(1f);
        }
    }

    private void NewElementWasAdded(int x)
    {
        Debug.Log("A new number was added! It was: " + x);
    }
}
