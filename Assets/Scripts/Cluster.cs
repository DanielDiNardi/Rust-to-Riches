using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    [SerializeField]
    string id;
    [SerializeField]
    HashSet<string> resourceIds = new HashSet<string>();

    public string GetId() { return id; }
    public HashSet<string> GetResourceIds() { return resourceIds; }

    public void SetId(string id) { this.id = id;}

    public void AddResource(string resourceId) { resourceIds.Add(resourceId); }

    public void PopulateClusterInfo()
    {
        string idString = "clu-" + IdManager.GetAndIncreaseClusterId();

        gameObject.GetComponent<Cluster>().SetId(idString);
    }
}
