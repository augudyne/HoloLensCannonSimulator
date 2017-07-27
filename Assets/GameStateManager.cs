using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    public GameObject Projectile;
    public int TRAJECTORY_FRAMES;
    public float ProjectileSpeed;
    public GameObject Cannon;

    public static Vector3[] lastGeneratedPositions;

    private Vector3[] lastFiredPositions;
    private static string TAG = "[GameStateManager]: ";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CannonSelected()
    {
        Debug.Log(TAG+ "Cannon Selected");
        //FireCannon
        Vector3[] positions = Cannon.GetComponent<CannonBehaviour>().fireProjectile(Projectile, ProjectileSpeed, TRAJECTORY_FRAMES);
    }

    void AngleChanged(int newAngle)
    {
        Debug.Log(TAG + "Cannon angle changed to: " + newAngle);
    }

    void GravityChanged(float gravityValue)
    {
        Debug.Log(TAG + "Gravity changed to: " + gravityValue);
    }
    
}
