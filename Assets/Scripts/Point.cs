
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Point : MonoBehaviour
{
    //Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cek apakah burung mati atau tidak
        if (!bird.IsDead())
        {
            //Menggerakan game object kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        //Mendapatkan component BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        //Cek null variable
        if(collider != null)
        {
            //ubah ukuran collider
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Mendapatkan component Bird
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //Menambahkan score jika burung tidak null dan burung belum mati;
        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
