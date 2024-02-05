using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{

    public Transform player;
    public float smoothing = 3f;
    private Vector3 offset;

    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move camera
        if (player != null)
            newPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.fixedDeltaTime);
    }
}
