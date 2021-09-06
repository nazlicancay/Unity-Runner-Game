using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class JoystickPlayerExample : MonoBehaviour
{
    private AudioSource playerAudio;
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public GameManager gm;
    public float fallMulti = 3.5f;
    public float lowMult = 2f;
    private Animator playerAnim;
    public int JumpForce;
    public bool isOnTheGround = true;
    public Button RestartBotton;
    public AudioClip CrashS;
    

 

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.x > 3.25 )
        {
            transform.position = new Vector3(3.25f, transform.position.y, transform.position.z);
        }
        if(transform.position.x < 1.3)
        {
            transform.position = new Vector3(1.3f,transform.position.y , transform.position.z);
        }
        if (gm.isGameActive)
        {
            Vector3 direction = Vector3.right * floatingJoystick.Horizontal;
            transform.Translate(direction * speed * Time.fixedDeltaTime);

        }
      

        if (floatingJoystick.Vertical > 0.9f && gm.isGameActive && isOnTheGround )  
        {

            rb.velocity = Vector3.up * JumpForce;
            playerAnim.SetTrigger("Jump_trig");
            isOnTheGround = false;

        }
    }

 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gm.LevelUp = true;
            gm.isGameActive = false;
            Debug.Log("finish");
            GameManager.gameManagerInstance.LevelUpBotton.gameObject.SetActive(true);
            GameManager.gameManagerInstance.levelnum +=1 ;
            PlayerPrefs.SetInt("Level", GameManager.gameManagerInstance.levelnum);
            GameManager.gameManagerInstance.StartFromBeginingBotton.gameObject.SetActive(true);
           
            playerAnim.SetBool("Static_b", false);
            playerAnim.SetFloat("Speed_f", 0);
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            gm.isGameActive = false;
            playerAudio.PlayOneShot(CrashS , 0.5f);
            Debug.Log("game over");
            RestartBotton.gameObject.SetActive(true);

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;

        }        

       
    }

   
}