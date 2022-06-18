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



   
    public List<Variable> getRandomRule(List<Variable> varList, int x1, int x2, int y1, int y2)
    {
        List<Variable> newVar = varList;
        Variable toModify;
        Random rd = new Random();
        int location = Random.Range(0, varList.Count);
        toModify = newVar[location];
        Debug.Log(toModify.nameVariable);

        if (toModify.isINT())
        {
            if (con.applyCondition(toModify.valueInt,randomCondtion(),Random.Range(x1,x2)))
            {
                Debug.Log("Variable modified was Int");
                toModify.valueInt  = eff.applyEffect(toModify.valueInt,randomEffect(),Random.Range(y1, y2));
                //PRINT KEY to see what was modified
            }
        }

        if (toModify.isFLOAT())
        {
            if (con.applyCondition(toModify.valueInt, randomCondtion(), Random.Range(x1, x2)))
            {
                Debug.Log("Variable modified was Float");
                toModify.valueFloat = eff.applyEffect(toModify.valueInt, randomEffect(), Random.Range(y1, y2));
                //PRINT KEY to see what was modified
            }
        }

        if (toModify.isBOOL())
        {
            //for bool if is true is gonna be false and if is false is gonna be true.
            Debug.Log("Variable modified was bool");
            toModify.valueBool = !toModify.valueBool;
              
        }

        //con.applyCondition();
        newVar[location] = toModify;
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








