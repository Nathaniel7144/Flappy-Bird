
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //Memusnahkan object ketika bersentuhan
        Destroy(collision.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
