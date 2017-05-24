using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        //destroy the other object
        if (other != null)
        {
            Destroy(other.gameObject);
        }
    }
}
