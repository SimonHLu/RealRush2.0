using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // acess to textmeshpro
[ExecuteAlways] // Executes in edit mode and in play mode.
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() {
        {
            label = GetComponent<TextMeshPro>();
            label.enabled = false;
            waypoint = GetComponentInParent<Waypoint>();    
            DisplayCoordinates();
            
        }

    }
        void Update()
    {
        if(!Application.isPlaying) // Makes it EDIT MODE ONLY. All inside only work in EDIT.
        {
            DisplayCoordinates();
            UpdateObjectName();
            
        }
        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockColor;
        }
    }
    // Update is called once per frame


    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z );
        label.text = coordinates.x + "," + coordinates.y;
        label.enabled = true;
    }

    void UpdateObjectName() // This only updates hierarchy coordinate names.
    {
        transform.parent.name = coordinates.ToString(); // To string is the way to let it print out the letters.
    }
}
