using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonalInput : MonoBehaviour
{
    //public VariableJoystick joystickPers;
    public FixedJoystick joystick;

    private ThirdPersonalController tpc;
    //private ThirdPersonalAttack tpAttack;

    private void Start()
    {
        tpc = GetComponent<ThirdPersonalController>();

        // если загружено с ПК, то спрятать джойстик
        if(Application.isEditor)
        {
            joystick.gameObject.SetActive(false);
        }
        // иначе, если мобильный, то включить джойстик
        else if(Application.isMobilePlatform)
        {
            joystick.gameObject.SetActive(true);
        }
        
        // tpAttack = GetComponent<ThirdPersonalAttack>();
    }
    private void Update()
    {
       // tpc.Movement(joystick.Horizontal, joystick.Vertical);
        if (Application.isEditor)
        {
            tpc.Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));            
            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    tpc.Run(5.0f);
            //}
            //else if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    tpc.Run(1.5f);
            //}
            //if (Input.GetMouseButtonDown(0))
            //{
            //    tpAttack.AttackPaw();
            //}
            //if (Input.GetMouseButtonUp(1))
            //{
            //    tpAttack.AttackRoar();
            //}
        }
        else
        {
            // мобильное упроавление
            //tpc.Movement(joystickPers.Horizontal, joystickPers.Vertical);
            tpc.Movement(joystick.Horizontal, joystick.Vertical);
        }
    }
    public void Run(bool _isRun)
    {
        if (_isRun)
        {
            tpc.Run(5.0f);
        }
        else
        {
            tpc.Run(1.5f);
        }
    }
    public void Paw()
    {
   //     tpAttack.AttackPaw();
    }
    public void Roar()
    {
  //      tpAttack.AttackRoar();
    }
}
