using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    [SerializeField]
    private float mineDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit , mineDistance))
        {
            if (Input.GetKey(KeyCode.E))
            {
                MineAsteroid(hit);
            } 
        }
    }
    
    private void MineAsteroid(RaycastHit hit)
    {
       
    }
}
