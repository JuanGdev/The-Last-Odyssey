using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private bool isInsideCollider = false;
    void Start()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        GetComponent<Rigidbody>().isKinematic = true;
        
        
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * (speed * Time.deltaTime), Space.World);

        if (isInsideCollider && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            GameManager.instance.LoadGame(SceneIndexes.LEVEL_3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collider with: " + other.gameObject.name);
        isInsideCollider = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited collider with: " + other.gameObject.name);
        isInsideCollider = false;
    }


}
