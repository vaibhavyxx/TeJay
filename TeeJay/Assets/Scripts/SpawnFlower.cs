//Spawns flower when the seed collides with the ground of the seed grounding
//Attach this code to the seed itself
//The seed will destroy itself after a few seconds probably 0.5 seconds
//Call Instantiate method grow the sunflower at that point
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    Transform flowerTransform;
    public string tagName;
    public GameObject seed;
    public GameObject flower;           //any flower ideally with animation on start turned on
    bool toSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            //Get the coordinates from the seed to grow the sunflower in those coordinates
            flowerTransform = seed.transform; 

            //Destroy(seed);             //destroys the seed itself
            //Destroy(seed);    //and its grab point
            toSpawn = true;
        }

        //Grows flower
        if(toSpawn)
        {
            Instantiate(flower, flowerTransform);
            toSpawn= false;
        }
    }
}
