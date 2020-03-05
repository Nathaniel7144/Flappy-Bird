
using UnityEngine;

/**
* Spawn Ground ketika ground game object keluar 
* dari area Ground spawner game object
*/

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    //Menampung ground yang ingin dibuat
    [SerializeField]
    private Ground groundRef;

    //Menampung ground sebelumnya
    private Ground prevGround;

    //Method untuk membuat game object yang baru
    private void SpawnGround()
    {
        //Pengecekan null variable
        if(prevGround != null)
        {
            //duplikasi GroundRef
            Ground newGround = Instantiate(groundRef);

            //aktifkan game object
            newGround.gameObject.SetActive(true);

            //menempatkan new ground dengan posisi nextGround dari prevGround agar posisinya
            //sejajar dengan ground sebelumnya
            prevGround.SetNextGround(newGround.gameObject);
        }
    }

    //Method ini akan dipanggil ketika terdapat game object lain yang memiliki component
    //collider yang keluar dari area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Mencari component ground dari object yang keluar dari area trigger
        Ground ground = collision.GetComponent<Ground>();

        //Cek null variable
        if(ground)
        {
            //isi variable prevGround
            prevGround = ground;

            //Membuat ground baru
            SpawnGround();
        }
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