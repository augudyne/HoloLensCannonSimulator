using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseAngleButton : MonoBehaviour
{
    public GameObject Barrel;

    private static int counter = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnSelect()
    {
        Debug.Log("Barrel Rotation #" + counter + ": " + Barrel.GetComponent<Transform>().rotation.eulerAngles);
        counter++;
        Vector3 originalRotation = Barrel.GetComponent<Transform>().rotation.eulerAngles;
        originalRotation.z = Mathf.Clamp(originalRotation.z - 5f, 0, 80);
        Barrel.GetComponent<Transform>().rotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z);

    }
}
