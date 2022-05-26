using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTank;
    public Vector3 offset;
    public new Camera camera;
    private float CameraZoomOutSpeed = 0.0001f;



    private void Start()
    {
        playerTank = FindObjectOfType<CameraController>().transform;
        GameObject cam = GameObject.Find("MainCam");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }

    void Update()
    {
        CheckPlayer();
        transform.position = playerTank.transform.position + offset;
    }

    private void CheckPlayer()
    {
        if (playerTank == null)
        {
            playerTank = transform;
            return;
        }
    }


    private void LateUpdate()
    {

        offset = transform.position - playerTank.transform.position;

    }

    public IEnumerator ZoomOutCamera()

    {

        float lerp = 0.01f;

        while (camera.orthographicSize < 60)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 60, lerp);
            lerp = lerp + CameraZoomOutSpeed;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator destroyEverything()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject.Destroy(objects[i]);
            yield return new WaitForSeconds(0.1f);
        }



    }

}