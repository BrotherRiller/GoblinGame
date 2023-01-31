using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Camera))]

public class TargetCanvasTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] float textOffset;

    private Camera cam;
    GUIStyle style = new GUIStyle();
    char[] trimmer = { '(', ')', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    List<string> tagName = new List<string> { "Orlag", "SawmillBuilding", "MasonBuilding", "FoodBuilding", "WealthResource", "FoodResource", "StoneResource", "WoodResource", "Interactable" };

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    public void FixedUpdate() //Hat Festgelegte 50 Aufrufe pro Sekunde
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 30f))
        {
            if (tagName.Contains(hit.transform.tag))
            {
                string name = hit.transform.gameObject.name;

                name = name.Trim(trimmer);

                targetText.text = name;

                textOffset = hit.transform.GetComponent<Collider>().bounds.size.y;

                Vector3 posTarget = hit.transform.position;

                Vector2 posTextOnCanvas = cam.WorldToScreenPoint(posTarget + Vector3.up * textOffset);

                targetText.transform.position = posTextOnCanvas;
                
            }
        }
        else
        {
            targetText.text = "";
        }
    }
    private void OnGUI()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            if (hit.transform.tag == "sign")
            {
                style.fontSize = 80;
                style.normal.textColor = Color.white;
                style.padding = new RectOffset();
                GUI.Label(new Rect(500, 300, 300, 50), "Buy a Building.", style);
                GUI.Label(new Rect(500, 400, 300, 50), "Press 1: Sawmill (20 Wood, 5 Stone)", style);
                GUI.Label(new Rect(500, 500, 300, 50), "Press 2: Mason (10 Wood, 20 Stone)", style);
                GUI.Label(new Rect(500, 600, 300, 50), "Press 3: Farmhous (10 Wood, 10 Stone)", style);
            }
            if(hit.transform.tag == "WorkerSign")
            {
                style.fontSize = 80;
                style.normal.textColor = Color.white;
                style.padding = new RectOffset();
                GUI.Label(new Rect(500, 400, 300, 50), "Click to buy a Worker (5 Wood)", style);
                
            }
        }
    }
}
