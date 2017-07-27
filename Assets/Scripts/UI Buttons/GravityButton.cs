using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour {
    public float gravityValue;

    void OnSelect()
    {
        Component[] siblingMeshs = GetComponent<Transform>().parent.gameObject.GetComponentsInChildren<TextMesh>();
        SendMessageUpwards("GravityChanged", gravityValue);
        foreach (TextMesh c in siblingMeshs)
        {
            c.color = new Color(1, 1, 1, 1);
        }
        CustomGravity.globalGravity = gravityValue;
        GetComponent<TextMesh>().color = new Color(0, 0, 1, 1);
    }
}
