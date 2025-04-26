using System.Collections;
using UnityEngine;

public class recoilScript : MonoBehaviour
{
    float recoilSpeed = 0.085f;
    float recoilFrame = 0;
    private float zPos = 0;
    public Transform gunTransform;
    bool recoil = false;
    string gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        gun = GameObject.Find("Player").GetComponent<PlayerController>().selectedGun;
        if (recoil && gun == "pistol")
        {
            float sinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 0.5f;
            float rotSinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 10f;
            //change newPos coords to match the position of the gun position, zPos should match the zCoord
            Vector3 newPos = new Vector3(0, 0, zPos - sinMod);
            Vector3 newRot = new Vector3(-rotSinMod, 0, 0);
            recoilFrame += recoilSpeed;
            recoilSpeed *= 0.98f;
            Debug.Log(newPos);
            gunTransform.localPosition = newPos;
            gunTransform.localEulerAngles = newRot;
            if (recoilFrame > 1)
            {
                recoil = false;
                recoilFrame = 0;
                recoilSpeed = 0.12f;
                //change newPos coords to match the position of the gun position, zPos should match the zCoord
                gunTransform.localPosition = new Vector3(0, 0, 0);
                gunTransform.localEulerAngles = new Vector3(0, 0, 0);
            }
        } else if (recoil && gun == "ak") {
            float sinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 0.5f;
            float rotSinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 5f;
            //change newPos coords to match the position of the gun position, zPos should match the zCoord
            Vector3 newPos = new Vector3(0, 0, zPos - sinMod);
            Vector3 newRot = new Vector3(-rotSinMod, 0, 0);
            recoilFrame += recoilSpeed;
            //recoilSpeed *= 0.98f;
            Debug.Log(newPos);
            gunTransform.localPosition = newPos;
            gunTransform.localEulerAngles = newRot;
            if (recoilFrame > 1)
            {
                recoilFrame = 0;
                recoilSpeed = 0.2f;
                //change newPos coords to match the position of the gun position, zPos should match the zCoord
                gunTransform.localPosition = new Vector3(0, 0, 0);
                gunTransform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            recoil = true;
            recoilFrame = 0;
        }
        if (Input.GetMouseButton(0) && !recoil && gun != "pistol")
        {
            recoil = true;
            recoilFrame = 0;
        }

        if (Input.GetMouseButtonUp(0) && recoil) {
            recoil = false;
            gunTransform.localPosition = new Vector3(0, 0, 0);
            gunTransform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
