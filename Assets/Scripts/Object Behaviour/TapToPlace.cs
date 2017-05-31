using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapToPlace : MonoBehaviour {

    public Material defaultMaterial;
    public Material placementMaterial;

    private GestureRecognizer recognizer;
    private bool placing = false;
    private float zLock;

    private void Start()
    {
        zLock = GameObject.Find("SpawnPoint").GetComponent<Transform>().position.z;
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            placing = false;
            recognizer.StopCapturingGestures();
        };
    }


    void OnSelect()
    {
        Debug.Log("TapToPlace Object was Selected");
        if (!placing)
        {
            placing = true;
        }

        if (placing)
        {
            //in placing mode
            Debug.Log("In Placing Mode");
            SpatialMapping.Instance.drawVisualMeshes = true;
            recognizer.StartCapturingGestures();
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
            GetComponent<Collider>().enabled = false;
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
            GetComponent<Collider>().enabled =true;
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }
	}
}
