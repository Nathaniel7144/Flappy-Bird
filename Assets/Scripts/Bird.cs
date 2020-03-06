
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    //Global Variables
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead, OnAddPoint;
    [SerializeField] private int score;

    //UI
    [SerializeField] private Text scoreText;

    //Rigidbody Bird
    private Rigidbody2D rigidBody2D;

    //Animator bird
    private Animator animator;

    //init variable
    void Start()
    {
        //Mendapatkan component ketika game baru berjalan
        rigidBody2D = GetComponent<Rigidbody2D>();

        //Mendapatkan component animator pada gameObject
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if(!isDead && Input.GetMouseButtonDown(0))
        {
            //Burung melakukan "jump"
            Jump();
        }
    }

    //apakah sudah mati?
    public bool IsDead()
    {
        return isDead;
    }

    //Method dead
    public void Dead()
    {
        //Jika belum mati dan value ONDead tidak sama dengan null
        if(!isDead && OnDead != null)
        {
            //Memanggil semua event pada OnDead
            OnDead.Invoke();
        }

        //Set variable dead menjadi true
        isDead = true;
    }

    //Method Jump
    void Jump()
    {
        //Cek rigidbody null atau tidak
        if(rigidBody2D)
        {
            //Hentikan kecepatan burung ketika jatuh
            rigidBody2D.velocity = Vector2.zero;

            //Menambahkan gaya ke aray sumbu y agar burung melakukan "jump"
            rigidBody2D.AddForce(new Vector2(0, upForce));
        }

        //Cek null variable
        if(OnJump != null)
        {
            //Menjalankan semua event OnJump event
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //Menghentikan animasi jika collide
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        //Menambahkan score value
        score += value;

        //Pengecekan null value
        if(OnAddPoint != null)
        {
            //Memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();
        }

        //Mengubah nilai text pada score text
        scoreText.text = score.ToString();
    }
}
