using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlace : MonoBehaviour {

    public Material defaultMaterial;
    public Material placementMaterial;

    private bool placing = false;
    private float zLock;

    private void Start()
    {
        zLock = GameObject.Find("SpawnPoint").GetComponent<Transform>().position.z;
    }

    void OnSelect()
    {
        Debug.Log("TapToPlace Object was Selected");
        placing = !placing;

        if (placing)
        {
            //in placing mode
            Debug.Log("In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = true;
        } else
        {
            Debug.Log("Not In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = false;
        }
    }
	
	// Update is called once per frame
	void Update () {



        if (placing) {
            GetComponent<MeshRenderer>().material = placementMaterial;
            Vector3 headPosition = Camera.main.GetComponent<Transform>().position;
            Vector3 gazeDirection = Camera.main.GetComponent<Transform>().forward;

            Vector3 resultPosition = headPosition + gazeDirection * 1.0f;
            resultPosition.z = zLock;
            Debug.Log("User Location: " + headPosition);
            Debug.Log("Lock z rotation: " + zLock);
            Debug.Log("Spawn Location: " + GameObject.Find("SpawnPoint").GetComponent<Transform>().position);
            Debug.Log("Instantiation Location: " + resultPosition);
            GetComponent<Transform>().position = resultPosition;
        } else
        {
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }
	}
}
