using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickDetectorForTestingWithoutHololens : MonoBehaviour {

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				print("Name of Object mouse clicked: " + hit.transform.gameObject.name);
				hit.transform.gameObject.SendMessageUpwards("OnSelect");
			}
		}
	}
}
