using UnityEngine;

public class PlaceCannonball : MonoBehaviour
{
    public GameObject projectile;

    
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        Debug.Log("OnSelect() in PlaceCannonBall button...creating new ball on the ground.");
        //instantiate a moveable cannonball in front of user
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;

        Vector3 placementLocation = headPosition + gazeDirection * 1.0f;
        
        var newProjectile = Instantiate(projectile, placementLocation, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
