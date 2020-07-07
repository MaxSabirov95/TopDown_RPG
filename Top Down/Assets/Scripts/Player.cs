
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Material alive;
    public Material dead;
    //public Renderer rend;
    public GameObject magicPref;
    public Transform firePoint;
    public float magicForce;
    public int speed;
    public int playerAttack;
    public float critChancePercentFormAttack;
    public int percentsToplayerAttackCritChance = 20;
    public int defend;
    public float maxPlayerHP=500;
    public float currentPlayerHP;
    float horizontalMove;
    float verticalMove;

    Camera cam;
    public PlayerHealthBar playerHealthBar;

    private Rigidbody rb;
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
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = alive;
        currentPlayerHP = maxPlayerHP;
        //playerHealthBar.SetMaxHealth(maxPlayerHP);
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
                //rend = GetComponent<Renderer>();
                //rend.enabled = true;
                //rend.sharedMaterial = dead;
            }
        }

        //movement.x = Input.GetAxis("Horizontal");
        //movement.z = Input.GetAxis("Vertical");

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 poitTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(poitTolook.x,transform.position.y,poitTolook.z));
        }

        if (Input.GetMouseButtonUp(0) && !isDead)
        {
            Attack();
        } 
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        rb.velocity=new Vector3(horizontalMove , 0 , verticalMove) * speed;
        if(horizontalMove!=0 || verticalMove != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    void Attack()
    {
        int critAttack = Random.Range(1, 101);
        if (critAttack <= percentsToplayerAttackCritChance)
        {
            float newAttack = playerAttack / critChancePercentFormAttack;
            newAttack += playerAttack;
        }
        //GameObject magic = Instantiate(magicPref, firePoint.position, firePoint.rotation);
        //Rigidbody rbMagic = magic.GetComponent<Rigidbody>();
        //rbMagic.AddForce(firePoint.forward * magicForce, ForceMode.Impulse);
        //Destroy(magic,1f);
        if((verticalMove == 0) && (horizontalMove  == 0))
        {
            StartCoroutine(NormalAttack());
            
            
        }
        else
        {
            StartCoroutine(RunAttack());
        }
    }

    public void PlayerGetDamage(int damage)
    {
        currentPlayerHP = currentPlayerHP - (damage - defend);
    }

    public void TakeHpFromPlayer(int damage)
    {
        currentPlayerHP -= damage;
        //playerHealthBar.SetHealth(currentPlayerHP);
    }

    IEnumerator RunAttack()
    {
        anim.SetTrigger("RunAttack");
        yield return new WaitForSeconds(0.5f);
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = 10;
    }
    IEnumerator NormalAttack()
    {
        speed = 0;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        speed = 10;
    }
}
