using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
    [SerializeField] GameObject Heart;
    [SerializeField] Transform spawnLocation;

    bool hasgiven = false;

    public void Execute()
    {
        if (hasgiven == false)
        {
            Instantiate(Heart, spawnLocation);
            hasgiven = true;
        }
    }
}
