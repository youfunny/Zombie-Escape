using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    PlayerControl player;
    [SerializeField]
    Vector3 offset;

    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        offset = transform.position - player.transform.position;

    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
