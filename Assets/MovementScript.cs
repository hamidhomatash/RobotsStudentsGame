using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{

    public float speed;
    public float jump;
    float moveVelocity;
    public Gravity gravity;
    public GameObject theEnd;
    public BoxCollider2D boxCol;
    public GameObject TheEnd;
    public GameObject Player;
    public GameObject Final;
    public GameObject Final1;
    public GameObject Final2;
    public GameObject Final3;
    public GameObject Final4;



    public AudioSource source;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip magnetSound;
    public AudioClip fixSound;
    public AudioClip smokeSound;

    Animator anim;

    public bool normal;
    public bool wall;
    public bool gravityEnabled;
    public bool fixing;
    public bool death;

    public bool isGrounded = true;

    Vector3 startPos;

    public int Level1 = 0;
    public int Level2 = 0;
    public int Level3 = 0;
    public int Level4 = 0;
    public int Level5 = 0;

    public GameObject LevelText;
    public GameObject Button1;
    public GameObject Button2;

    void Start()
    {
        anim = this.GetComponent<Animator>();

        if (gravity.enabled)
        {
            gravityEnabled = true;
        }
        else
        {
            gravityEnabled = false;
        }

        normal = true;
        wall = false;
        fixing = false;


        startPos = this.transform.position;

        //boxCol = theEnd.GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();

        LevelText.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);

        Final.SetActive(true);
        Final1.SetActive(true);
        Final2.SetActive(true);
        Final3.SetActive(true);
        Final4.SetActive(true);


    }

    void Update()
    {

        if (normal == true)
        {
            float axisX = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(axisX, 0) * Time.deltaTime * speed);
        }

        if (wall == true)
        {
            float axisY = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, axisY) * Time.deltaTime * speed);
        }

        if (Input.GetButton("Horizontal") && fixing == false)
        {
            anim.SetInteger("CharacterStage", 1);
        }

        else if (!Input.GetButton("Horizontal") && fixing == false)
        {
            anim.SetInteger("CharacterStage", 0);
        }

        if (Input.GetButton("Vertical") && wall == true)
        {
            anim.SetInteger("CharacterStage", 1);
        }

        else if (!Input.GetButton("Vertical") && wall == true)
        {
            anim.SetInteger("CharacterStage", 0);
        }

        if (death == true)
        {
            anim.SetInteger("CharacterStage", 5);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("CharacterStage", 2);

            if (isGrounded == true)
            {
                //anim.SetInteger("CharacterStage", 0);
                source.PlayOneShot(jumpSound, 0.5F);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                isGrounded = false;
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
        }

        if (Level1 == 2)
        {
            Final.SetActive(false);
        }

            if (Level1 >= 3)
            {
                if (SceneManager.GetActiveScene().name == "Lolz")
                {
                    LevelText.SetActive(true);
                    Button1.SetActive(true);
                    Button2.SetActive(true);
                }
            }
        

        if (Level2 == 2)
        {
            Final1.SetActive(false);
        }

            if (Level2 >= 3)
            {
                if (SceneManager.GetActiveScene().name == "MediumDifficultyLevel")
                {
                    LevelText.SetActive(true);
                    Button1.SetActive(true);
                    Button2.SetActive(true);
                }
            }
        


        if (Level3 == 5)
        {
            Final2.SetActive(false);
        }

            if (Level3 >= 6)
            {
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    LevelText.SetActive(true);
                    Button1.SetActive(true);
                    Button2.SetActive(true);
                }
            }
        

        if (Level4 == 3)
        {
            Final3.SetActive(false);
        }

            if (Level4 >= 4)
            {
                if (SceneManager.GetActiveScene().name == "Level 4")
                {
                    LevelText.SetActive(true);
                    Button1.SetActive(true);
                    Button2.SetActive(true);
                }
            }


        //if (Level5 == 2)
        //{
        //    Final4.SetActive(false);
        //}

        if (Level5 >= 4)
        {
            if (SceneManager.GetActiveScene().name == "Level 5 - With Background")
            {
                LevelText.SetActive(true);
                Button1.SetActive(true);
                Button2.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelSelection");
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Respawn")
        {
            StartCoroutine(DyingRespawn());
            //yield return WaitForSeconds(1);
            //source.PlayOneShot(deathSound, 1F);
            //this.transform.position = startPos;
        }
        if (collider.gameObject.tag == "Collect")
        {
            Destroy(collider.gameObject);
            boxCol.enabled = true;
        }

        if (collider.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }

        if (collider.gameObject.tag == "EndAnims")
        {
            StartCoroutine(Wait());
            fixing = true;
            anim.SetInteger("CharacterStage", 4);
        }

        if (collider.gameObject.tag == "SlowDown")
        {
            Physics2D.gravity = new Vector3(-50f, -25f, 0f);
        }
    }

    IEnumerator Wait()
    {
        source.PlayOneShot(fixSound, 1F);
        isGrounded = false;
        normal = false;
        yield return new WaitForSeconds(2.5f);
        Level1++;
        Level2++;
        Level3++;
        Level4++;
        Level5++;
        source.PlayOneShot(smokeSound, 1f);
        normal = true;
        isGrounded = true;
    }

    IEnumerator DyingRespawn()
    {
        source.PlayOneShot(deathSound, 1F);
        normal = false;
        wall = false;
        death = true;
        yield return new WaitForSeconds(0.5f);
        death = false;
        this.transform.position = startPos;
        normal = true;
        wall = true;
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MagnetRoof")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetWallR")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = false;
                wall = true;
            }
            else if (gravity.enabled == false && gravityEnabled == false)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetWallL")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = false;
                wall = true;
            }
            else if (gravity.enabled == false && gravityEnabled == false)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushLow")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;

            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushRight")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3f);
                isGrounded = true;
            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushLeft")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }
            else if (Input.GetKeyDown("p"))
            {
                gravity.enabled = false;
                gravityEnabled = false;
                Physics2D.gravity = new Vector3(0f, -25f, 0f);
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushLeftDia")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }

            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushRightDia")
        {
            if (Input.GetKeyDown("o"))
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
            }

            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MagnetWallR")
        {
            normal = true;
            wall = false;
        }
        if (collider.gameObject.tag == "MagnetWallL")
        {
            normal = true;
            wall = true;
        }

        if (collider.gameObject.tag == "EndAnims")
        {
            fixing = false;
        }
    }
}