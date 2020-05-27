
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject magicPref;
    public Transform firePoint;
    public float magicForce;
    Camera cam;
    public int speed;

    private Rigidbody rb;
    private Vector3 movement;
    private float rayLength;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 poitTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(poitTolook.x,transform.position.y,poitTolook.z));
        }

        if (Input.GetMouseButtonUp(0))
        {
            ShootMagic();
        } 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void ShootMagic()
    {
        GameObject magic = Instantiate(magicPref, firePoint.position, firePoint.rotation);
        Rigidbody rbMagic = magic.GetComponent<Rigidbody>();
        rbMagic.AddForce(firePoint.forward * magicForce, ForceMode.Impulse);
        Destroy(magic,1f);
    }
}
