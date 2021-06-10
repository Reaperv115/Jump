using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRope : MonoBehaviour
{
    protected int numOfJumps = 0;
    protected bool goUp, goDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getnumJumps()
    {
        return numOfJumps;
    }
}
