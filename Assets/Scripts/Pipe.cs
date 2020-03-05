
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //Global Variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cek burung sudah mati/ belum
        if(!bird.IsDead())
        {
            //Membuat pipa bergerak ke sebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //cek null value
        if(bird)
        {
            //dapatkan component collider pada game object
            Collider2D collider = GetComponent<Collider2D>();

            //cek null variable atau tidak
            if(collider)
            {
                //non aktifkan cllider
                collider.enabled = false;
            }

            bird.Dead();
        }
    }
}
