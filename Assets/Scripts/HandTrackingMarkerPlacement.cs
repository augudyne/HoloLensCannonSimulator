using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

// Place script on object you want to place markers on with your hand (ex. Grid)

public class HandTrackingMarkerPlacement : HandGuidance {

	[Tooltip("The indicator for when use enters placing mode")]
	public GameObject placingModeIndicator;

	[Tooltip("Marker GameObject to place on Grid")]
	public GameObject markerGO;

	private bool placingMode;
	private List<GameObject> markers;

	void Start() {
		markers = new List<GameObject>();
		for(int i = 0; i < 10; i++)
		{
			GameObject marker = Instantiate(markerGO);
			marker.name = "Marker: " + i;
			marker.SetActive(false);
			markers.Add(marker);
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
		GameObject handGO = HandGuidance.Instance.returnHandGuidanceIndicatorGameobject();
		Vector3 handPos = handGO.transform.position;
		RaycastHit hit;
		Vector3 handDir = Vector3.forward;

		if (Physics.Raycast(handPos, handDir, out hit, 100f))
		{
			// Enter placing mode + show a marker on the hand
			placingMode = true;
			HandGuidance.Instance.setHandGuidanceIndicatorGameobject(placingModeIndicator);
		}
		else
		{
			placingMode = false;
			HandGuidance.Instance.setHandGuidanceIndicatorGameobject(HandGuidance.Instance.HandGuidanceIndicator);
		}
		
	}

	void PlaceMarker()
	{
		print("Attempting to place marker");
		if (placingMode)
		{
			print("Placed marker");
			GameObject marker = markers[0];
			markers.RemoveAt(0);

			Vector3 handPos = HandGuidance.Instance.returnHandGuidanceIndicatorGameobject().transform.position;
			Vector3 markerPos = new Vector3(handPos.x, handPos.y, this.transform.position.z);

			marker.transform.position = markerPos;
			marker.SetActive(true);
		}
	}
}
