using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public float speed = 0.25F;
    public bool toMove = true;
    public GameObject player;
    public Vector3 offset = new Vector3(3, 6, -3);
    Vector3 depth;
    Vector3 pos;   

    void Update()
    {
        if (!Manager.instance.CanPlay()) return; //камера начнет двигаться только, когда игрок нажмет вперед
        
        if (toMove)
        {
            depth = gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        }
        else
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        }
    }

    
}
