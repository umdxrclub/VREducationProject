using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityEvent onMyEventTriggered;

    public void Start()
    {
        onMyEventTriggered.AddListener(DoSomething);
        onMyEventTriggered.Invoke();
    }


    private void DoSomething()
    {
        Debug.Log("I did something!");
    }

    private void Update()
    {
        
    }
}
