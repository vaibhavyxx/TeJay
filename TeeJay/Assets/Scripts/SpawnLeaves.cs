
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
    int counter = 0;

    //time
    float time = 0.0f;
    const float deltaTime = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        meshWidth = meshObject.GetComponent<MeshRenderer>().bounds.size.x;
        totalMeshes = Mathf.RoundToInt(2* Mathf.PI * radius / meshWidth);
        deltaAngle = 2* Mathf.PI/ 6;
        coordinates = new Vector3[totalMeshes];

        //totalMeshes = int.Parse 2 * Mathf.PI * radius;
        //finds the coordinates to make a circle
        /*for(int i = 0; i < totalMeshes; i++)
        {
            float angle = i * deltaAngle;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);
            //Debug.Log("angle "+ angle+" "+ x+ ", "+y);
            coordinates[i] = new Vector3(x, 0, z);
            Instantiate(meshObject, coordinates[i], Quaternion.identity);
            //time = Time.time;
            //Debug.Log(time);
        }*/
        //Debug.Log("total meshes: " + totalMeshes);
    }
     

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        //Debug.Log("Time: "+ time);
        if(time > deltaTime && counter < totalMeshes)
        {
            time = 0.0f;                                //resets time
            float angle = counter * deltaAngle;
            Vector3 coordinate = new Vector3(radius * Mathf.Cos(angle),
                0, radius * Mathf.Sin(angle));
            makeObject(coordinate, Quaternion.Euler(angle * counter, angle * counter, angle * counter));
            counter++;
        }
        
    }

    void makeObject(Vector3 coordinates, Quaternion rotation)
    {
        Instantiate(meshObject, coordinates, rotation);
    }
}
