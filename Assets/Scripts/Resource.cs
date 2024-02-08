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
    Vector3Int position;
    [SerializeField]
    string clusterId;

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

    public Vector3Int GetPosition()
    {
        return position;
    }

    public string GetClusterId()
    {
        return clusterId;
    }

    public void SetId(string id)
    {
        this.id = id;
    }

    public void SetType(string type)
    {
        this.type = type;
    }

    public void SetPosition(Vector3Int position)
    {
        this.position = position;
    }

    public void SetClusterId(string clusterId)
    {
        this.clusterId = clusterId;
    }

    public void PopulateResourceInfo(string type, Vector3Int position, string clusterId)
    {
        string idString = "res-" + type.ToLower() + "-" + IdManager.GetAndIncreaseResourceId();

        gameObject.GetComponent<Resource>().SetId(idString);
        gameObject.GetComponent<Resource>().SetType(type);
        gameObject.GetComponent<Resource>().SetPosition(position);
        gameObject.GetComponent<Resource>().SetClusterId(clusterId);

    }
}
