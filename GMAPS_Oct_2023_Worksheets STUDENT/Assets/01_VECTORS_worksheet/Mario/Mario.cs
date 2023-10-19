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
        // gravity must act on the player
        // so the 2 points must be the player and the planet
        gravityDir = planet.position - transform.position;
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;
        Debug.Log(moveDir);
        
        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        /*float angle = Vector3.SignedAngle(Vector3.up, gravityDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));*/

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);

        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


