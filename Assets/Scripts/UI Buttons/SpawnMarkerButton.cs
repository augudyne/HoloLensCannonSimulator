using UnityEngine;

public class SpawnMarkerButton : MonoBehaviour
{
    public GameObject projectile;
    public GameObject theCannon;
	public GameObject grid;
    private int placementCounter = 0;
    private Vector3[] intendedPositions = new Vector3[5];

    
    
    //when a parameter has changed, reset the "game state" in the marker button
    public void updatePositions()
    {
        Debug.Log("Fetching Positions");
        Vector3[] positions = theCannon.GetComponent<CannonBehaviour>().generatePositions();
        placementCounter = 0;

        //truncate the generated positions, taking only every 15 frames (half second presumably)
        for(int i = 0; i < 5; i++)
        {
            intendedPositions[i] = positions[(i+1) * 15];
        }

        Debug.Log("Intended positions: " + intendedPositions);
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if (placementCounter < 5)
        {
            Debug.Log("OnSelect() in PlaceCannonBall button...creating new ball.");
            //instantiate a moveable cannonball in front of user
            Vector3 headPosition = Camera.main.transform.position;
            Vector3 gazeDirection = Camera.main.transform.forward;

            //Debug.Log("User Location: " + headPosition);


            Vector3 placementLocation = headPosition + gazeDirection * 0.5f;

            //Debug.Log("Instantiation Location: " + placementLocation);
            var newProjectile = Instantiate(projectile, placementLocation, Quaternion.identity);
            newProjectile.GetComponent<TapToPlace>().setIntendedPosition(intendedPositions[placementCounter++]);

            EnableGrid();
        }
        else
        {
            Debug.Log("OnSelect() in PLaceCannonBall button, but exceeded placement amount...");
        }
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
