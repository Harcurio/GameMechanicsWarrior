using System.Collections; 
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;




// TESTING THIS AS WRAPPER


public class NewBehaviourScript : MonoBehaviour {

    //To hold all the possible changes in the variables
    //Hashtable hashTableVariables = new Hashtable();
    public Dictionary<string, Variable> VariablesDict = new Dictionary<string, Variable>();
    //to save the objects in the dictionary
    public BinaryFormatter formatter;

    //For variables to change.
    public WalkMovement movement;
    public JumpMovement jumpMovement;// ONE VARIABLE
    public AttackMovement attackM; //ONLY ONE VARIABLE
    public TurnAround tAround; // TWO BOOLEANS
    public FloorDetector floorD;  //need to check if this need to be done 
    public Rigidbody2D myBody;


    //For newBehaviours 
    public NewRules theRules = new NewRules();
    public bool newChanges = false;
    public List<Variable> varList = new List<Variable>();
    public List<Variable> oldVarList = new List<Variable>();





    protected void Awake()
    {
        movement = GetComponent<WalkMovement>();
        jumpMovement = GetComponent<JumpMovement>();
        attackM = GetComponent<AttackMovement>();
        tAround = GetComponent<TurnAround>();
        floorD = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();


       



    }

    public NewBehaviourScript(WalkMovement movement, JumpMovement jumpMovement, FloorDetector floorD) {

        this.movement = movement;
        this.jumpMovement = jumpMovement;


        //Variable bar14 = new Variable("", );

        Variable bar0 = new Variable("knockbackStrength", movement.knockbackStrength);
        Variable bar1 = new Variable("knockBackLength", movement.knockBackLength);
        Variable bar2 = new Variable("walkSpeed", movement.walkSpeed);
        Variable bar3 = new Variable("knockbackTimeCount", movement.knockbackTimeCount);
        Variable bar4 = new Variable("knockFromRight", movement.knockFromRight);
        Variable bar5 = new Variable("desiredWalkDirection", movement.desiredWalkDirection);
        Variable bar6 = new Variable("knockbackFinished", movement.knockbackFinished);
        Variable bar7 = new Variable("jumpSpeed", jumpMovement.jumpSpeed);

        //Variable bar8 = new Variable("isTouchingFloor", floorD.isTouchingFloor);
        //Variable bar9 = new Variable("AttackMovementEnabled", attackM.AttackMovementEnabled);
        //Variable bar10 = new Variable("isFacingLeft", tAround.isFacingLeft );
        //Variable bar11 = new Variable("IsFacingRight", tAround.IsFacingRight);
        //Variable bar12 = new Variable("direction", tAround.direction);
        //Variable bar13 = new Variable("isAttacking", attackM.isAttacking);
        //Variable bar14 = new Variable("distanceToFloor", floorD.distanceToFloor); //for nullable values...??
        //Variable bar14 = new Variable("",myBody. );

        /*
        this.varList.Add(bar0);
        this.varList.Add(bar1);*/
        this.varList.Add(bar2);
        /*this.varList.Add(bar3);
        this.varList.Add(bar4);
        this.varList.Add(bar5);
        this.varList.Add(bar6);
        this.varList.Add(bar7);*/

        //this.varList.Add(bar8);
        //this.varList.Add(bar9);
        //this.varList.Add(bar10);
        //this.varList.Add(bar11);
        //this.varList.Add(bar12);
        //this.varList.Add(bar13);
        //varList.Add(bar14);


        //Debug.Log("nombre de la variable: ");
        //Debug.Log(varList[2].nameVariable);



        this.oldVarList = this.varList;

    }



    public void resetVariables()
    {
        this.varList = this.oldVarList;
    }


    public Variable getRandomVariable()
    {
        Variable toModify;
        int location = UnityEngine.Random.Range(0, this.varList.Count);
        toModify = this.varList[location];
        return toModify;
    }

    //need to check type of variable also olverload this function.
    //complexity (O) (Nx4)^2 aprox
    public void fillDictWalkSpeed(Variable var, float x1,float x2, float y1, float y2)
    {
        
        Variable newVar;
        String key = "";

       

        //place to save the dictionary
        saveDict();

    }


    public void saveDict()
    {

        try
        {
            FileStream writerFileStream = new FileStream("dictionary.dat", FileMode.Create, FileAccess.Write);
            this.formatter.Serialize(writerFileStream, this.VariablesDict);
            writerFileStream.Close();
        }
        catch (Exception)
        {
            Debug.Log("Unable to save dictionary");
        }
    }

    public Dictionary<string,Variable> loadDict()
    {
        Dictionary<string, Variable> Dict = new Dictionary<string, Variable>();

        try
        {
            FileStream readerFileStream = new FileStream("dictionary.dat", FileMode.Open, FileAccess.Read);
            Dict = (Dictionary<string, Variable>)formatter.Deserialize(readerFileStream);
            readerFileStream.Close();

        }
        catch (Exception)
        {
            Debug.Log("Unable to recovery dictionary");
        }

        return Dict;
    }


    
    public void updatevariables() //to have an effect in the game 
    {

      

        if (newChanges)
        {
            Debug.Log(" changes were done......");
            movement.knockbackStrength = varList[0].valueFloat;
            movement.knockBackLength = varList[1].valueFloat;
            movement.walkSpeed = varList[2].valueFloat;
            movement.knockbackTimeCount = varList[3].valueFloat;
            movement.knockFromRight = varList[4].valueBool;
            movement.desiredWalkDirection = varList[5].valueFloat;
            movement.knockbackFinished = varList[6].valueBool;
            //jumpMovement.canDoubleJump = varList[7].valueBool;
            //floorD.isTouchingFloor = varList[8].valueBool;
            newChanges = false;
        }

    }

}


