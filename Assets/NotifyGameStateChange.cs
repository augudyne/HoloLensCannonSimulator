using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyGameStateChange : MonoBehaviour {
    public GameObject STATE_MANAGER; //currently the create marker button

	void OnSelect()
    {
        Debug.Log("A button on UIView was selected, game state changed...update!");
        //update the game state button
        STATE_MANAGER.GetComponent<SpawnMarkerButton>().updatePositions();

        GameObject.Find("Error Display").GetComponent<TextMesh>().text = "Error: ";
        GameObject.Find("Cannon").GetComponent<LineRenderer>().enabled = false;
        //when the angle has changed, remove all previously placed markers
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }


}
