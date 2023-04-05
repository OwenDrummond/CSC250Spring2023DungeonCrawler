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
    private bool exitOn = true;
    private bool centerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterData.count);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Exit")
        {
            if (other.gameObject == this.northExit && exitOn == true)
            {
                MasterData.whereDidIComeFrom = "north";
                exitOn = false;
                centerOn = true;
                this.rb.transform.position = this.southExit.transform.position;
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            }
            if (other.gameObject == this.southExit && exitOn == true)
            {
                MasterData.whereDidIComeFrom = "south";
                exitOn = false;
                centerOn = true;
                this.rb.transform.position = this.northExit.transform.position;
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            }
            if (other.gameObject == this.eastExit && exitOn == true)
            {
                MasterData.whereDidIComeFrom = "east";
                exitOn = false;
                centerOn = true;
                this.rb.transform.position = this.westExit.transform.position;
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            }
            if (other.gameObject == this.westExit && exitOn == true)
            {
                MasterData.whereDidIComeFrom = "west";
                exitOn = false;
                centerOn = true;
                this.rb.transform.position = this.eastExit.transform.position;
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            }
            MasterData.count++;
            canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Center" && centerOn == true)
        {
            SceneManager.LoadScene("SampleScene");
            exitOn = true;
            centerOn = false;
        }
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
}
