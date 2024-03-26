using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField]
    GroundGenerator groundGenerator;
    [SerializeField]
    ResourceGenerator resourceGenerator;

    // Start is called before the first frame update
    void Start()
    {
        groundGenerator.RunProceduralGeneration();
        resourceGenerator.RunProceduralGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
