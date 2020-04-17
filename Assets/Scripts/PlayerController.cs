using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForse = 10f;
    public float gravityMultiplier = 1;

    private Rigidbody playerRB;
    private bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector3.up * jumpForse, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}
