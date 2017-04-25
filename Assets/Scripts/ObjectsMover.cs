using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMover : MonoBehaviour {

    public float speed = 1F;
    public int directionToMove = 0;
    public bool parentToObject = true;
    public bool hitThePlayer = false;
    public GameObject objectToMove;

    private Renderer rend;
    private bool isVisible = false;



	// Use this for initialization
	void Start ()
    {
        rend = objectToMove.GetComponent<Renderer>();

        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        IsVisiable();
        transform.Translate(speed * Time.deltaTime, 0, 0); //move the oblect
		
	}

    void IsVisiable()
    {
        if (rend.isVisible)
        {
            isVisible = true;
        }

        if (!rend.isVisible && isVisible)
        {
            Debug.Log("Remove it");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (parentToObject)
            {
                other.transform.parent = transform;
            }

            if (hitThePlayer)
            {
                other.GetComponent<PlayerController>().GotHit();
            }
            
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (parentToObject)
            {
                other.transform.parent = null;
            }
        }
    }
}
