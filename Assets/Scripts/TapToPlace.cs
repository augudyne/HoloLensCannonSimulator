using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlace : MonoBehaviour {

    private bool placing = false;

    void OnSelect()
    {
        Debug.Log("TapToPlace Object was Selected");
        placing = !placing;

        if (placing)
        {
            //in placing mode
            SpatialMapping.Instance.drawVisualMeshes = true;
        } else
        {
            SpatialMapping.Instance.drawVisualMeshes = false;
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (placing) {
            //place the object into the scene using raycast
            var headPosition = Camera.main.GetComponent<Transform>().position;
            var gazeDirection = Camera.main.GetComponent<Transform>().forward;

            RaycastHit hitInfo;

            if(Physics.Raycast(headPosition, gazeDirection, out hitInfo, 10.0f, SpatialMapping.PhysicsRaycastMask))
            {
                GetComponent<Transform>().position = hitInfo.point;

                Quaternion quat = Camera.main.transform.localRotation;
                quat.x = 0;
                quat.z = 0;
                GetComponent<Transform>().rotation = quat;
            }
        }
	}
}
