using UnityEngine;
using System.Collections.Generic;

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

    List<Variable> newListVartoUpdate = new List<Variable>();
    List<Variable> neighbourList = new List<Variable>();


    public bool CharacterControlDisabled { get; set; }

    Conditions con = new Conditions();


    protected void Awake()
    {
        float speed = 650f;
        wm = GetComponent<WalkMovement>();
        jumpMovement = GetComponent<JumpMovement>();
        floorDetector = GetComponent<FloorDetector>();
        //walkMovement = GetComponent<NewBehaviourScript>();
        wm.walkSpeed = speed;

        walkMovement =  new NewBehaviourScript(wm, jumpMovement, floorDetector);
        
        //float velocity = 650f;



        //Debug.Log("speed of the variable");
        //Debug.Log(walkMovement.movement.walkSpeed);



        //Debug.Log("list of variables");

        // walkMovement.varList


        //Debug.Log();

        //walkMovement.varList =  

        newListVartoUpdate = walkMovement.theRules.getRandomRule(walkMovement.varList,5,10,3,9); // here need to catch the new rules
        
        walkMovement.newChanges = true; // to make the changes
        neighbourList = walkMovement.theRules.getNeighbors(walkMovement.varList, walkMovement.theRules.key);
        Debug.Log("rules updated quantity");
        Debug.Log(newListVartoUpdate.Count);
        Debug.Log("neighbours quantity");
        Debug.Log(neighbourList.Count);

        //walkMovement.varList[2] = walkMovement.theRules.changeWalkSpeed(walkMovement.varList[2],Conditions.conditions.lessThan, 651f, 4.0f);
        //aqui va el fill 
        //walkMovement.fillDictWalkSpeed(walkMovement.varList[2], 5.0f, 10.0f, 3.0f, 9.0f);
        //walkMovement.newChanges = true;
        //walkMovement.updatevariables();



        //Debug.Log("speed of the variable afther new rule wink wink");
        //Debug.Log(walkMovement.movement.walkSpeed);
        //Debug.Log(walkMovement.varList[2].valueFloat);








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
