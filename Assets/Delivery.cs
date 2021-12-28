using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
     spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    bool hasPackage; 
    

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Package" && !hasPackage)
      {
         Debug.Log("Weed picked up");
         hasPackage = true;
         spriteRenderer.color = hasPackageColor;
         Destroy(other.gameObject, destroyDelay);
      }

      if(other.tag == "Objective" && hasPackage)
      {
         Debug.Log("Weed delivered");
         hasPackage = false;
         spriteRenderer.color = noPackageColor; 
      }   
    }
}
