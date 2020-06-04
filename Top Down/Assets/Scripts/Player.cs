
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Material alive;
    public Material dead;
    public Renderer rend;
    public GameObject magicPref;
    public Transform firePoint;
    public float magicForce;
    public int speed;
    public int playerAttack;
    public float playerAttackCritChance;
    public int percentsToplayerAttackCritChance = 20;
    public int defend;
    public float maxPlayerHP=500;
    public float currentPlayerHP;

    Camera cam;
    public PlayerHealthBar playerHealthBar;

    private Rigidbody rb;
    private Vector3 movement;
    private float rayLength;
    public bool isDead;

    private void Awake()
    {
        BlackBoard.player = this;
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        isDead = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = alive;
        currentPlayerHP = maxPlayerHP;
        playerHealthBar.SetMaxHealth(maxPlayerHP);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHpFromPlayer(123);
            if (currentPlayerHP<=0)
            {
                currentPlayerHP = Mathf.Clamp(currentPlayerHP, 0, maxPlayerHP);
                isDead = true;
                rend = GetComponent<Renderer>();
                rend.enabled = true;
                rend.sharedMaterial = dead;
            }
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 poitTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(poitTolook.x,transform.position.y,poitTolook.z));
        }

        if (Input.GetMouseButtonUp(0) && !isDead)
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
        int critAttack = Random.Range(1, 101);
        if (critAttack >= percentsToplayerAttackCritChance)
        {
            float newAttack = playerAttack * playerAttackCritChance;
        }
        GameObject magic = Instantiate(magicPref, firePoint.position, firePoint.rotation);
        Rigidbody rbMagic = magic.GetComponent<Rigidbody>();
        rbMagic.AddForce(firePoint.forward * magicForce, ForceMode.Impulse);
        Destroy(magic,1f);
    }

    public void PlayerGetDamage(int damage)
    {
        currentPlayerHP = currentPlayerHP - (damage - defend);
    }


    void TakeHpFromPlayer(int damage)
    {
        currentPlayerHP -= damage;
        playerHealthBar.SetHealth(currentPlayerHP);
    }
}
