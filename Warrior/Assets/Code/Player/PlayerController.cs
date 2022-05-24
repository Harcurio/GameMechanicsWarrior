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
        float speed = 650f;
        wm = GetComponent<WalkMovement>();
        //walkMovement = GetComponent<NewBehaviourScript>();
        wm.walkSpeed = speed;

        walkMovement =  new NewBehaviourScript(wm);
        //float velocity = 650f;

        
        
        Debug.Log("speed of the variable");
        Debug.Log(walkMovement.movement.walkSpeed);



        Debug.Log("list of variables");

        // walkMovement.varList


        //Debug.Log();

        // walkMovement.varList =  walkMovement.theRules.getRandomRule(walkMovement.varList); // here
        //walkMovement.newChanges = true; // to make the changes

        walkMovement.varList[2] = walkMovement.theRules.changeWalkSpeed(walkMovement.varList[2], speed, 651f);
        walkMovement.newChanges = true;
        walkMovement.updatevariables();

        

        Debug.Log("speed of the variable afther new rule wink wink");
        Debug.Log(walkMovement.movement.walkSpeed);
        Debug.Log(walkMovement.varList[2].valueFloat);








        jumpMovement = GetComponent<JumpMovement>();
        attackMovement = GetComponent<AttackMovement>();
        floorDetector = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();
        dashMovement = GetComponent<DashMovement>();
        CharacterControlDisabled = false;


        // las regl as se generan antes del update dado que en el update se deben mantener los valores..
        // la segunda fase sera hacer todo con el update
    }

    protected void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftControl) && floorDetector.isTouchingFloor || CharacterControlDisabled && floorDetector.isTouchingFloor)
        {
            
             walkMovement.varList[5].valueFloat = 0;
            
            
        }

        if((Input.GetButton("Left") && !Input.GetKey(KeyCode.LeftControl)) && 
            !CharacterControlDisabled)
        {
            
             walkMovement.varList[5].valueFloat = Input.GetAxis("Left");
             walkMovement.movement.desiredWalkDirection = walkMovement.varList[5].valueFloat;
            
            
            
        }
        else if(Input.GetButtonUp("Left"))
        {
            
             walkMovement.varList[5].valueFloat = 0;
             walkMovement.movement.desiredWalkDirection = walkMovement.varList[5].valueFloat;
            
            
            
        }

        if ((Input.GetButton("Right") && !Input.GetKey(KeyCode.LeftControl)) && 
            !CharacterControlDisabled)
        {
            
             walkMovement.varList[5].valueFloat = Input.GetAxis("Right");
             walkMovement.movement.desiredWalkDirection = walkMovement.varList[5].valueFloat;
            
            
            
        }
        else if (Input.GetButtonUp("Right"))
        {
            
             walkMovement.varList[5].valueFloat = 0;
             walkMovement.movement.desiredWalkDirection = walkMovement.varList[5].valueFloat;
            
            
            
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
