using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2c, Q2d, Q2e;
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
        if (Q2c)
            Question2c(20);
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
        // Gets the height of the game by taking the camera.main.orthographic size
        // It is multiplied by 2 to get the full size of the game height.
        // If this is not done we cannot see the full height of the camera's view and only the height from the center
        GameHeight = Camera.main.orthographicSize * 2f;

        // Gets the width of the height by multipling the camera aspect ratio by the full size of the game height
        // The aspect ratio in this case is roughly 3:2, meaning 3 divided by 2 multiplied by GameHeight
        GameWidth = Camera.main.aspect * GameHeight;

        // Variables to store the GameWidth and GameHeight
        // GameWidth must be divided by 2 because to reset the maximum size back to only what the camera can see
        // If we do not divide the width and height by 2, we could end up with coordinates outside of what the camera can see.
        maxX = GameWidth / 2;
        minX = -maxX;
        maxY = GameHeight / 2;
        minY = -maxY;

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

            // EnableDrawing turned on to allow the lineFactory to draw the line on the scene
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2c(int n)
    {
        // Call the CalculateGameDimensions() function to get the minimum and maximum coordinates for X and Y
        CalculateGameDimensions();

        // For loop to iterate 20 times to draw 20 lines
        for (int i = 0; i < n; i++)
        {
            // Create a start point variable with randomised X and Y coordinates anywhere on the game screen
            startPt = new Vector2(Random.Range(minX, maxX),
                Random.Range(minY, maxY));
            // Create an end point variable with randomised X and Y coordinates anywhere on the game screen
            endPt = new Vector2(Random.Range(minX, maxX),
                Random.Range(minY, maxY));

            // Creates a new variable called drawnLine to call the lineFactory class
            // lineFactory creates a new black line from the randomisde start point and randomised end point with a width of 0.02
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            // EnableDrawing turned on to allow the lineFactory to draw the line on the scene
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
       // Create an arrow in 3D
        DebugExtension.DebugArrow(
            // Start point of the arrow with the (x, y, z) coordinates
            new Vector3(0, 0, 0),
            // End point of the arrow with the (x, y, z) coordinates
            new Vector3(-5, -5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        // Call the CalculateGameDimensions() function to get the minimum and maximum coordiantes for X and Y
        CalculateGameDimensions();
        // For loop to iterate 20 times to draw 20 arrows
        for (int i = 0; i < n; i++)
        {
            // Create an arrow in 3D
            DebugExtension.DebugArrow(
                // Set the start point of the arrow's (x, y, z) coordinates to the center)
                new Vector3(0, 0, 0),
                // Randomizes the end point of the arrow's (x, y, z) coordinates based on the size of the game screen.
                // z-coordinate has no maximum hence -minY and minY are used as specified by the worksheet :)
                new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(-minY, minY)),
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        // Creating new vectors a, b and c
        // Using HVector2D class constructor.
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;

        // Drwaing 3 arrows using the coordinates of a, b and c
        // Converting a, b and c to 3D vectors using the ToUnityVector3() function created in HVector2D.cs
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        // Drawing a 4th arrow with the starting coordinate from the head of the "a" arrow.
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        // Creating 3 vector 3 variables to get the magnitude of a, b and c
        float a_mag = a.Magnitude();
        float b_mag = b.Magnitude();
        float c_mag = c.Magnitude();

        // Printing the magnitude of arrows a, b and c in the console.
        // Printing the float to only 2 decimal places by using ToString("F2") which prints the first 2 decimal points.
        Debug.Log("Magnitude of a = " + a_mag.ToString("F2"));
        Debug.Log("Magnitude of b = " + b_mag.ToString("F2"));
        Debug.Log("Magnitude of b = " + c_mag.ToString("F2"));
    }

    public void Question3b()
    {
        // Creating new vector a
        HVector2D a = new HVector2D(3, 5);

        // Drawing arrow a
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Drawing arrow b that has half the scale of a
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), a.ToUnityVector3() / 2, Color.green, 60f);
    }

    public void Question3c()
    {
        // Creating new vector a
        HVector2D a = new HVector2D(3, 5);

        // Drawing arrow a
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        // Using normalize function to normalize the vector
        a.Normalize();
        // Drawing arrow a again after normalizing
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), a.ToUnityVector3(), Color.green, 60f);
        // Printing magnitude of vector a after normalizing
        Debug.Log(a.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        // Creating the 3 original vectors to be used
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        // Creating vector v1, with the coordinates (4, 0)
        HVector2D v1 = b - a;
        
        // Projecting the v2 vector 
        HVector2D proj = c.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
