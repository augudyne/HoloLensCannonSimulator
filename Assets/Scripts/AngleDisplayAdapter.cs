using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleDisplayAdapter : MonoBehaviour {

    public GameObject BarrelForAngleDisplay;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float angle = BarrelForAngleDisplay.GetComponent<Transform>().rotation.eulerAngles.z;
        int rounded = Mathf.RoundToInt(angle);
        TextMesh textDisplay = GetComponent<TextMesh>();
        textDisplay.text = "Current Angle:" + rounded;
	}
}
