using System.Collections; 
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine;

[RequireComponent(typeof(JumpMovement))]
[RequireComponent(typeof(AttackMovement))]

[RequireComponent(typeof(AttackTrigger))]
[RequireComponent(typeof(CatchEdgeMovement))]
[RequireComponent(typeof(DashMovement))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(HurtEnemyOnContact))]
[RequireComponent(typeof(HurtPlayerOnContact))]
[RequireComponent(typeof(KnockbackOnContact))]
[RequireComponent(typeof(LifeManager))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(RotateToAliginWithFloor))]


[RequireComponent(typeof(NewRules))]
[RequireComponent(typeof(Variable))]





// TESTING THIS AS WRAPPER


public class NewBehaviourScript : MonoBehaviour {


    public WalkMovement movement;
    public JumpMovement jumpMovement;
    public AttackMovement attackMovement;


    public NewRules theRules = new NewRules();
    //public Variable bar;  //this will encapsulate all the other values


    public List<Variable> varList = new List<Variable>();

    public int playerpoints { get; set; }




    protected void Awake()
    {


        movement = GetComponent<WalkMovement>();
        jumpMovement = GetComponent<JumpMovement>();
        attackMovement = GetComponent<AttackMovement>();

        //Rules made for the new behaviour?
       



    }

    public NewBehaviourScript(WalkMovement movement) {

        this.movement = movement;

        //public variables from WalkMovement
        Variable bar0 = new Variable("knockbackStrength", movement.knockbackStrength);
        Variable bar1 = new Variable("knockBackLength", movement.knockBackLength);
        Variable bar2 = new Variable("walkSpeed", movement.walkSpeed);
        Variable bar3 = new Variable("knockbackTimeCount", movement.knockbackTimeCount);
        Variable bar4 = new Variable("knockFromRight", movement.knockFromRight);
        Variable bar5 = new Variable("desiredWalkDirection", movement.desiredWalkDirection);
        Variable bar6 = new Variable("knockbackFinished", movement.knockbackFinished);
        //public variables from JumpMovement
        //Variable bar7 = new Variable("canDoubleJump", jumpMovement.canDoubleJump);
        /*
         for more changes in JumpMovement we need to use the transform Variables. given that speed jump
         or double Jump Duration are privated functions
         */
        //public variables from AttackMovement
        //Variable bar8 = new Variable("isAttacking", attackMovement.isAttacking);
        //Variable bar9 = new Variable("AttackMovementEnabled", attackMovement.AttackMovementEnabled);
        //Variable bar10 = new Variable("AttackCount", attackMovement.attackCount);
        //public variables TurnArround
        //Variable bar11 = new Variable("AttackCount", attackMovement.attackCount);




        varList.Add(bar0);
        varList.Add(bar1);
        varList.Add(bar2);
        varList.Add(bar3);
        varList.Add(bar4);
        varList.Add(bar5);
        varList.Add(bar6);


        Debug.Log("nombre de la variable: ");
        Debug.Log(varList[2].nameVariable);
        



    }










        // Use this for initialization
    void Start () {




    }
	
	// Update is called once per frame
	void Update () {




    }






    void updatevariables()
    {



    }

}



//WM = GetComponent<WalkMovement>();
/*
        Debug.Log("hello");

 Type type = typeof(WalkMovement);


 PropertyInfo[] propertyInfo = type.GetProperties();
 MethodInfo[] methodInfo = type.GetMethods();

 //Debug.Log("List of properties of the class are: ");


 foreach (PropertyInfo pInfo in propertyInfo)
 {
     Debug.Log(pInfo.Name);
     //Debug.Log(pInfo.PropertyType);
     //String x = pInfo.Name;

    // Debug.Log(pInfo.Name);

     //FieldInfo fld = typeof(JumpMovement).GetField(x);
     if (pInfo.PropertyType == typeof(bool))
     {
         Debug.Log("si entra");
         FieldInfo fld = typeof(JumpMovement).GetField(x);
         //Debug.Log(fld.GetValue(null));
     }
 }



// FieldInfo field = type.GetField("FieldName", BindingFlags.NonPublic | BindingFlags.Instance);

 Debug.Log("List of methods of the class are: ");
 foreach (MethodInfo temp in methodInfo)
 {

     Debug.Log(temp.Name);
 }



 //Debug.Log("Class: " + type.Name);
 //Debug.Log("Namespace: " + type.Namespace);

*/
