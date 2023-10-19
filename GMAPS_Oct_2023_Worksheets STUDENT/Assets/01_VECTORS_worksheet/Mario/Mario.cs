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
        Debug.Log(gravityDir);

        /*moveDir = new Vector3(*//*change this*//*, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(*//*change this*//*);

        gravityNorm = *//*change this*//*;
        rb.*//*change this*//*(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(*//*change this*//*, *//*change this*//*, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(*//*change this*//*));

        DebugExtension.DebugArrow(*//*change this*//*, *//*change this*//*, Color.red);

        DebugExtension.DebugArrow(*//*change this*//*, *//*change this*//*, Color.blue);*/
    }
}


