using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForse = 10f;
    [SerializeField]
    private float gravityMultiplier = 1;

    private Animator playerAnim;
    private static bool isGameOver = false;
    private Rigidbody playerRB;
    private bool isOnGround = true;
    // Start is called before the first frame update

    public delegate void OnPlayerDie();
    public static event OnPlayerDie onPlayerDie;

    public static bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
    }

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !IsGameOver)
        {
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerRB.AddForce(Vector3.up * jumpForse, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        else if(collision.gameObject.tag == "Obstracle")
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            isGameOver = true;
            onPlayerDie();
        }
    }

}
