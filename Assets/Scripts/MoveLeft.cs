using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float leftBound = -15f;

    private bool stopMoving = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        PlayerController.onPlayerDie += onPlayerDie;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDie -= onPlayerDie;
    }

    void onPlayerDie()
    {
        stopMoving = true;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.IsGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstracle"))
        {
            Destroy(gameObject);
        }
    }
}
