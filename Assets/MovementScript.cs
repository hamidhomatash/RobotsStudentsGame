using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	public GameObject BlockerObstacle;

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

    public GameObject LevelText;

	[SerializeField] private Text objectiveText;

	[SerializeField] private GameObject killZoneLeft;
	[SerializeField] private GameObject killZoneRight;
	[SerializeField] private GameObject killZoneTop;
	[SerializeField] private GameObject killZoneBottom;

	private bool levelComplete = false;
	private int objectivesComplete = 0;
	private int totalObjectives = 0;

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

		if (BlockerObstacle != null)
		{
			BlockerObstacle.SetActive(true);
		}

		totalObjectives = GameObject.FindObjectsOfType<FixPointsScript>().Length;

		LevelText.SetActive(false);
	}

	/// <summary>
	/// There is a bug sometimes where the player can leave the level by falling through it. Therefore
	/// to prevent the user from being stuck forever due to this killzone markers have been placed in the
	/// levels and this funcion checks the player position against them to make sure to kill the player
	/// if they go outwith the kill zone boundries
	/// </summary>
	private void CheckKillZones()
	{
		Vector3 position = transform.position;
		if(	position.x <= killZoneLeft.transform.position.x || position.x >= killZoneRight.transform.position.x ||
			position.y <= killZoneBottom.transform.position.y || position.y >= killZoneTop.transform.position.y)
		{
			StartCoroutine(DyingRespawn());
		}
	}

    private void Update()
    {
		if (objectiveText != null)
		{
			objectiveText.text = objectivesComplete + " / " + totalObjectives;
		}

		// Don't do anything if currently dying or the level is complete
		if (death || levelComplete)
		{
			return;
		}

		CheckKillZones();

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

		if (!fixing)
		{
			if (Input.GetButton("Horizontal"))
			{
				anim.SetInteger("CharacterStage", 1);
			}
			else if (!Input.GetButton("Horizontal"))
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

			if (IsJumpButtonDown())
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
		}

		CheckRemoveBlockerObstacle();
		CheckLevelComplete();

		if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }
	

	private void CheckRemoveBlockerObstacle()
	{
		if (objectivesComplete == totalObjectives - 1 && BlockerObstacle != null)
		{
			BlockerObstacle.SetActive(false);
		}
	}
	private void CheckLevelComplete()
	{
		if(!levelComplete)
		{
			if(objectivesComplete >= totalObjectives)
			{
				levelComplete = true;
				LevelText.SetActive(true);

				StartCoroutine(LevelCompleteSequence());
			}
		}
	}

	IEnumerator LevelCompleteSequence()
	{
		yield return new WaitForSeconds(4.0f);

		// If game not complete yet go to next level
		if (Singleton.Instance.completedLevels < LevelSelectScript.totalLevels)
		{
			++Singleton.Instance.completedLevels;
			++Singleton.Instance.currentLevelIndex;
		}

		// Otherwise load the level select screen
		SceneManager.LoadScene("LevelSelection");
	}

	void OnTriggerEnter2D(Collider2D collider)
    {
		// Don't do anything if currently dying or the level is complete
		if (death || levelComplete)
		{
			return;
		}

		if (collider.gameObject.tag == "Respawn")
        {
            StartCoroutine(DyingRespawn());
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

        if (collider.gameObject.tag == "EndAnims" && !fixing)
        {
            StartCoroutine(SetObjectiveComplete(collider.gameObject));
        }

        if (collider.gameObject.tag == "SlowDown")
        {
            Physics2D.gravity = new Vector3(-50f, -25f, 0f);
        }
    }

    IEnumerator SetObjectiveComplete(GameObject objectiveGameObject)
    {
		++objectivesComplete;
		fixing = true;
		anim.SetInteger("CharacterStage", 4);

		source.PlayOneShot(fixSound, 1F);
        isGrounded = false;
        normal = false;

		AnimFixing animFixing = objectiveGameObject.GetComponent<AnimFixing>();
		if(animFixing != null)
		{
			StartCoroutine(animFixing.PlayAnimation());
		}

        yield return new WaitForSeconds(2.5f);
		
        source.PlayOneShot(smokeSound, 1f);
        normal = true;
        isGrounded = true;
		fixing = false;

		FixPointsScript fixPointsScript = objectiveGameObject.GetComponent<FixPointsScript>();
		if(fixPointsScript != null)
		{
			fixPointsScript.SetFixed();
		}
    }

    IEnumerator DyingRespawn()
    {
        source.PlayOneShot(deathSound, 1F);
		anim.SetInteger("CharacterStage", 5);
		normal = false;
        wall = false;
        death = true;
        yield return new WaitForSeconds(1.0f);
		death = false;
		normal = true;
		transform.position = startPos;
		anim.SetInteger("CharacterStage", 0);
	}


    void OnTriggerStay2D(Collider2D collider)
    {
		// Don't do anything if currently dying or the level is complete
		if (death || levelComplete)
		{
			return;
		}

		if (collider.gameObject.tag == "MagnetRoof")
        {
            if (IsMagnetButtonDown())
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

        if (collider.gameObject.tag == "MagnetWallR")
        {
			if (IsMagnetButtonDown())
			{
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3F);
                isGrounded = true;
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
            if (IsMagnetButtonDown())
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
            if (IsMagnetButtonDown())
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

        if (collider.gameObject.tag == "MagnetPushRight")
        {
            if (IsMagnetButtonDown())
            {
                anim.SetInteger("CharacterStage", 3);
                gravity.enabled = true;
                gravityEnabled = true;
                source.PlayOneShot(magnetSound, 0.3f);
                isGrounded = true;
            }
            if (gravity.enabled == true && gravityEnabled == true)
            {
                normal = true;
                wall = false;
            }
        }

        if (collider.gameObject.tag == "MagnetPushLeft")
        {
            if (IsMagnetButtonDown())
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

        if (collider.gameObject.tag == "MagnetPushLeftDia")
        {
            if (IsMagnetButtonDown())
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
            if (IsMagnetButtonDown())
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
		// Don't do anything if currently dying or the level is complete
		if (death || levelComplete)
		{
			return;
		}

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
    }

	private bool IsMagnetButtonDown()
	{
		return Input.GetKeyDown(KeyCode.M) ||
			Input.GetKeyDown(KeyCode.O) ||
			Input.GetKeyDown(KeyCode.Return) ||
			Input.GetKeyDown(KeyCode.LeftAlt) ||
			Input.GetKeyDown(KeyCode.Keypad5);
	}

	private bool IsJumpButtonDown()
	{
		return Input.GetKeyDown(KeyCode.Space) ||
			Input.GetKeyDown(KeyCode.P) ||
			Input.GetKeyDown(KeyCode.Return) ||
			Input.GetKeyDown(KeyCode.Keypad0) ||
			Input.GetKeyDown(KeyCode.KeypadPeriod) ||
			Input.GetKeyDown(KeyCode.KeypadEnter) ||
			Input.GetKeyDown(KeyCode.KeypadPlus) ||
			Input.GetKeyDown(KeyCode.KeypadMinus) ||
			Input.GetKeyDown(KeyCode.KeypadMultiply) ||
			Input.GetKeyDown(KeyCode.KeypadDivide);
	}
}