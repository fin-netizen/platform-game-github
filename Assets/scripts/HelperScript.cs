using UnityEngine;

public class HelperScript : MonoBehaviour
{
    
    public void DoFlipObject(bool flip)
    {
        // get the SpriteRenderer component
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }
    
    
        
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
       if (Input.GetKey("h"))
       {
            print("hello world");
       }
       
    }
}
