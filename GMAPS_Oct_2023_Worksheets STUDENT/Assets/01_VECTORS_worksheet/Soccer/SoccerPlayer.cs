using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t  => t != this).ToArray();
        if (IsCaptain)
        {
            ArrangePlayers();
            FindMinimum();
        }
    }

    void ArrangePlayers()
    {
        float radius = 10f;
        float angleStep = 360.0f / OtherPlayers.Length;
        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            Vector3 position = new Vector3(x, 0, z);
            position += transform.position;

            OtherPlayers[i].transform.position = position;
        }
    }
    
    void FindMinimum()
    {
        // Creating a list to store all the randomised heights
        List<float> heights = new List<float>();
        // For loop to generate all the heights
        for (int i = 0; i < 10; i++)
        {
            float height = Random.Range(5f, 20f);
            // Adding each height float into the list
            heights.Add(height);
            Debug.Log(height);
        }
        
        // Using the System.Linq OrderBy function to arrange the list in ascending order
        heights = heights.OrderBy(h => h).ToList();
        Debug.Log("Sorted in ascending order:");
        // Printing out the heights now in ascending order
        foreach (float height in heights)
        {
            Debug.Log(height);
        }
    }
    float Magnitude(Vector3 vector)
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

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            toPlayer = Normalise(toPlayer);

            float dot = Dot(transform.forward, toPlayer);
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.black);
            
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);
        if (IsCaptain)
        {
            angle += Input.GetAxisRaw("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


