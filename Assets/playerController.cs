using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    CharacterController cc;
    public float moveSpeed = 4f;

    public float gravity = 0f;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0, z).normalized;

        //Velocity = direction * how far * per second
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;

        //Gravity 
        if (cc.isGrounded) //If player is on a platform
        {
            gravity = 0;
        }
        else
        {
            gravity += 0.25f;
            //Makes sure player never falls too fast
            gravity = Mathf.Clamp(gravity, 1f, 20f);
        }
        //gravityVector = downward vector * length is "gravity" * in units per second
        Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;

        //has collision detection, can handle slopes and stairs
        cc.Move(velocity + gravityVector);

        if (velocity.magnitude > 0) //only change direction of the player if the player is moving
        {
            //Tangent(Theta) = slope --> ArcTangent(slope) = theta
            //yAngle is your Theta                        Mathf.Rad2Deg = convert to degrees
            float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            //set to local y-rotation to yAngle
            transform.localEulerAngles = new Vector3(0, yAngle, 0);
        }
    }
}
