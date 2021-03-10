using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject laser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectilePeriod = .2f;

    [SerializeField] float Xmin;
    [SerializeField] float Xmax;
    [SerializeField] float Ymin;
    [SerializeField] float Ymax;

    Coroutine firingCouroutine;
    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBoundaries();
         
    }

    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        Xmin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        Xmax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
        Ymin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        Ymax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCouroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCouroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true) {
            GameObject PlayerLaser = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            PlayerLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            Destroy(PlayerLaser, 2f);
            yield return new WaitForSeconds(projectilePeriod);
        }
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
