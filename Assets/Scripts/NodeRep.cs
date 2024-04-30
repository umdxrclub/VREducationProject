using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class NodeRep : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public TextMeshProUGUI textLabel;
    public Graphic graphic;
    public XRGrabInteractable interactable;

    public UnityEvent onNodeLinkBroken;

    public Transform origin;
    public Transform attach;
    public Transform ending;
    public NodeRep prev;
    private NodeRep nextNode;
    public float threshold = 1f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
        interactable.selectExited.AddListener(OnNodeDeSelected);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = attach;
        // Set the LineRenderer points to be between these two positions using lineRenderer.SetPOsition?
        if (attach)
        {
            // Get the world space position of the origin using orign.position
            var or_pos = origin.position;

            // Get the world space position of the attach using attach.transform
            var attach_pos = attach.position;
            lineRenderer.SetPosition(0, or_pos);

            lineRenderer.SetPosition(1, attach_pos);

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("i entered");
    }

    private void OnNodeDeSelected(SelectExitEventArgs args)
    {
        if (prev)
        {
            float distance = Vector3.Distance(prev.transform.position, transform.position);
            if (distance > threshold)
            {
                prev.Link(null);
                
            }
        }
    }
    
    private void LineUpdate()
    {
    }

    public void Display(string val, Color color)
    {
        textLabel.text = val;
        graphic.color = color;
    }

    public void Link(NodeRep other)
    {
        if (nextNode)
        {
            nextNode.prev = null;
        }   
        
        nextNode = other;

        // Temporary "hack" to prevent grabbing the nodes if they are linked to anything.
        interactable.interactionLayers = other ? 0 : ~0;
        
        // If other is valid, set attach to other.ending 
        if (other )
        {
            attach = other.ending;
            other.prev = this;
        }
        else
        {
            attach = null;
            Debug.Log("Its broken");
            onNodeLinkBroken?.Invoke();
        }

        
    }
    
    
}