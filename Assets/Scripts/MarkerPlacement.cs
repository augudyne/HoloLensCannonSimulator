using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;

public class MarkerPlacement : MonoBehaviour {

	[Tooltip("The indicator for when use enters placing mode")]
	public GameObject placingModeIndicator;

	[Tooltip("Marker GameObject to place on Grid")]
	public GameObject markerGO;

	private bool placingMode;
	private List<GameObject> unusedMarkers;

	void Start()
	{
		unusedMarkers = new List<GameObject>();
		for (int i = 0; i < 10; i++)
		{
			GameObject marker = Instantiate(markerGO);
			marker.name = "Marker: " + i;
			marker.SetActive(false);
			unusedMarkers.Add(marker);
		}
	}

	void Update()
	{
		EnterPlacingModeUponBeingInFrontOfGrid();
	}

	// if all pre-requisites pass, put us into placing mode and spawn a marker on the cursor
	void OnSelect()
	{
		PlaceMarker();
	}

	// Sort of self-explanatory innit?
	void EnterPlacingModeUponBeingInFrontOfGrid()
	{
		Vector3 handPos = GestureManager.Instance.NavigationPosition;
		RaycastHit hit;
		Vector3 handDir = Vector3.forward;

		if (Physics.Raycast(handPos, handDir, out hit, 100f))
		{
			// Enter placing mode + show a marker on the hand
			placingMode = true;
			// TODO: Change the hand visual to one that says it's in placing mode
		}
		else
		{
			placingMode = false;
			// TODO: keep hand visual normal (not in placing mode)
		}

	}

	void PlaceMarker()
	{
		print("Attempting to place marker");
		if (placingMode)
		{
			print("Placed marker");
			GameObject marker = unusedMarkers[0];
			unusedMarkers.RemoveAt(0);

			Vector3 handPos = GestureManager.Instance.NavigationPosition;
			Vector3 markerPos = new Vector3(handPos.x, handPos.y, this.transform.position.z);

			marker.transform.position = markerPos;
			marker.SetActive(true);

			//TODO: Have to add the markers back to unusedMarkers array after resetting markers
		}
	}
}
