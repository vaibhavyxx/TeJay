using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based on the video https://www.youtube.com/watch?v=Mic9ERhr0HA
public class GameRespawn : MonoBehaviour
{
   
    public float threshold;
    [SerializeField] private Vector3 startingposition;
    // Update is called once per frame
    void Start()
    {
        startingposition = this.transform.localPosition;
        
    }
    void Update()
    {
        //If the player falls lower than the threshold, it will respawn at the coordinates listed below
        //in the code.
        
        if(this.transform.localPosition.y < threshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Debug.Log("Player has fallen less then "+threshold);/
            this.transform.localPosition = startingposition;
            Debug.Log(gameObject.name + " Respawn point: "+transform.localPosition.x + " "+ transform.localPosition.y+ " "+ transform.localPosition.z);
        }
    }
}
