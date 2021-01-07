using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;
    [SerializeField]
    private Game game;
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * 10f, playerBody.velocity.y, Input.GetAxis("Vertical") * 10f);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    }

    private void FixedUpdate()
    {
        playerBody.velocity = inputVector;
    }

    //bool isGrounded()
    //{
    //    float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
    //    Ray ray = new Ray(transform.position, Vector3.down);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            game.ReloadCurrentLevel();
        }
    }
}
