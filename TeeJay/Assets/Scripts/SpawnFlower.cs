//Spawns flower when the seed collides with the ground of the seed grounding
//Attach this code to the seed itself
//The seed will destroy itself after a few seconds probably 0.5 seconds
//Call Instantiate method grow the sunflower at that point
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    Transform flowerTransform;
    public string tagName;
    GameObject seed;
    public GameObject flower;           //any flower ideally with animation on start turned on
    bool toSpawn = false;
    float randomScale = 0.0f;
    public float ySpawnCoordinate = 76.5f;      //where flower should be spawned
    private void Start()
    {
        randomScale = Random.Range(0.0f, 0.5f);
        flowerTransform.transform.localScale = new Vector3 (randomScale, randomScale, randomScale);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            seed = other.gameObject;
            //Get the coordinates from the seed to grow the sunflower in those coordinates
            flowerTransform = seed.transform; 

            Destroy(seed);             //destroys the seed itself
            toSpawn = true;
        }

        //Grows flower
        if(toSpawn)
        {
            Vector3 vec3 = new Vector3(flowerTransform.position.x, ySpawnCoordinate, flowerTransform.position.z);
            Instantiate(flower, vec3, Quaternion.identity);
            toSpawn= false;
            Debug.Log("should spawn flower");
        }
    }
}
