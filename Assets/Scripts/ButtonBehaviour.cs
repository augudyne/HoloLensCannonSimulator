using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public void OnSelect()
    {
        Debug.Log("Inside OnSelect of ButtonBehaviour");
        Rigidbody myRB = GetComponent<Rigidbody>();
        if (!myRB)
        {
            myRB = this.GetComponent<GameObject>().AddComponent<Rigidbody>();
        }
        myRB.angularVelocity = new Vector3(0.5f, 0f, 0f);
    }
}
