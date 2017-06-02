using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapToPlace : MonoBehaviour {

    public Material defaultMaterial;
    public Material placementMaterial;
	GameObject grid;

    private GestureRecognizer recognizer;
    private bool placing = true;
    private float zLock;
	Vector3 posToPlaceOnGrid;

    private void Start()
    {
        zLock = GameObject.Find("SpawnPoint").GetComponent<Transform>().position.z;
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            placing = true;
            recognizer.StopCapturingGestures();
        };

		grid = GameObject.Find("Grid");
    }


    void OnSelect()
    {
        Debug.Log("TapToPlace Object was Selected");
        if (!placing)
        {
            placing = true;
        }

        if (placing){
            //in placing mode
            Debug.Log("In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = true;
            recognizer.StartCapturingGestures();
			print("Turn off placing mode!");
			placing = false;
			DisableGrid();
		} else
        {
            Debug.Log("Not In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = false;
			EnableGrid();
		}
    }
	
	// Update is called once per frame
	void Update () {



        if (placing) {
            GetComponent<MeshRenderer>().material = placementMaterial;
			
			// Disable the collisions between the placement cannonballs and the real cannonballs
			//GetComponent<Collider>().enabled = false;
			Physics.IgnoreLayerCollision(8, 9, true);
			Physics.IgnoreLayerCollision(9, 9, true);
			Physics.IgnoreLayerCollision(10, 9, true);


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

	// TODO: click on placement cannonball again to enter placing mode to edit the position of selected placement cannonball
}
