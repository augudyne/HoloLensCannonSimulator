using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {
    public GameObject Projectile;
    public GameObject ProjectileSpawn;
    public GameObject BarrelTip;
    public int TRAJECTORY_FRAMES;
    public float ProjectileSpeed;
    public float ShotInterval; //in seconds

    public void Start()
    {
        
        //get initial cannon rotation
        /*lastTime = Time.time;
        */
    }

    public void Update()
    {
        
        /*if (Time.time - lastTime > ShotInterval){//5 second interval
            lastTime = Time.time;
            OnSelect();
        }
        */
    }

    public void OnSelect()
    {
        Debug.Log("Inside OnSelect of CannonBehaviour");

        GameObject theCannonball = Instantiate(Projectile, ProjectileSpawn.GetComponent<Transform>().position, Quaternion.identity);
        Rigidbody projectileRB = theCannonball.GetComponent<Rigidbody>();
        projectileRB.useGravity = false;
        Physics.IgnoreCollision(theCannonball.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
     
        //Physics.IgnoreCollision(theCannonball.GetComponent<Collider>(), GetComponent<Collider>(), true);
        Vector3 initVelocity =
            (BarrelTip.GetComponent<Transform>().position - ProjectileSpawn.GetComponent<Transform>().position) * ProjectileSpeed;
        Vector3 velocity = new Vector3(initVelocity.x, initVelocity.y, initVelocity.z);
        Vector3[] positions = new Vector3[TRAJECTORY_FRAMES];
        Vector3 prevPos = ProjectileSpawn.GetComponent<Transform>().position;
        for (int i = 0; i < TRAJECTORY_FRAMES; i++)
        {

            velocity += CustomGravity.globalGravity * Time.fixedDeltaTime * Vector3.up;
            positions[i] = prevPos + velocity * Time.fixedDeltaTime;
            prevPos = positions[i];
        }

        GetComponent<LineRenderer>().SetPositions(positions);
        //send the ball flying
        theCannonball.GetComponent<Rigidbody>().velocity = initVelocity;
    }
}
