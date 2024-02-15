using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    string id;
    [SerializeField]
    string clusterId;
    [SerializeField]
    HashSet<string> truckIds = new HashSet<string>();
    [SerializeField]
    float inventory = 0;
    [SerializeField]
    float output = 0;
    [SerializeField]
    Vector3Int position;
    [SerializeField]
    string type;

    public string GetId()
    {
        return id;
    }

    public string GetClusterId()
    {
        return clusterId;
    }

    public HashSet<string> GetTruckIds()
    {
        return truckIds;
    }

    public float GetInventory()
    {
        return inventory;
    }

    public float GetOutput()
    {
        return output;
    }

    public Vector3Int GetPosition()
    {
        return position;
    }

    public string GetType()
    {
        return type;
    }

    public void SetId(string id)
    {
        this.id = id;
    }

    public void SetClusterId(string clusterId)
    {
        this.clusterId = clusterId;
    }

    public void AddTruckId()
    {
        truckIds.Add(id);
    }

    public void IncreaseInventory(float input)
    {
        this.inventory += input;
    }

    public void DecreaseInventory()
    {
        if (inventory - output > 0) 
        { 
            inventory -= output;
        }
    }

    public void SetOutput(float newOutput)
    {
        this.output = newOutput;
    }

    public void SetPosition(Vector3Int position)
    {
        this.position = position;
    }

    public void SetType(string type)
    {
        this.type = type;
    }

    public void PopulateCollectorInfo(string type, Vector3Int position, string clusterId)
    {
        string idString = "res-" + type.ToLower() + "-" + IdManager.GetAndIncreaseResourceId();

        gameObject.GetComponent<Collector>().SetId(idString);
        gameObject.GetComponent<Collector>().SetType(type);
        gameObject.GetComponent<Collector>().SetPosition(position);
        gameObject.GetComponent<Collector>().SetClusterId(clusterId);
        gameObject.name = id;
    }
}
