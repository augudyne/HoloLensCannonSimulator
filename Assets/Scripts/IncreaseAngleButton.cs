using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAngleButton : MonoBehaviour {
    public GameObject Barrel;
    public float IncreaseInterval;
    private float nextIncrease;
    private static int counter = 0;
	// Use this for initialization
	void Start () {
        nextIncrease = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextIncrease)
        {
            nextIncrease = Time.time + IncreaseInterval;
            OnSelect();
        }
	}

    void OnSelect()
    {
        Debug.Log("Barrel Rotation #" + counter + ": " + Barrel.GetComponent<Transform>().rotation.eulerAngles);
        counter++;
        Vector3 originalRotation = Barrel.GetComponent<Transform>().rotation.eulerAngles;
        originalRotation.z = Mathf.Clamp(originalRotation.z + 5f, 0, 80);
        Barrel.GetComponent<Transform>().rotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z);
        
    }
}
