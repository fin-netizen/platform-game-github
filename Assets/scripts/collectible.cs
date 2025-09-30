using System.Runtime.CompilerServices;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public bool isPlayerThere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
        
    }
   /* 
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
   */
}
