using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonalController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    private ThirdPersonalAnimations tpa;

    public float speed = 3.0f;

    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    private float energy = 100.0f;
    private bool isCarrot;
    private float timerCarrotEffect = 5.0f;

    private void Start()
    {
        tpa = GetComponent<ThirdPersonalAnimations>();
        GameManager.Instance.EnergyUI(energy);
    }
    // private void Update()
    // {
    //float horizontal = Input.GetAxisRaw("Horizontal");
    // float vertical = Input.GetAxisRaw("Vertical");
    public void Run(float _speed)
    {
        speed = _speed;
        //tpa.WalkRunAnim(speed);
    }
    public void AddEnegy(float _enegy)
    {
        energy += _enegy;
        GameManager.Instance.EnergyUI(energy);
    }
    public void Carrot()
    {
        isCarrot = true;
    }
    private void Update()
    {
        energy -= Time.deltaTime;
        GameManager.Instance.EnergyUI(energy);

        if(energy <= 0)
        {
            GameManager.Instance.StatusGame(false);
        }
        if (isCarrot)
        {
            speed = 10.0f;
            timerCarrotEffect -= Time.deltaTime;
            if(timerCarrotEffect <= 0)
            {
                speed = 5.0f;
                timerCarrotEffect = 5;
                isCarrot = false;
            }
        }
    }
    public void Movement(float h, float v)
    {
        float horizontal = h;
        float vertical = v;
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        tpa.WalkIdleAnim(direction.magnitude);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            Vector3 posY = new Vector3(transform.position.x, 0.282f, transform.position.z);
            transform.position = posY;
        }
    }
   // }
}
