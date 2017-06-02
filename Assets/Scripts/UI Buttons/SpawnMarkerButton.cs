using UnityEngine;

public class SpawnMarkerButton : MonoBehaviour
{
    public GameObject projectile;

	public GameObject grid;
    
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        Debug.Log("OnSelect() in PlaceCannonBall button...creating new ball.");
        //instantiate a moveable cannonball in front of user
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;

        //Debug.Log("User Location: " + headPosition);


        Vector3 placementLocation = headPosition + gazeDirection * 0.5f;

        //Debug.Log("Instantiation Location: " + placementLocation);
        var newProjectile = Instantiate(projectile, placementLocation, Quaternion.identity);

		EnableGrid();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

	void EnableGrid() {
		// TODO: make a grid visible
		grid.SetActive(true);
	}
}
