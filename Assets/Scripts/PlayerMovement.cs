using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 rawInput;
    Vector2 minBound;
    Vector2 maxBound;
    Shooter shooter;
    void Awake()
    {
        shooter=GetComponent<Shooter>();
    }
    void Start()
    {
        InitBound();
    }
    void Update()
    {
        
    }
    void InitBound()
    {
        Camera mainCamera=Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound=mainCamera.ViewportToWorldPoint(new Vector2(1,1)); 
    }
    public void MoveLeft()
    {
        Vector3 delta = new Vector2(-10f,0) * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x+delta.x,minBound.x+paddingLeft, maxBound.x-paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y+paddingBottom, maxBound.y-paddingTop);
        transform.position = newPos;
        if (shooter != null)
        {
            shooter.isFiring = true;
        }
    }
    public void MoveRight()
    {
        Vector3 delta = new Vector2(10f, 0) * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);
        transform.position = newPos;
        if (shooter != null)
        {
            shooter.isFiring = true;
        }
    }

    public void OnMove(InputValue value)
    {
        rawInput=value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if(shooter!=null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
