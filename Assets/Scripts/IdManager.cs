using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IdManager
{
    [SerializeField]
    private static int resourceIdCount = 0;

    public static int GetAndIncreaseResourceId()
    {
        resourceIdCount++;
        return resourceIdCount;
    }
}
