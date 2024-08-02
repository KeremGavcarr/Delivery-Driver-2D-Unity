using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Appears!");

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // SerializeField[]
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);

        }
        if (collision.tag == "Customer" && hasPackage)
        {

            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }

}
