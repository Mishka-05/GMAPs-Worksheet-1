using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {

    }

    void Question2a()
    {
        // Creates a starting point for the line to be drawn at vector 0, 0
        startPt = new Vector2(0, 0);
        // Creates an end point for the line to be drawn at vector 2, 3
        endPt = new Vector2(2, 3);

        // Creates a new variable called drawnLine to call the lineFactory class
        // lineFactory creates a black line from the start point (0,0) and the end point (2,3) with a width of 0.02
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        // EnableDrawing turned on to allow the lineFactory to draw the line on the scene
        drawnLine.EnableDrawing(true);

        // Gets the distance between the end point and the start point
        Vector2 vec2 = endPt - startPt;

        // Prints the magnitude (length) of the line drawn in the console.
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        // For loop to iterate 20 times to draw 20 lines
        for (int i = 0; i < n; i++)
        {
            // Create a start point variable with randomised X and Y coordinates between 5 and -5
            startPt = new Vector2(Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            // Create an end point variable with randomised X and Y coordinates between 5 and -5
            endPt = new Vector2(Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            // Declare values for maxX and maxY coordiantes
            // This will allow the start points to be between -5 and 5
            maxX = 5;
            maxY = 5;

            // Creates a new variable called drawnLine to call the lineFactory class
            // lineFactory creates a new black line from the randomised start point and randomised end point with a width of 0.02
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            // Enable Drawing turned on to allow the lineFactory to draw the line on the scene
            drawnLine.EnableDrawing(true);
        }
    }


    void Question2d()
    {

    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            // Your code here
            // ...

            //DebugExtension.DebugArrow(
            //    new Vector3(0, 0, 0),
            //    // Your code here,
            //    Color.white,
            //    60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        //HVector2D b = // Your code here;
        //HVector2D c = // Your code here;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        // ...

        // Your code here

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
