using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    private float speedX = 480f;
    private float speedY = 450f;
    public float limitY = 60f;
    public float minDistance = 1.5f;
    public LayerMask obstacles;
    public LayerMask noPlayer;

    private float maxDistance;
    private Vector3 localPosition;
    private float currentYRot;
    private Vector3 p
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        localPosition = target.InverseTransformPoint(p);
        maxDistance = Vector3.Distance(p, target.position);
    }

    void LateUpdate()
    {
        p = target.TransformPoint(localPosition);
        CameraRotation();
        localPosition = target.InverseTransformPoint(p);
    }

    void CameraRotation()
    {
        var mx = Input.GetAxis("Mouse X");
        var my = -Input.GetAxis("Mouse Y");

        if (my != 0)
        {
            var tmp = Mathf.Clamp(currentYRot + my * speedY * Time.deltaTime, -limitY, limitY);
            if (tmp != currentYRot)
            {
                var rot = tmp - currentYRot;
                transform.RotateAround(target.position, transform.right, rot);
                currentYRot = tmp;
            }
        }

        if (mx != 0)
        {
            transform.RotateAround(target.position, Vector3.up, mx * speedX * Time.deltaTime);
        }

        transform.LookAt(target);
    }
}
