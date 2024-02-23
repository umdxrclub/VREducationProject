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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LineUpdate()
    {
        
    }
    public void Display(string val, Color color)
    {
        textLabel.text = val;
        graphic.color = color;
    }
    public NodeRep next()
    {

    }
}
