using System.Collections; 
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine;




// TESTING THIS AS WRAPPER


public class NewBehaviourScript : MonoBehaviour {

    //For variables to change.
    public WalkMovement movement;
    public JumpMovement jumpMovement;
    public AttackMovement attackM;
    public TurnAround tAround;
    public FloorDetector floorD;  //need to check if this need to be done 
    public Rigidbody2D myBody;


    //For newBehaviours 
    public NewRules theRules = new NewRules();
    public bool newChanges = false;
    public List<Variable> varList = new List<Variable>();





    protected void Awake()
    {
        movement = GetComponent<WalkMovement>();
        jumpMovement = GetComponent<JumpMovement>();
        attackM = GetComponent<AttackMovement>();
        tAround = GetComponent<TurnAround>();
        floorD = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();


       



    }

    public NewBehaviourScript(WalkMovement movement) {

        this.movement = movement;


        //Variable bar14 = new Variable("", );

        Variable bar0 = new Variable("knockbackStrength", movement.knockbackStrength);
        Variable bar1 = new Variable("knockBackLength", movement.knockBackLength);
        Variable bar2 = new Variable("walkSpeed", movement.walkSpeed);
        Variable bar3 = new Variable("knockbackTimeCount", movement.knockbackTimeCount);
        Variable bar4 = new Variable("knockFromRight", movement.knockFromRight);
        Variable bar5 = new Variable("desiredWalkDirection", movement.desiredWalkDirection);
        Variable bar6 = new Variable("knockbackFinished", movement.knockbackFinished);
        Variable bar7 = new Variable("canDoubleJump", jumpMovement.canDoubleJump);
        Variable bar8 = new Variable("isAttacking", attackM.isAttacking);
        Variable bar9 = new Variable("AttackMovementEnabled", attackM.AttackMovementEnabled);
        Variable bar10 = new Variable("isFacingLeft", tAround.isFacingLeft );
        Variable bar11 = new Variable("IsFacingRight", tAround.IsFacingRight);
        Variable bar12 = new Variable("direction", tAround.direction);
        Variable bar13 = new Variable("isTouchingFloor", floorD.isTouchingFloor);
        //Variable bar14 = new Variable("distanceToFloor", floorD.distanceToFloor); for nullable values...
        //Variable bar14 = new Variable("",myBody. );


        varList.Add(bar0);
        varList.Add(bar1);
        varList.Add(bar2);
        varList.Add(bar3);
        varList.Add(bar4);
        varList.Add(bar5);
        varList.Add(bar6);


        //Debug.Log("nombre de la variable: ");
        //Debug.Log(varList[2].nameVariable);
   
        



    }










        // Use this for initialization
    void Start () {


        //Debug.Log("entra al start de newBehaviour");



    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //updatevariables();  



    }

    




    public void updatevariables()
    {
        
        if (newChanges)
        {
            Debug.Log(" se hicieron los cambios...");
            movement.walkSpeed = varList[2].valueFloat;


            newChanges = false;
        }

    }

}


