using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public bool isTerranin = false;
    //public int jumpCount = 2;  //а║га х╫╪Ж
    Rigidbody jumpRigidbody;
    Animator jumpAnimator;

    // Start is called before the first frame update
    void Start()
    {
        jumpRigidbody = GetComponent<Rigidbody>();
        jumpAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            isTerranin = true;
            //jumpCount = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (isTerranin)
        //{

           if (Input.GetKey(KeyCode.Space))
           {
               jumpRigidbody.MovePosition(jumpRigidbody.position+Vector3.up*jumpSpeed*Time.deltaTime);
                    //jumpCount--;
               jumpAnimator.SetTrigger("Jump");
           }
                
            
        //}
    }
}
