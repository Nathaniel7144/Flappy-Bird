
using UnityEngine;

//Component akan ditambahkan jika tidak ada dan komponen tersebut tidak dapat dibuang
[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cek apakah bird null atau belum mati
        if(bird == null || (bird != null && !bird.IsDead()))
        {
            //Membuat pipa bergerak ke sebelah kiri dengan kecepatan dari variable speed
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //Method untuk menempatkan game object pada posisi next ground
    public void SetNextGround(GameObject ground)
    {
        //Cek null value
        if(ground != null)
        {
            //Menempatkan ground berikutnya pada posisi nextground
            ground.transform.position = nextPos.position;
        }
    }

    //Dipanggil ketika game object bersentuhan dengan game object yang lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Membuat burung mati ketika bersentuhan dengna game object ini
        if(bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}
