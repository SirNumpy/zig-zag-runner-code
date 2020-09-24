using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public Transform raystart;
    private Animator animator;
    private Rigidbody rb;
    private bool movingRight=true;
    private GameManager gameManager;
    public GameObject crystalEffect;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("gameStarted");
        }
        RaycastHit hit;
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
        if (!Physics.Raycast(raystart.position, -Vector3.up,out hit, Mathf.Infinity))
        {
            animator.SetTrigger("isFalling");
        }
        else
        {
            animator.SetTrigger("notfalling");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
           
        }
        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }
    private void Switch()
    {
        movingRight = !movingRight;
        if (movingRight)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,- 45, 0));
        }
      
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "crystal")
        {
           
            GameObject g = Instantiate(crystalEffect, raystart.position, Quaternion.identity);
            Destroy(g, 2);
            gameManager.increaseScore();
            Destroy(other.gameObject);
        }
    }
}
   
   
