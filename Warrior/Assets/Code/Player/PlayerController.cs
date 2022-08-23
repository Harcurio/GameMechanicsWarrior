using UnityEngine;
using System.Collections.Generic;
using System.Collections;


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
    WalkMovement trueWalkMovement;

    List<Variable> currentList = new List<Variable>();
    Variable variableModified;
    List<Rules> neighbourList = new List<Rules>();
    //Variable current;


    public bool CharacterControlDisabled { get; set; }

    Conditions con = new Conditions();

    [SerializeField]
    public float jumpSpeed = 7f;

    [SerializeField]
    private float secondJumpSpeed = 10f;

    [SerializeField]
    private float doubleJumpDuration = 0.5f;

    public bool canDoubleJump { get; private set; }


    CrouchMovement crouchMovement;
    Physics2D gravity;
    AudioManager audioManager;
    Animator animator;

    private int jumps = 0;

    public bool lft = false;
    public bool rgt = false;
    public bool spc = false;



    protected void Awake()
    {
        float speed = 650f;
        wm = GetComponent<WalkMovement>();
        jumpMovement = GetComponent<JumpMovement>();
        floorDetector = GetComponent<FloorDetector>();
        trueWalkMovement = GetComponent<WalkMovement>();
        crouchMovement = GetComponent<CrouchMovement>();
        audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        //walkMovement = GetComponent<NewBehaviourScript>();
        wm.walkSpeed = speed;
        Rules generatedRule;
        walkMovement = new NewBehaviourScript(wm, jumpMovement, floorDetector);

        //float velocity = 650f;



        //Debug.Log("speed of the variable");
        //Debug.Log(walkMovement.movement.walkSpeed);



        //Debug.Log("list of variables");


        generatedRule = walkMovement.theRules.getRandomRule(walkMovement.varList, 650, 651, 3, 9); // here need to catch the new rules

        if (generatedRule.used)
        {
            Debug.Log(generatedRule.name);
            Debug.Log(generatedRule.comparator);
            Debug.Log(generatedRule.valueComparator);
            Debug.Log(generatedRule.effect);
            Debug.Log(generatedRule.valueEffect);
        }

        //walkMovement.theRules.getNeighbors(generatedRule);


        Rules output = SearchBased(generatedRule);



        Debug.Log("rules updated quantity");




        jumpMovement = GetComponent<JumpMovement>();
        attackMovement = GetComponent<AttackMovement>();
        floorDetector = GetComponent<FloorDetector>();
        myBody = GetComponent<Rigidbody2D>();
        dashMovement = GetComponent<DashMovement>();
        CharacterControlDisabled = false;


        // las regl as se generan antes del update dado que en el update se deben mantener los valores..
        // la segunda fase sera hacer todo con el update
    }

    public Rules SearchBased(Rules current)
    {

        //Variable current = varList[walkMovement.theRules.variablePlace];
        Rules oldcurrent = null;
        neighbourList = walkMovement.theRules.getNeighbors(current);
        Debug.Log("neighbours quantity");
        Debug.Log(neighbourList.Count);

        //printList(neighbourList); Debug.Log("END neighborList"+ neighbourList.Count);

        int count = 0;
        bool flag = true;
        do
        {

            //Debug.Log("after neighbors " + current.valueFloat);

            for (int i = 0; i < neighbourList.Count; i++)
            {


                if (fitness(neighbourList[i]) > fitness(current))
                {
                    Debug.Log("inside fitness");
                    oldcurrent = current;
                    current = neighbourList[i];
                }


            }

            if (current == oldcurrent) //it was is doing the null from Unity here.... 
            {
                Debug.Log("Found the rule!!");
                flag = false;
            }

            neighbourList = walkMovement.theRules.getNeighbors(current);

            if (count == 40)
            {
                flag = false;
                Debug.Log("out for time");
            }

            count += 1;
        } while (flag);

        printList(neighbourList);

        Debug.Log("counter");
        Debug.Log(count);

        Debug.Log(current.name);
        Debug.Log(current.comparator);
        Debug.Log(current.valueComparator);
        Debug.Log(current.effect);
        Debug.Log(current.valueEffect);

        return current;
    }



    public int fitness(Rules x)
    {
        int value = 0;

        if (x.name == "walkSpeed")
        {
            value += 1;
        }

        if (x.comparator == "lessThan")
        {
            value += 1;
        }

        if (x.valueComparator == "651")
        {
            value += 1;
        }

        if (x.effect == "multiply")
        {
            value += 1;
        }
        float valueComparator = float.Parse(x.valueEffect);
        if (valueComparator < 10f)
        {
            value -= 3;
        }
        if (valueComparator > 5f)
        {
            value += 5;
        }
        if (valueComparator > 8f)
        {
            value += 2;
        }
        if (valueComparator > 9f)
        {
            value += 2;
        }


        return value;
    }

    public void printList(List<Rules> varList)
    {
        for (int i = 0; i < varList.Count; i++)
        {
            Debug.Log(varList[i].name + " " + varList[i].comparator + " " + varList[i].valueComparator + " " + varList[i].effect + " " + varList[i].valueEffect);
        }
        Debug.Log("endGetNeigbors List");
    }

    public bool randomBot()
    {

        int randomNumber = Random.Range(0, 10);

        if (randomNumber < 5)
        {
            return true;
        }

        return false;
    }

    protected void Update()
    {
        lft = randomBot();
        rgt = randomBot();
        spc = randomBot();

        

        if ((Input.GetKey(KeyCode.LeftControl) && floorDetector.isTouchingFloor) || (CharacterControlDisabled && floorDetector.isTouchingFloor) )
        {

            trueWalkMovement.desiredWalkDirection = 0;


        }




        if (lft  && !CharacterControlDisabled)
        {

            trueWalkMovement.desiredWalkDirection = -1;



        }
        else if (lft == false)
        {

            trueWalkMovement.desiredWalkDirection = 0;



        }

        if (rgt && !CharacterControlDisabled)
        {

            trueWalkMovement.desiredWalkDirection = -1;



        }
        else if ( rgt == false)
        {

            trueWalkMovement.desiredWalkDirection = 0;



        }
        if (spc && floorDetector.isTouchingFloor && !crouchMovement.isCrouching && !CharacterControlDisabled)
        {
            Jump(jumpSpeed);
            canDoubleJump = true;
            return;
        }



        if ((Input.GetButton("Left") && !Input.GetKey(KeyCode.LeftControl)) && !CharacterControlDisabled)
        {

            trueWalkMovement.desiredWalkDirection = Input.GetAxis("Left");



        }
        else if(Input.GetButtonUp("Left") )
        {

            trueWalkMovement.desiredWalkDirection = 0;



        }

        if ((Input.GetButton("Right") && !Input.GetKey(KeyCode.LeftControl)) && !CharacterControlDisabled)
        {

            trueWalkMovement.desiredWalkDirection = Input.GetAxis("Right");



        }
        else if (Input.GetButtonUp("Right"))
        {

            trueWalkMovement.desiredWalkDirection = 0;



        }

        /*if (Input.GetButtonDown("Attack") && !CharacterControlEnabled)
        {
            attackMovement.attackRequest = true;
        }*/

        if(Input.GetKeyDown(KeyCode.D) && floorDetector.isTouchingFloor && !CharacterControlDisabled)
        {
            dashMovement.dash = true;
        }

        if (Input.GetButtonDown("Jump") && floorDetector.isTouchingFloor
            && !crouchMovement.isCrouching && !CharacterControlDisabled)
        {
            Jump(jumpSpeed);
            canDoubleJump = true;
            return;
        }

        if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            animator.SetBool("Double_Jump", true);
            StartCoroutine(DoubleJumpDuration());

            if (myBody.velocity.y > 0)
            {
                Jump(secondJumpSpeed);
            }

            if (myBody.velocity.y < 0)
            {
                Jump(secondJumpSpeed * 3.3f);
            }
            canDoubleJump = false;
        }
    }

    protected void LateUpdate()
    {
        if (floorDetector.isTouchingFloor)
        {
            canDoubleJump = false;
        }
    }
    public void Jump(float speed)
    {
        audioManager.playerJump[Random.Range(0, 4)].Play();
        myBody.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
    }

    IEnumerator DoubleJumpDuration()
    {
        yield return new WaitForSeconds(doubleJumpDuration);
        animator.SetBool("Double_Jump", false);
    }
}
