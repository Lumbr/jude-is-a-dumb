using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody myRB;
    private Vector3 moveInput;
    public float speed;
    public GameObject playerModel;
    public Transform pivot;
    public float rotateSpeed;
    public float jumpForce;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRB.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionStay(Collider other)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        moveInput = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveInput = moveInput.normalized * speed;
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //moveSpeed = moveSpeed + momentumIncrease;
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0f, moveInput.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {

        myRB.AddForce(moveInput);
        
    }
}
