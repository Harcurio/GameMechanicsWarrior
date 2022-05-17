using UnityEngine;

[RequireComponent(typeof(WalkMovement))]
[RequireComponent(typeof(JumpMovement))]
[RequireComponent(typeof(AttackMovement))]
[RequireComponent(typeof(TurnAround))]
[RequireComponent(typeof(FloorDetector))]
[RequireComponent(typeof(NewBehaviourScript))]

public class PlayerController : MonoBehaviour
{
     WalkMovement wm;

     NewBehaviourScript walkMovement;
    //WalkMovement wm = new WalkMovement();
    //NewBehaviourScript walkMovement = new NewBehaviourScript(wm);

    JumpMovement jumpMovement;
    AttackMovement attackMovement;
    FloorDetector floorDetector;
    Rigidbody2D myBody;
    DashMovement dashMovement;

    public bool CharacterControlDisabled { get; set; }

    protected void Awake()
    {
        wm = GetComponent<WalkMovement>();
        //walkMovement = GetComponent<NewBehaviourScript>();
        wm.walkSpeed = 3f;

        walkMovement =  new NewBehaviourScript(wm);
        //float velocity = 650f;

        unsafe
        {
            *walkMovement.varList[2].varFloat = 650f; 
        }
        
        Debug.Log("speed of the variable");
        Debug.Log(wm.walkSpeed);



        Debug.Log("list of variables");
        unsafe
        {
            Debug.Log(*walkMovement.varList[2].varFloat);
            Debug.Log(*walkMovement.varList[2].varFloat);
        }
  


        walkMovement.varList =  walkMovement.theRules.getRandomRule(walkMovement.varList);
        Debug.Log("speed of the variable afther new rule wink wink");
        Debug.Log(wm.walkSpeed);








        jumpMovement = GetComponent<JumpMovement>();
        attackMovement = GetComponent<AttackMovement>();
        floorDetector = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();
        dashMovement = GetComponent<DashMovement>();
        CharacterControlDisabled = false;
    }

    protected void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftControl) && floorDetector.isTouchingFloor || CharacterControlDisabled && floorDetector.isTouchingFloor)
        {
            unsafe
            {
                *walkMovement.varList[5].varFloat = 0;
            }
            
        }

        if((Input.GetButton("Left") && !Input.GetKey(KeyCode.LeftControl)) && 
            !CharacterControlDisabled)
        {
            unsafe
            {
                *walkMovement.varList[5].varFloat = Input.GetAxis("Left");
                walkMovement.movement.desiredWalkDirection = *walkMovement.varList[5].varFloat;
            }
            
            
        }
        else if(Input.GetButtonUp("Left"))
        {
            unsafe
            {
                *walkMovement.varList[5].varFloat = 0;
                walkMovement.movement.desiredWalkDirection = *walkMovement.varList[5].varFloat;
            }
            
            
        }

        if ((Input.GetButton("Right") && !Input.GetKey(KeyCode.LeftControl)) && 
            !CharacterControlDisabled)
        {
            unsafe
            {
                *walkMovement.varList[5].varFloat = Input.GetAxis("Right");
                walkMovement.movement.desiredWalkDirection = *walkMovement.varList[5].varFloat;
            }
            
            
        }
        else if (Input.GetButtonUp("Right"))
        {
            unsafe
            {
                *walkMovement.varList[5].varFloat = 0;
                walkMovement.movement.desiredWalkDirection = *walkMovement.varList[5].varFloat;
            }
            
            
        }

        /*if (Input.GetButtonDown("Attack") && !CharacterControlEnabled)
        {
            attackMovement.attackRequest = true;
        }*/

        if(Input.GetKeyDown(KeyCode.D) && floorDetector.isTouchingFloor && !CharacterControlDisabled)
        {
            dashMovement.dash = true;
        }
    }
}
