using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapToPlace : MonoBehaviour {

    private GameObject errorDisplay;

    public Material defaultMaterial;
    public Material placementMaterial;
    
	GameObject grid;

    private GestureRecognizer recognizer;
    private bool placing = false;
    private float zLock;
	private Vector3 posToPlaceOnGrid;
    



    private const int CANNONBALL_LAYER = 8;
    private const int MARKER_LAYER = 9;
    private const int GRID_LAYER = 10;


    private Vector3 intendedPosition;

    private void Start()
    {
        zLock = GameObject.Find("SpawnPoint").GetComponent<Transform>().position.z;
        errorDisplay = GameObject.Find("Error Display");
        grid = GameObject.Find("Grid");
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            //show the placement information
            errorDisplay.GetComponent<TextMesh>().text = "Error: " + getError();
            placing = false;
            recognizer.StopCapturingGestures();
        };

		
        
    }


    void OnSelect()
    {
        Debug.Log("TapToPlace Object was Selected");

        //only toggle to placing mode on click select. Only exits placement mode via gestureRecognizer (tap)
        if (!placing)
        {
            placing = true;
        }

        if (placing){
            //in placing mode
            Debug.Log("In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = true;
            recognizer.StartCapturingGestures();
            EnableGrid();
            
		} else
        {
            DisableGrid();
            Debug.Log("Not In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = false;
            errorDisplay.GetComponent<TextMesh>().text = "Error: " + getError();
		}
    }
	
	// Update is called once per frame
	void Update () {



        if (placing) {
            GetComponent<MeshRenderer>().material = placementMaterial;
			
			// Disable the collisions between the placement cannonballs and the real cannonballs
			//GetComponent<Collider>().enabled = false;
			Physics.IgnoreLayerCollision(CANNONBALL_LAYER, MARKER_LAYER, true);
			Physics.IgnoreLayerCollision(MARKER_LAYER, MARKER_LAYER, true);
			Physics.IgnoreLayerCollision(GRID_LAYER, MARKER_LAYER, true);


			RayStuff();

			//Vector3 headPosition = Camera.main.GetComponent<Transform>().position;
            //Vector3 gazeDirection = Camera.main.GetComponent<Transform>().forward;

            //Vector3 resultPosition = headPosition + gazeDirection * 1.0f;
            //resultPosition.z = zLock;
			//Debug.Log("User Location: " + headPosition);
			//Debug.Log("Lock z rotation: " + zLock);
			//Debug.Log("Spawn Location: " + GameObject.Find("SpawnPoint").GetComponent<Transform>().position);
			//Debug.Log("Instantiation Location: " + resultPosition);
			//GetComponent<Transform>().position = resultPosition;
			GetComponent<Transform>().position = posToPlaceOnGrid;
        } else
        {
            GetComponent<Collider>().enabled =true;
            GetComponent<MeshRenderer>().material = defaultMaterial;

			
		}
	}

	void RayStuff() {
		RaycastHit hit;
		Vector3 headPosition = Camera.main.GetComponent<Transform>().position;
		Vector3 gazeDirection = Camera.main.GetComponent<Transform>().forward;

		if (Physics.Raycast(headPosition, gazeDirection, out hit, 100f)) {
			posToPlaceOnGrid = hit.point;
			posToPlaceOnGrid.z = zLock;
		}
	}

	void EnableGrid() {
		if(!grid.activeSelf) grid.SetActive(true);
	}

	void DisableGrid() {
		if (grid.activeSelf) grid.SetActive(false);
	}

	public void setIntendedPosition(Vector3 position)
    {
        intendedPosition = position;
    }



    //return the error between its current position and `he intended location
    float getError()
    {
        return Vector3.Distance(intendedPosition, GetComponent<Transform>().position);

    }
}
