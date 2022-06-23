﻿using System.Collections;
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
    public int variablePlace;
    public string key;
    public bool randomGenerated = false;
     

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

    
    
    public List<Variable> getNeighbors(List<Variable> varlist,  string key)
    {
        List<Variable> newVar = varlist;
        Variable toNeighbor = varlist[this.variablePlace];
        if (this.randomGenerated)
        {
            
            string[] words = key.Split('-');
            //toModify.nameVariable + "-" + c +"-"+ ran +"-" + e + "-" + ran2 + "-";
            Conditions.conditions cUsed = getConditionUsed(words[1]);
            Effect.effects eUsed = getEffectUsed(words[4]);
            

            if (toNeighbor.isINT())
            {
                if (con.applyCondition(toNeighbor.valueInt, cUsed, Random.Range(x1, x2)))
                {
                    Debug.Log("Variable modified was Int");
                    toNeighbor.valueInt = eff.applyEffect(toNeighbor.valueInt, randomEffect(), Random.Range(y1, y2));
                    //PRINT KEY to see what was modified
                }
            }
        
            if (toNeighbor.isFLOAT())
            {
                if (con.applyCondition(toNeighbor.valueInt, randomCondtion(), Random.Range(x1, x2)))
                {
                    Debug.Log("Variable modified was Float");
                    toNeighbor.valueFloat = eff.applyEffect(toNeighbor.valueInt, randomEffect(), Random.Range(y1, y2));
                    //PRINT KEY to see what was modified
                }
            }

        }

        newVar[this.variablePlace] = toNeighbor;


        return newVar;
    }
        

    public List<Variable> getRandomRule(List<Variable> varList, int x1, int x2, int y1, int y2)
    {
        List<Variable> newVar = varList;
        Variable toModify;
        
        Conditions.conditions c = randomCondtion();
        Effect.effects e = randomEffect();

        Random rd = new Random();
        int location = Random.Range(0, varList.Count);
        this.variablePlace = location;
        this.key = "";
        this.randomGenerated = true;
        toModify = newVar[location];
        Debug.Log(toModify.nameVariable);

        int ran, ran2;

        if (toModify.isINT())
        {
            ran = Random.Range(x1, x2);
            if (con.applyCondition(toModify.valueInt,c,ran))
            {
                Debug.Log("Variable modified was Int");
                ran2 = Random.Range(y1, y2);
                toModify.valueInt  = eff.applyEffect(toModify.valueInt,e,ran2);
                this.key = this.key + toModify.nameVariable + "-" + c +"-"+ ran +"-" + e + "-" + ran2 + "-";
                Debug.Log(this.key);

            }
        }

        if (toModify.isFLOAT())
        {
            ran = Random.Range(x1, x2);
            if (con.applyCondition(toModify.valueInt, c, ran))
            {
                ran2 = Random.Range(y1, y2);
                Debug.Log("Variable modified was Float");
                toModify.valueFloat = eff.applyEffect(toModify.valueInt, e, ran2);
                this.key = this.key + toModify.nameVariable + "-" + c + "-" + ran + "-" + e + "-" + ran2 + "-";
                Debug.Log(this.key);
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

    public Conditions.conditions getConditionUsed(string cond)
    {
        switch (cond)
        {
            case "biggerThan":
                return Conditions.conditions.lessThan;
            case "lessThan":
                return Conditions.conditions.biggerThan;
            case "equalThan":
                return Conditions.conditions.equalThan;
            default:
                return Conditions.conditions.COUNT;
        }

    }

    public Effect.effects getEffectUsed(string cond)
    {
        switch (cond)
        {
            case "add":
                return Effect.effects.add;
            case "subtract":
                return Effect.effects.subtract;
            case "multiply":
                return Effect.effects.multiply;
            case "divide":
                return Effect.effects.divide;
            case "residue":
                return Effect.effects.residue;
            default:
                return Effect.effects.change;
        }
    }





    /* we can do a function that updates all the variables inside the walk each time there is a change...*/










}








