using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolCue : MonoBehaviour
{
 	public LineFactory lineFactory;
 	public GameObject ballObject;

 	private Line drawnLine;
 	private Ball2D ball;

 	private void Start()
 	{
 		ball = ballObject.GetComponent<Ball2D>();
 	}

 	void Update()
 	{
 		if (Input.GetMouseButton(0))
 		{
 			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            Debug.Log($"startline: {startLinePos}");
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 2f, Color.black);
 				drawnLine.EnableDrawing(true);
 			}
 		}
 		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
 		{
 			drawnLine.EnableDrawing(false);

 			//update the velocity of the white ball.
 			HVector2D v = new HVector2D(ball.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
 			ball.Velocity = v;

 			drawnLine = null; // End line drawing            
 		}

 		if (drawnLine != null)
 		{
 			drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            // Update line end
 		}
 	}

 	/// <summary>
 	/// Get a list of active lines and deactivates them.
 	/// </summary>
 	public void Clear()
 	{
 		var activeLines = lineFactory.GetActive();

 		foreach (var line in activeLines)
 		{
 			line.gameObject.SetActive(false);
 		}
 	}
}
