using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improvement : MonoBehaviour
{
    [SerializeField]
    string id;
    [SerializeField]
    string type;
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

    public void PopulateImprovementInfo(Vector3Int position)
    {
        string idString = "imp-" + type.ToLower() + "-" + IdManager.GetAndIncreaseImprovementId();

        gameObject.GetComponent<Resource>().SetId(idString);
        gameObject.GetComponent<Resource>().SetPosition(position);
        gameObject.GetComponent<Resource>().SetClusterId(clusterId);
        gameObject.name = id;
    }
}
