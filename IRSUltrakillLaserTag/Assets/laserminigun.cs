using UnityEngine;
using System.Collections;

public class laserminigun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RaycastHit hit;
    LineRenderer lr;
    public Material lasermaterial;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().selectedGun == "minigun") {
        GetComponent<Renderer>().enabled = true;

        lr.SetPosition(0, new Vector3(0, 0, 0));
        lr.SetPosition(1, new Vector3(0, 1, 0));
        if (Input.GetMouseButton(0) && Time.frameCount % 2 == 0) {
            StartCoroutine(shootLaserMinigun());
            //im so sorry
            Physics.Linecast(transform.TransformPoint(lr.GetPosition(0)), transform.TransformPoint(lr.GetPosition(1)), out hit);
        }

        if (hit.point != null && Input.GetMouseButton(0)) {
            StartCoroutine(drawDot());
        }
        } else {
            GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator shootLaserMinigun() {
        lr.enabled = true;
        yield return new WaitForSeconds(0.001f);
        lr.enabled = false;
    }

    IEnumerator drawDot() {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hit.point;
        sphere.GetComponent<Collider>().enabled = false;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        GameObject flash = new GameObject("flash");
        flash.transform.position = hit.point;
        Light lightComp = flash.AddComponent<Light>();
        lightComp.type = LightType.Point;
        lightComp.range = 2;
        lightComp.intensity = 5;
        lightComp.color = Color.green;
        sphere.GetComponent<Renderer>().material = lasermaterial;
        yield return new WaitForSeconds(0.5f);
        Destroy(sphere);
        Destroy(flash);
    }
}