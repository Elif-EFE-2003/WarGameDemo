using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rb;
    public Animator anim;
    Vector3 moveDir;
    public float ileri,yan,moveSpeed,sensivity;
    public bool running,jumping;
    public int scaleType;
    public Transform mascot,mascotPos;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        //Player=GameObject.Find("Player");
        //anim=GameObject.Find("Character").GetComponent<Animator>();
        anim=transform.Find("Character").GetComponent<Animator>();
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
     
       movement();
       mascotPosition();
       
    }
    void mascotPosition(){
       mascot.transform.position=Vector3.Lerp(mascot.transform.position,mascotPos.position,moveSpeed*Time.deltaTime);
       mascot.transform.rotation=Quaternion.Lerp(mascot.transform.rotation,mascotPos.rotation,moveSpeed*Time.deltaTime);
    }
    void movement(){
        running=Input.GetKey(KeyCode.LeftShift);
        jumping=Input.GetKeyDown(KeyCode.Space);//1 kere işlem yapıcak
        ileri=Input.GetAxis("Vertical");
        yan=Input.GetAxis("Horizontal");
        moveDir=new Vector3(yan,0,ileri);
        if(jumping){
            rb.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
        transform.Translate(moveDir*moveSpeed*Time.deltaTime);
        transform.Rotate(0,Input.GetAxis("Mouse X")*sensivity*Time.deltaTime,0);
        anim.SetFloat("forward",ileri);
        anim.SetFloat("side",yan);
        anim.SetBool("run",running);
        anim.SetBool("jump",jumping);
    }
    private void OnTriggerStay(Collider other){
       if(other.gameObject.tag=="coin" && Input.GetKeyDown(KeyCode.Mouse0)){
        switch(scaleType){
            case 1:
            {
                other.gameObject.transform.localScale-=Vector3.one*.2f;
                break;
            }
            case 2:{
                other.gameObject.transform.localScale+=Vector3.one*.2f;
                break;
            }
            default:{
                print("scaleType doesn't matchs");
                break;
            }
        }
       }
    }
}
