using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    //public CharacterController mycharactercontroller;
    public float sideways;
    public float forward;
    public float xmouse;
    public float ymouse;
    //public Transform upperbody;
    public float rotationvalue;
    Animator myanimator;
    Rigidbody myrigidbody;
    public Joystick myjoystick;
    public float zvalue;
    public float xvalue;
    public GameObject directionpointer;
    bool isgrounded;
    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      

        sideways = myjoystick.Horizontal;
        //forward = Input.GetAxisRaw("Vertical");
        forward = myjoystick.Vertical;
        //Debug.DrawRay();
        //////////////////////////////////////////
        if (forward != 0)
        {
            
           
            if (forward > 0.9f || forward < -0.9f)
            {


                zvalue = 1f;
            }
            else
            {
                zvalue = forward;
            }
        }
        else
        if (forward == 0)
        {
            zvalue = 0f;
        }
        ////////////////////////////////////////////////


        if (sideways != 0)
        {
            xvalue = sideways;
        }
        else
        {
            xvalue = 0f;
        }
          
        myanimator.SetFloat("movez", zvalue);
        myanimator.SetFloat("movex", xvalue);
        if (sideways != 0 && forward != 0)
        {

            transform.forward = directionpointer.transform.forward;
           /* Vector3 forwardmovement = transform.forward;
            myrigidbody.velocity = new Vector3(sideways*2f, myrigidbody.velocity.y, forward* 2f);*/
           //we have to add here up 
            myrigidbody.velocity = (transform.forward * 2f* forward)+(transform.right * 2f * sideways);
        }
        else
        {
            myrigidbody.velocity = new Vector3(sideways, myrigidbody.velocity.y, forward);
        }

        ///////////////////////////////////////////////


        
    }
    public void playerjump()
    {
        if (isgrounded)
        {
            myrigidbody.velocity = new Vector3(myrigidbody.velocity.x, 4f, myrigidbody.velocity.z);


            myanimator.SetTrigger("jump");
        }
    }
    public void playershoots()
    {
        transform.forward = directionpointer.transform.forward;
        myanimator.SetTrigger("fire");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name== "ground")
        {
            isgrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == "ground")
        {
            isgrounded = false;
        }
    }
}
