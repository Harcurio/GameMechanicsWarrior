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

    List<Variable> currentList = new List<Variable>();
    Variable variableModified;
    List<Variable> neighbourList = new List<Variable>();
    //Variable current;


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
        Rules generatedRule;
        walkMovement =  new NewBehaviourScript(wm, jumpMovement, floorDetector);

        //float velocity = 650f;



        //Debug.Log("speed of the variable");
        //Debug.Log(walkMovement.movement.walkSpeed);



        //Debug.Log("list of variables");


        generatedRule = walkMovement.theRules.getRandomRule(walkMovement.varList,650,651,3,9); // here need to catch the new rules

        if (generatedRule.used)
        {
            Debug.Log(generatedRule.name);
            Debug.Log(generatedRule.comparator);
            Debug.Log(generatedRule.valueComparator);
            Debug.Log(generatedRule.effect);
            Debug.Log(generatedRule.valueEffect);
        }

        walkMovement.theRules.getNeighbors(generatedRule);

        /*
        //walkMovement.newChanges = true; // to make the changes  on the game
        //Variable current = currentList[walkMovement.theRules.variablePlace];
        Variable output = currentList[walkMovement.theRules.variablePlace];
        //Debug.Log(output.nameVariable);


        if (Object.Equals(output,"null"))
        {
            Debug.Log("why is null?");
        }
        //Variable noise = null;

        output = SearchBased(currentList);
        //Debug.Log(output.nameVariable);

        Debug.Log("rules updated quantity");
        //Debug.Log(newListVartoUpdate.Count);
        


        jumpMovement = GetComponent<JumpMovement>();
        attackMovement = GetComponent<AttackMovement>();
        floorDetector = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();
        dashMovement = GetComponent<DashMovement>();
        CharacterControlDisabled = false;

        */
        // las regl as se generan antes del update dado que en el update se deben mantener los valores..
        // la segunda fase sera hacer todo con el update
    }

    public Variable SearchBased(List<Variable> varList )
    {

        Variable current = varList[walkMovement.theRules.variablePlace];
        Variable oldcurrent = null;
        //neighbourList = walkMovement.theRules.getNeighbors(current, walkMovement.varList);  //walkMovement.theRules.getNeighbors(walkMovement.varList[walkMovement.theRules.variablePlace], walkMovement.varList); //revisar las listas de walkmovement y validar que fue utilizada getRandom


        //printList(neighbourList); Debug.Log("END neighborList"+ neighbourList.Count);

        Debug.Log(current.nameVariable);
        Debug.Log(current.valueFloat);
        int count = 0;
        bool flag = true;
        do
        {


            

            //Debug.Log("after neighbors " + current.valueFloat);
            Debug.Log("neighbours quantity");
            Debug.Log(neighbourList.Count);
            for (int i = 0; i < neighbourList.Count; i++)
            {

                Debug.Log("Fitness neighbor: "+ fitness(neighbourList[i]));
                Debug.Log("Fitness Current"+ fitness(current));
                if (fitness(neighbourList[i]) > fitness(current))
                {
                    Debug.Log("entro a la fitness");
                    oldcurrent = current;
                    current = neighbourList[i];
                }


            }

            if (Object.Equals(current, oldcurrent)) //it was is doing the null from Unity here.... 
            {
                flag = false;
            }

            Debug.Log(current.valueFloat + "_THIS IS THE VALUE to SEND ");
            //neighbourList = walkMovement.theRules.getNeighbors(current, neighbourList);

            if (count == 2)
            {
                flag = false;
                Debug.Log("out for time");
            }

            count += 1;
        } while (flag);

        Debug.Log("counter");
        Debug.Log(count);
        return current;
    }

    

    public int fitness(Variable x)
    {
        int value = 0;

        if (x.nameVariable == "walkSpeed")
        {
            value += 1;
        }

        if (x.valueInt > 50)
        {
            value += 1;
        }

        if (x.valueFloat > 1300)
        {
            value += 1;
        }

        if (x.valueFloat < 2500)
        {
            value += 1;
        }

        return value;
    }

    public void printList(List<Variable> varList)
    {
        for (int i = 0; i < varList.Count; i++)
        {
            Debug.Log(varList[i].valueFloat);
        }
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
