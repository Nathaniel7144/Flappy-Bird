using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float holeSize = 1f;
    [SerializeField] private Point point;

    //Variable penampung coroutine
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSpawn()
    {
        //Menjalankan fungsi Coroutine IeSpawn
        if(CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Hentikan coroutine
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //duplikasi game object pipeUp dan menempatkan posisinya sama 
        //dengan game object ini tapi dibalik
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0,0,180));

        //aktifkan newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //duplikasi game object pipeDown dan menempatkan posisinya sama
        //dengan posisi game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //aktifkan newPipeDown
        newPipeDown.gameObject.SetActive(true);

        //tempatkan posisi pipa yang sudah terbentuk agar ada lubang di tengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize/2);
        newPipeDown.transform.position += Vector3.down * (holeSize/2);

        //Buat angka random untuk menentukan posisi pipa
        float y = Random.Range(-1.0f, 1.1f);
        
        //tempatkan posisi pipa yang telah dibentuk agar posisinya random
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;
        
        //Point
        Point newPoint = Instantiate(point, transform.position,Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while(true)
        {
            //Jika burung mati stop
            if(bird.IsDead())
            {
                StopSpawn();
            }

            //Buat pipa baru
            SpawnPipe();

            //Tunggu beberapa detik sesuai dengan interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
