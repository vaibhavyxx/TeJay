
using Unity.VisualScripting;
using UnityEngine;

public class SpawnLeaves : MonoBehaviour
{
    public GameObject meshObject;
    //calculate array of points in virtual space
    Vector3[] coordinates;   //saves x and y coordinates 

    //to calculate the radius of the dome
    float radius = 5.0f;
    int totalMeshes = 0;
    float deltaAngle = 0.0f;
    float meshWidth = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        meshWidth = meshObject.GetComponent<MeshRenderer>().bounds.size.x;
        totalMeshes = Mathf.RoundToInt(2* Mathf.PI * radius / meshWidth);
        deltaAngle = 2* Mathf.PI/ totalMeshes;
        coordinates = new Vector3[totalMeshes];
        //totalMeshes = int.Parse 2 * Mathf.PI * radius;
        
        //finds the coordinates to make a circle
        for(int i = 0; i < totalMeshes; i++)
        {
            float angle = i * deltaAngle;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);
            //Debug.Log("angle "+ angle+" "+ x+ ", "+y);
            coordinates[i] = new Vector3(x, 0, z);
            Instantiate(meshObject, coordinates[i], Quaternion.identity);

        }
        Debug.Log("total meshes: " + totalMeshes);
    }
     

    // Update is called once per frame
    void Update()
    {
        
    }
}
