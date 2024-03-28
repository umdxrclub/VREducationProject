using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeRep : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public TextMeshProUGUI textLabel;
    public Graphic graphic;
    public NodeDup nodeDup;

    public Transform origin;

    public Transform attach;

    public Transform ending;

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
        // If other is valid, set attach to other.ending 
        if (other)
        {
            attach = other.ending;
        }
        else
        {
            attach = null;
        }
    }
}