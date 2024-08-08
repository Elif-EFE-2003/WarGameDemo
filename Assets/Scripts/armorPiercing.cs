using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class armorPiercing : MonoBehaviour
{ 
    Rigidbody rb;
    public float bulletSpeed;
    public int damage;
    public ParticleSystem fx;
    void Start()
    {
        Destroy(gameObject,.5f);
        rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*bulletSpeed,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        GameObject target=collision.gameObject;
        if(target.tag=="ENEMY"){
            target.GetComponent<ENEMY1>().hp-=damage;
            if(target.GetComponent<ENEMY1>().hp<=0){
               Destroy(target);
               fx.Play();
            }
        }
        if(target.tag=="enemy"){
            target.GetComponent<enemy>().hp-=damage;
            if(target.GetComponent<enemy>().hp<=0){
              Destroy(target);
              fx.Play();
            }
        }
         Destroy(gameObject);
    }
}
