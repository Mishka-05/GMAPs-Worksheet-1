using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    public float Magnitude(Vector3 vector)
    {
        return (float)Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        float magnitude = Magnitude(vector);
        vector.x /= magnitude;
        vector.y /= magnitude;
        vector.z /= magnitude;
        return vector;
    }

    public float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z);
    }

    float FindAngle(Vector3 vectorA, Vector3 vectorB)
    {
        return (float)Mathf.Acos(Dot(vectorA, vectorB) / (Magnitude(vectorA) * Magnitude(vectorB))) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (IsCaptain)
        {
            // Question 6b
            Vector3 directionVector = OtherPlayer.transform.position - transform.position;
            DebugExtension.DebugArrow(transform.position, directionVector, Color.black);

            // Question 6c
            Vector3 captForward = Normalise(transform.forward);
            DebugExtension.DebugArrow(transform.position, captForward, Color.blue);

            // Question 6d
            float captAngle = FindAngle(transform.forward, directionVector);
            float otherAngle = FindAngle(-directionVector, transform.forward);
            Debug.Log("Captain to Other player angle: " + captAngle);
            Debug.Log("Other player to captain angle: " + otherAngle);
            Debug.Log(captAngle + otherAngle);
        }
    }
}
