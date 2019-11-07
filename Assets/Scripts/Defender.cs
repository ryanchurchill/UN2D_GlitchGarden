using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] int laneNumber;

    public void AddStars(int numStars)
    {
        FindObjectOfType<StarDisplay>().AddStars(numStars);
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void SetLaneNumber(int _laneNumber)
    {
        laneNumber = _laneNumber;
    }

    public int GetLaneNumber()
    {
        return laneNumber;
    }
}
