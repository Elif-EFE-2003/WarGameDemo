using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rifle : MonoBehaviour
{
    public float time;
    public float timer;
    public GameObject projectile;
    public Transform bulletPos;
    public ParticleSystem barrelFx;
    AudioSource Audio;
    void Start()
    {
        Audio=GetComponent<AudioSource>();
        time=0;
    }

 
    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;

        if(Input.GetKey(KeyCode.Mouse0)&&(time<=0)){
           
           
           time=timer;
           Instantiate(projectile,bulletPos.position,bulletPos.rotation);
           Audio.Play();
          
            
        }
        
    }
}
