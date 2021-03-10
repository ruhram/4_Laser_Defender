using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float Xmin;
    [SerializeField] float Xmax;
    [SerializeField] float Ymin;
    [SerializeField] float Ymax;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        setUpMoveBoundaries();
         
    }

    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        Xmin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        Xmax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        Ymin = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y;
        Ymax = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, Ymin, Ymax);

        transform.position = new Vector2(newXpos, newYpos);
    }
}
