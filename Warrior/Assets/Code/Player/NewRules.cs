using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//[RequireComponent(typeof(Conditions))]
[RequireComponent(typeof(Variable))]



public class NewRules
{


    //Conditions condition;
    Variable var;

    // LISTA DE VARIABLES
    public List<Variable> varList = new List<Variable>();

    public Conditions con = new Conditions();

    //public Condition con = new Condition();
    public Effect eff = new Effect();




    public Variable changeWalkSpeed(Variable var,Conditions.conditions x , float valueToCompare,Effect.effects y,float change)
    {
        Variable newVar = var;
        Debug.Log("value of the var");
        Debug.Log(newVar.valueFloat);
        if (con.applyCondition(var.valueFloat, x, valueToCompare))
        {
            newVar.valueFloat = eff.applyEffect(var.valueFloat,y,change );
        }
        return newVar;
    }




    public List<Variable> getRandomRule(List<Variable> varList)
    {
        List<Variable> newVar = varList;
        Variable toModify;
        //Random rd = new Random();
        int location = Random.Range(0, varList.Count);

        toModify = newVar[location];

        if (toModify.isINT())
        {
            //tbd the range...
            if (con.applyCondition(toModify.valueInt,randomCondtion(),Random.Range(0,10)))
            {
                toModify.valueInt  = eff.applyEffect(toModify.valueInt,randomEffect(),Random.Range(0, 10));
            }
        }

        if (toModify.isFLOAT())
        {
            //the range
            if (con.applyCondition(toModify.valueInt, randomCondtion(), Random.Range(0, 10)))
            {
                toModify.valueFloat = eff.applyEffect(toModify.valueInt, randomEffect(), Random.Range(0, 10));
            }
        }

        if (toModify.isBOOL())
        {
           // if (con.applyCondition()) { } to be determ  
        }

        //con.applyCondition();

        return newVar;
    }

    public Conditions.conditions randomCondtion()
    {
        System.Array A = System.Enum.GetValues(typeof(Conditions.conditions));
        Conditions.conditions x = (Conditions.conditions)A.GetValue(Random.Range(0, 3));
        return x;
    }

    public Conditions.conditions randomCondtionBool()
    {
        System.Array A = System.Enum.GetValues(typeof(Conditions.conditions));
        Conditions.conditions x = (Conditions.conditions)A.GetValue(Random.Range(3, 5));
        return x;
    }

    public Effect.effects randomEffect()
    {
        System.Array A = System.Enum.GetValues(typeof(Effect.effects));
        Effect.effects x = (Effect.effects)A.GetValue(Random.Range(0, 5));
        return x;
    }


    void getNeighbors()
    {
        // como defino los vecinos? misma clase?
    }



    /* we can do a function that updates all the variables inside the walk each time there is a change...*/




   




    
}








