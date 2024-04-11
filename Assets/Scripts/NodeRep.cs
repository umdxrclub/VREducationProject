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
    private NodeRep nextNode;
    private float threshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
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
        
        if (nextNode && (interactable.isSelected || nextNode.interactable.isSelected))
        {
            float distance = Vector3.Distance(this.transform.position, nextNode.transform.position);
            if (distance > threshold)
            {
                this.Link(null);
                
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
        nextNode = other;

        // Temporary "hack" to prevent grabbing the nodes if they are linked to anything.
        interactable.interactionLayers = other ? 0 : ~0;
        
        // If other is valid, set attach to other.ending 
        if (other)
        {
            attach = other.ending;
        }
        else
        {
            attach = null;
            Debug.Log("Its broken");
            onNodeLinkBroken?.Invoke();
        }

        
    }
}