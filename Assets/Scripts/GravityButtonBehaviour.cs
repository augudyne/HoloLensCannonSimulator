using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonBehaviour : MonoBehaviour {
    public float gravityValue;

    void OnSelect()
    {
        Debug.Log(GetComponent<Transform>().GetComponentInParent<GameObject>());
        Debug.Log(GetComponent<Transform>().parent.gameObject.GetComponentsInChildren<TextMesh>());
        Component[] siblingMeshs = GetComponent<Transform>().parent.gameObject.GetComponentsInChildren<TextMesh>();
        foreach (TextMesh c in siblingMeshs)
        {
            c.color = new Color(1, 1, 1, 1);
        }
        CustomGravity.globalGravity = gravityValue;
        GetComponent<TextMesh>().color = new Color(0, 0, 1, 1);
    }
}
