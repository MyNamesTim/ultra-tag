using System.Collections;
using UnityEngine;

public class recoilScript : MonoBehaviour
{
    float recoilSpeed = 0.085f;
    float recoilFrame = 0;
    private float zPos = 0.8f;
    public Transform gunTransform;
    bool recoil = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (recoil)
        {
            float sinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 0.5f;
            float rotSinMod = Mathf.Sin(Mathf.PI * recoilFrame) * 10f;
            //change newPos coords to match the position of the gun position, zPos should match the zCoord
            Vector3 newPos = new Vector3(0.5f, -0.5f, zPos - sinMod);
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
                recoilSpeed = 0.085f;
                //change newPos coords to match the position of the gun position, zPos should match the zCoord
                gunTransform.localPosition = new Vector3(0.5f, -0.5f, 0.8f);
                gunTransform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !recoil)
        {
            Debug.Log("hi");
            recoil = true;
            recoilFrame = 0;
        }
    }
}
