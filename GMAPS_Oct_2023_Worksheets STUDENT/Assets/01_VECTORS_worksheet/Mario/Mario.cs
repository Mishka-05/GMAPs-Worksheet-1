using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    public Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Gravity must act on the player
        // So the 2 points must be the player and the planet
        gravityDir = planet.position - transform.position;
        
        // Set the move direction of the astronaut to rotate around the center of the planet
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;
        // Adds the movement force to the player
        rb.AddForce(moveDir * force);

        // Normalizing the gravity vector to be able to apply the strength
        gravityNorm = gravityDir.normalized;
        // Applying gravity force on the player by multiplying the magnitude by the gravityStrength (1 * 5)
        rb.AddForce(gravityNorm * gravityStrength);

        // Calculates the angle that the astronaut must turn
        float angle = Vector3.SignedAngle(Vector3.right, moveDir, Vector3.forward);
        // Applies the angle to the astronaut Rigidbody2D
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


