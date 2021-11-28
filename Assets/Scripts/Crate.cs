using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] private float speed;

     bool rotate = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Pick(this.gameObject);
            transform.rotation = Quaternion.Euler(0,0,0);
            rotate = false;
            GetComponent<Crate>().enabled = false;
        }
    }
}
