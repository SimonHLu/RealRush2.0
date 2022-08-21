using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable  { get{return isPlaceable;}}// this is a property, nothing inside gets altered from outside
    // The property is grouped next to the isPlaceable field for neatness.

    void OnMouseDown() {
        if(isPlaceable)
        {
            bool isPlaced =  towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
