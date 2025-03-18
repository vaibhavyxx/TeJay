using System.Collections.Generic;
using UnityEngine;

//Based on the video https://www.youtube.com/watch?v=Mic9ERhr0HA
public class GameRespawn : MonoBehaviour
{
    //We set out threshold based on y-axis = -60
    public float threshold;

    // Update is called once per frame
    void Update()
    {
        //If the player falls lower than the threshold, it will respawn at the coordinates listed below
        //in the code.
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(-323f, -46.55552f,-167.9565f);
        }
    }
}
