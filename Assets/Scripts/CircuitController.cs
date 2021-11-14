using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitController : MonoBehaviour
{
    private int gridSize = 3;

    [SerializeField]
    private Circuit powerSource;

    [SerializeField]
    private Circuit[,] circuits;

    // Start is called before the first frame update
    void Awake()
    {
        circuits = new Circuit[gridSize, gridSize];
        int index = 0;
        foreach(Circuit c in GetComponentsInChildren<Circuit>())
        {
            circuits[index % gridSize, index / gridSize] = c;
            index++;
        }

        UpdatePower();
    }

    public void UpdatePower()
    {
        foreach(Circuit c in GetComponentsInChildren<Circuit>())
        {
            c.SetPower(false);
        }

        RecursivePowerCheck(0,0,"");
    }

    void RecursivePowerCheck(int y, int x, string direction)
    {
        if(y < 0 || y >= gridSize || x < 0 || x >= gridSize || circuits[y,x].HasPower()) return;
        var directions = circuits[y,x].GetDirections();
        bool left = directions.Item1;
        bool top = directions.Item2;
        bool right = directions.Item3;
        bool bottom = directions.Item4;

        if(!ValidDirection(left, top, right, bottom, direction)) return;

        circuits[y,x].SetPower(true);

        if(left) RecursivePowerCheck(y-1,x, "left");
        if(right) RecursivePowerCheck(y+1,x, "right");
        if(top) RecursivePowerCheck(y,x-1, "top");
        if(bottom) RecursivePowerCheck(y,x+1, "bottom");

    }

    bool ValidDirection(bool left, bool top, bool right, bool bottom, string direction)
    {
        if(direction == "right" && !left) return false;
        if(direction == "left" && !right) return false;
        if(direction == "top" && !bottom) return false;
        if(direction == "bottom" && !top) return false;

        return true;
    }
}
