using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
//using UnityStandardAssets.CrossPlataformInput;

public class Movimiento : MonoBehaviour    
{
    public float speed;
    public VariableJoystick VariableJoystick;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * VariableJoystick.Vertical * speed;
        this.transform.position += Vector3.right * VariableJoystick.Horizontal * speed;

        if(VariableJoystick.Vertical + VariableJoystick.Horizontal ==0 && this.GetComponent<Animator>().GetBool("Caminar")){
            this.gameObject.GetComponent<Animator>().SetBool("Caminar",false);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        }else if(VariableJoystick.Vertical + VariableJoystick.Horizontal !=0){
            this.gameObject.GetComponent<Animator>().SetBool("Caminar",true);
            transform.eulerAngles = new Vector3(0,Mathf.Atan2(VariableJoystick.Horizontal,VariableJoystick.Vertical)*Mathf.Rad2Deg,0);
        }
    }
}