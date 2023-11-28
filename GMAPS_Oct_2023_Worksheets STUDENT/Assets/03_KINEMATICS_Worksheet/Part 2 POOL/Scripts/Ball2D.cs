using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    //[HideInInspector]
     float BallRadius;

     private void Start()
     {
         Position.x = transform.position.x;
         Position.y = transform.position.y;

         Sprite sprite = GetComponent<SpriteRenderer>().sprite;
         BallRadius = sprite.bounds.size.x / 2f;

        //HVector2D a = new HVector2D(0, 0);
        //HVector2D b = new HVector2D(5, 0);
        //float distance = Util.FindDistance(a, b);
     }

     public bool IsCollidingWith(float x, float y)
     {
         
         float distance = Util.FindDistance(Position, new HVector2D(x, y));
        print($"2 distance: {distance}, rad: {BallRadius}");
        return distance <= BallRadius;
     }

     public bool IsCollidingWith(Ball2D other)
     {
         float distance = Util.FindDistance(Position, other.Position);
         return distance <= BallRadius + other.BallRadius;
     }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x;
        float displacementY = Velocity.y;

        Position.x += displacementX * deltaTime;
        Position.y += displacementY * deltaTime;

        transform.position = new Vector2(Position.x, Position.y);
    }
}

