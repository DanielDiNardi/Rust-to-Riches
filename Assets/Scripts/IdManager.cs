using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IdManager
{
    [SerializeField]
    private static int resourceIdCount = 0;
    [SerializeField]
    private static int clusterIdCount = 0;
    [SerializeField]
    private static int improvementIdCount = 0;

    public static int GetAndIncreaseResourceId()
    {
        resourceIdCount++;
        return resourceIdCount;
    }

    public static int GetAndIncreaseClusterId()
    {
        clusterIdCount++;
        return clusterIdCount;
    }

    public static int GetAndIncreaseImprovementId()
    {
        improvementIdCount++;
        return improvementIdCount;
    }

    public static int GetClusterID()
    {
        return clusterIdCount;
    }
}
