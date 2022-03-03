using System.Collections;
using System.Collections.Generic;
using TimeFunctions;
using UnityEngine;

[System.Serializable]
public struct Border
{
    public int Vertical;
    public int Horizontal;
}


public class Spawner : MonoBehaviour
{
    public Transform Player;
    public GameObject Prefab;
    [HideInInspector]
    public List<Vector2> GridForShow;

    public float PlayerRadius;

    [SerializeField]
    float _spawnTimer;
    [SerializeField]
    Border _camBorder;

    TimerFunctions _t1 = new TimerFunctions();

    void Start()
    {
        SetBorder();
        Player = FindObjectOfType<PlayerInput>().transform;
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            SpawnMeteor();
        }
    }

    //Spawn a meteor away from player but inside the view port 
    void SpawnMeteor()
    {
        List<Vector2> grid = CreateGrid();

        Vector2 randPos = GetRandomPoint(grid);
        Vector2 faceTowards = GetRandomAngle();

        GameObject meteor = Instantiate(Prefab, randPos, Quaternion.identity);
        meteor.transform.up = faceTowards;
    }

    List<Vector2> CreateGrid()
    {
        List<Vector2> grid = new List<Vector2>();
        Vector2 startingPoint;
        Vector2 endPoint;
        Vector2 newPoint;
        float distance;
        float x;
        float y;
        int length;

        // get starting position of the list
        x = transform.position.x - _camBorder.Horizontal;
        y = transform.position.y - _camBorder.Vertical;
        startingPoint = new Vector2(x, y);
        newPoint = startingPoint;

        // get end of the list
        x = transform.position.x + _camBorder.Horizontal;
        y = transform.position.y + _camBorder.Vertical;
        endPoint = new Vector2(x, y);

        length = ((_camBorder.Horizontal * 2)+1) * (1+(_camBorder.Vertical * 2));
        for (int i = 0; i < length; i++)
        {

            // move to the next height if all the x is covered
            if (newPoint.x >= endPoint.x)
            {
                newPoint.y = newPoint.y + 1;
                newPoint.x = startingPoint.x;
            }else
            {
                if (i != 0)
                    newPoint.x = newPoint.x + 1;
            }

            // Check if the point is in the players zone
            distance = (newPoint - (Vector2)Player.position).magnitude;
            if (distance >= PlayerRadius)
                grid.Add(newPoint);


        }
        GridForShow = grid;
        return grid;
    }

    Vector2 GetRandomPoint(List<Vector2> grid)
    {
        int ran = Random.Range(0, grid.Count - 1);
        print($"Range {ran}");
        return grid[ran];
    }

    Vector2 GetRandomAngle()
    {
        Vector2 angle = Vector2.zero;
        int randomAngle;
        float cos;
        float sin;

        //Randomize angle
        randomAngle = Random.Range(0, 360);

        // get the vector of the angle 
        cos = Mathf.Cos(randomAngle);
        sin = Mathf.Sin(randomAngle);

        angle = new Vector2(cos, sin);

        return angle;
    }

    // sets the size of the border
    void SetBorder()
    {
        _camBorder.Vertical = (int)Camera.main.orthographicSize;
        _camBorder.Horizontal = (int)Camera.main.aspect * _camBorder.Vertical;
    }

}
