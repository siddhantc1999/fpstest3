using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameramovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    public Vector3 offset;
    public Vector3 previousposition;
    public Vector3 threshold;
    public float thresholdy;
    public float yrotationvalue;
    public float xrotationvalue;
    public Joystick myjoystick;
    public float mouseymin;
    public float mouseymax;
    public float clampedxangle;
    public float xrotate;
    public float yrotate;
    [SerializeField] GameObject direction;
    [SerializeField] GameObject upperbody;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("the angles " + Quaternion.Euler(new Vector3(0f,30f,0f)));
       
    }

    // Update is called once per frame
    void Update()
    {
    /*    Debug.DrawRay(transform.position, Vector3.forward * 100f, Color.red);*/

        if (!EventSystem.current.IsPointerOverGameObject())
        {
           
            if (Input.GetMouseButtonDown(1))
            {

                previousposition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                threshold = previousposition - Camera.main.ScreenToViewportPoint(Input.mousePosition);


            }
            else
            {
                previousposition = Vector3.zero;
                threshold = Vector3.zero;
            }
            //float xrot = threshold.y * 2f;
            //float yrot = threshold.x * 2f;
            //clampedxangle = Mathf.Clamp(xrot,-20f , 25f);

            //x me y aur y me x
            xrotate = threshold.y * 2f;
            yrotate = threshold.x * 2f;
            transform.Rotate(xrotate, yrotate, 0f);
            direction.transform.Rotate(0f, yrotate, 0f);

            //clampedxangle = Mathf.Clamp(transform.eulerAngles.x, 335f, 30f);

            //transform.rotation = Quaternion.Euler(clampedxangle, transform.eulerAngles.y, 0f); //new Vector3(clampedxangle, transform.eulerAngles.y, 0f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
            //upperbody.transform.eulerAngles = new Vector3(xrotate, yrotate, upperbody.transform.eulerAngles.z);
            Debug.Log(upperbody.transform.eulerAngles);

        }

    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }
   
}
