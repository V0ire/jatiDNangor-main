using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class CharMovement : MonoBehaviour
{
 /*Change the value at unity
 Input the gameobject for animator*/
    public Animator animator;
    [SerializeField] private bool isRepeatedMovement = false;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;
    private bool isMoving = false;
    public LogicScript logic;
    public bool playerIsAlive = true;
    private float x;
    private float y;
    private bool moving;
    UnityEngine.Vector2 movement;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>(); //input logic prefab
    }

    private void Update()
    {
        /*Main code for char movement*/
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movement = new UnityEngine.Vector2(x, y);
        Animate();
        
        if (!isMoving && playerIsAlive)
        {
            System.Func<KeyCode, bool> inputFunction;
            if (isRepeatedMovement)
            {
                inputFunction = Input.GetKey;
            }
            else
            {
                inputFunction = Input.GetKeyDown;
            }

            if (inputFunction(KeyCode.UpArrow))
            {
                StartCoroutine(Move(UnityEngine.Vector2.up));
            }
            else if (inputFunction(KeyCode.DownArrow))
            {
                StartCoroutine(Move(UnityEngine.Vector2.down));
            }
            else if (inputFunction(KeyCode.LeftArrow))
            {
                StartCoroutine(Move(UnityEngine.Vector2.left));
            }
            else if (inputFunction(KeyCode.RightArrow))
            {
                StartCoroutine(Move(UnityEngine.Vector2.right));
            }
        }
    }
 

    private IEnumerator Move(UnityEngine.Vector2 direction)
    {
        isMoving = true;

        UnityEngine.Vector2 startPosition = transform.position;
        UnityEngine.Vector2 endPosition = startPosition + (direction * gridSize);

        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = UnityEngine.Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        transform.position = endPosition;

        isMoving = false;
    }
    void OnCollisionEnter2D(Collision2D other) //Scene Controller (gameover, ending)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
        logic.gameOver_crash();
        playerIsAlive = false;
        Debug.Log("gameover true");
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
        logic.missionSuccess();
        playerIsAlive = false;
        Debug.Log("missionSuccess true");
        }
    }
    private void Animate() //
    {
        if(movement.magnitude > 0.1f || movement.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if(moving)
        {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        }
        animator.SetBool("Moving", moving);
    }
    
}
