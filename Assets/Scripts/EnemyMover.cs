using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); // 'path' is variable, = new List<Way... is initializing that new list.
    [SerializeField] [Range(0f, 5f)]float speed = 1f; // becareful, speed can be both positive and negative. The range caps it from escaping the bounds.
    Enemy enemy; // access to enemy script
    // Start is called before the first frame update
    void OnEnable()
    {  
        FindPath();  
        ReturnToStart();  
        StartCoroutine(FollowPath());
    }
    void Start() 
    {
       enemy = GetComponent<Enemy>(); // This variable holds info coming from Type Enemy
    }

    void FindPath()
    {
        path.Clear();  // empties the list to ZERO 
        GameObject parent = GameObject.FindGameObjectWithTag("Path"); // This is an array, find all objects with tag 'Path'. We need it to become a list.
        foreach(Transform child in parent.transform) // This loops through each and every array point
        {
            Waypoint waypoint = child.GetComponent<Waypoint>(); //guard against missplaced objects with no waypoints
            if(waypoint != null)
            {
                path.Add(waypoint);// This adds the array objects to the LIST. In List<Waypoint>
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while(travelPercent < 1f) // while not at our end position
            {
                travelPercent += Time.deltaTime * speed; // update travel % with time of frames elapsing
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent); // move position of the RAM
                yield return new WaitForEndOfFrame(); // yield back to the update function, until the end of the frame is completed
            }
        }
    FinishPath();
        
    }

}
