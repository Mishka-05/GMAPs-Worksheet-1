using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);

        // Normalizing the HVector2D of moveDir
        moveDir.Normalize();
        moveDir *= -1f;

        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);

        // Converting the moveDir from HVector2D to Vector2 to scale it by the movement force
        rb.AddForce(moveDir.ToUnityVector2() * force);

        // Normalizing the HVector2D of gravityDir
        gravityDir.Normalize();
        gravityNorm = gravityDir;

        // Converting the normalized gravity to Vector2 to scale it by the gravity strength
        rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength);

        // Applying the rotation of the character sprite
        HVector2D right = new HVector2D(Vector3.right);
        float angle = moveDir.FindAngle(right);
        Debug.Log(angle);
        // float angle = Vector3.SignedAngle(Vector3.right, moveDir.ToUnityVector3(), Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));
    }
}
