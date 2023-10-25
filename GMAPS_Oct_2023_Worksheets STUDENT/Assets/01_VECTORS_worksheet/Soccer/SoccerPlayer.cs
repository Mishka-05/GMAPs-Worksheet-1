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

    //float Magnitude(Vector3 vector)
    //{
        
    //}

    //Vector3 Normalise(Vector3 vector)
    //{
        
    //}

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
        
    //}

    //SoccerPlayer FindClosestPlayerDot()
    //{
    //    SoccerPlayer closest = null;

    //    return closest;
    //}

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
        }
    }
}


