/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    bool grounded = false;

    public string[] guns = {
        "pistol",
        "ak",
        "minigun"
    };
    
    public string selectedGun = "";
    public int gunNum = 0;

    // Use this for initialization
    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;		
	}
	
	// Update is called once per frame
	void Update () {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
/*
the rest of the code from here on is mine (nolan stone)
*/
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), 1.2f)) {
            grounded = true;
        } else {
            grounded = false;
        }

        if (Input.GetKeyDown("space") && grounded) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        } 


        if (Input.GetKeyDown("e")) {
            gunNum++;
        } else if (Input.GetKeyDown("q")) {
            gunNum--;
        }
        
        gunNum = Mathf.Clamp(gunNum, 0, 3);

        selectedGun = guns[gunNum];
    }
}