using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {
    public GameObject BarrelTip;
    public GameObject ProjectileSpawn;

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
        SendMessageUpwards("CannonSelected");
    }

    /**
     * Sends given projectile firing out at given speed, returns the positions through which the projectile will fly
     * */
    public Vector3[] fireProjectile(GameObject projectile, float projectileSpeed, int frames)
    {
        //firing projectile
        GameObject theCannonball = Instantiate(projectile, BarrelTip.GetComponent<Transform>().position, Quaternion.identity);
        Rigidbody projectileRB = theCannonball.GetComponent<Rigidbody>();
        projectileRB.useGravity = false;
        Physics.IgnoreCollision(theCannonball.GetComponent<Collider>(), this.GetComponent<Collider>(), true);

        Vector3 initVelocity =
            (BarrelTip.GetComponent<Transform>().position - ProjectileSpawn.GetComponent<Transform>().position) * projectileSpeed;
        Vector3[] positions = generatePositions(projectileSpeed, frames);
        GetComponent<LineRenderer>().SetPositions(positions);
        GetComponent<LineRenderer>().enabled = true;

        //send the ball flying
        theCannonball.GetComponent<Rigidbody>().velocity = initVelocity;
        return positions;
    }

    public Vector3[] generatePositions(float projectileSpeed, int frames)
    {
        Vector3 initialVelocityVector =
    (BarrelTip.GetComponent<Transform>().position - ProjectileSpawn.GetComponent<Transform>().position) * projectileSpeed;
        Vector3[] positions = new Vector3[frames];
        Vector3 prevPos = BarrelTip.GetComponent<Transform>().position;
        Vector3 velocity = initialVelocityVector;
        for (int i = 0; i < frames; i++)
        {

            velocity += CustomGravity.globalGravity * Time.fixedDeltaTime * Vector3.up;
            positions[i] = prevPos + velocity * Time.fixedDeltaTime;
            prevPos = positions[i];
        }

        return positions;

    }


}
