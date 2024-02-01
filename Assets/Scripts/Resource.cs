using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    string id;
    [SerializeField]
    string type;
    [SerializeField]
    float output = 2;
    [SerializeField]
    string clusterId;
    [SerializeField]
    Vector3Int position;

    public string GetId()
    {
        return id;
    }

    public string GetType()
    {
        return type;
    }

    public float GetOutput()
    {
        return output;
    }

    public string GetClusterId()
    {
        return clusterId;
    }

    public Vector3Int GetPosition()
    {
        return position;
    }

    public void SetId(string id)
    {
        this.id = id;
    }

    public void SetType(string type)
    {
        this.type = type;
    }
}
