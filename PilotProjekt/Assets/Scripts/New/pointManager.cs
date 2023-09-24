using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{

    public int storedPoints = 0;
    public int safePoints = 0;


    public void add(int point = 1)
    {
        storedPoints += point;
    }

    public void savePoints()
    {
        safePoints += storedPoints;
    }
}

