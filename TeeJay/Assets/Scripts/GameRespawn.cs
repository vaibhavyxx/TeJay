using System.Collections.Generic;
using UnityEngine;

//Based on the video https://www.youtube.com/watch?v=Mic9ERhr0HA
public class GameRespawn : MonoBehaviour
{
    public Transform transformPoint;
    public float threshold;

    // Update is called once per frame
    void Update()
    {
        //If the player falls lower than the threshold, it will respawn at the coordinates listed below
        //in the code.
        if(this.transform.position.y < threshold)
        {
            Debug.Log("Player has fallen less then "+threshold);
            //transform.position = new Vector3(610.6f, -26.2f,-536.8f);
            Debug.Log("Respawn point: "+transformPoint.position.x + " "+ transformPoint.position.y+ " "+ transformPoint.position.z);
            this.transform.position = transformPoint.position;
        }
    }
}
