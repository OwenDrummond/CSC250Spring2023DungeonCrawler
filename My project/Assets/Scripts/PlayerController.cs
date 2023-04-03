using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public float movementSpeed = 40.0f;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterData.count);
    }

    // Update is called once per frame
    void Update()
    { 
       if(canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                canMove = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                canMove = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                canMove = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                canMove = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("SampleScene");
            MasterData.count++;
            canMove = true;
        }
    }
}
