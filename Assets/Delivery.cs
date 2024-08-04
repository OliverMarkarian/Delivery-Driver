using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32 (176,1,255,255);
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
    [SerializeField] float destroyDelay = 0.3f;
    
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

void OnCollisionEnter2D(Collision2D other) 
{
    Debug.Log("Ouch");
}
void OnTriggerEnter2D(Collider2D other) {

        

        if (other.tag == "Package" && !hasPackage){
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject,destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }

        // If the thing we trigger is the package
        //{
        //          print package picked up
        //}
        if (other.tag == "Customer" && hasPackage){
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        // If the thing we trigger is the receiver
        //{
        //print package delivered
        //}

    }
}
