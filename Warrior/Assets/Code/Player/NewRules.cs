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

    public Condition con = new Condition();
    public Effect eff = new Effect();




    public Variable changeWalkSpeed(Variable var, float actualSpeed, float value)
    {
        Variable newVar = var;
        if (con.applyCondition(var.valueFloat, Condition.conditions.lessThan, value))
        {
            newVar.valueFloat = eff.applyEffect(var.valueFloat,NewRules.Effect.effects.divide,4.0f );
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

    public Condition.conditions randomCondtion()
    {
        System.Array A = System.Enum.GetValues(typeof(Condition.conditions));
        Condition.conditions x = (Condition.conditions)A.GetValue(Random.Range(0, 3));
        return x;
    }

    public Condition.conditions randomCondtionBool()
    {
        System.Array A = System.Enum.GetValues(typeof(Condition.conditions));
        Condition.conditions x = (Condition.conditions)A.GetValue(Random.Range(3, 5));
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




    public class Condition {

        public int numberOfConditions = 5;
        public int conditionsNumbers = 3;
        
        /*we will start with the conditions made for numbers and at the end made for bools*/


        public enum conditions
        {
            biggerThan,
            lessThan,
            equalThan,
            isTrue,
            isFalse,
            COUNT
        }

        

        public bool applyCondition(int var1, conditions x, int var2)
        {
            switch ((int)x)
            {
                case 0:
                    if (var1 > var2)
                        return true;
                    break;
                case 1:
                    if (var1 < var2)
                        return true;
                    break;
                case 2:
                    if (var1 == var2)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        public bool applyCondition(float var1, conditions x, float var2)
        {
            switch ((int)x)
            {
                case 0:
                    if (var1 > var2)
                        return true;
                    break;
                case 1:
                    if (var1 < var2)
                        return true;
                    break;
                case 2:
                    if (var1 == var2)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        public bool applyCondition(bool var1, conditions x)
        {
            switch ((int)x)
            {
                case 3:
                    if (var1)
                        return true;
                    break;
                case 4:
                    if (!var1)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

    }




    public class Effect
    {
        public enum effects
        {
            add,
            subtract,
            multiply,
            divide,
            residue,
            change
        }

        public int applyEffect(int var, effects x, int quantity )
        {
            switch ((int)x)
            {
                case 0:
                    return var + quantity;
                case 1:
                    return var - quantity;
                case 2:
                    return var * quantity;
                case 3:
                    if (quantity == 0)
                        return -1;
                    return var / quantity;
                case 4:
                    return var % quantity;
                default:
                    break;
            }
            return -1;
        }

        public float applyEffect(float var, effects x, float quantity)
        {
            switch ((int)x)
            {
                case 0:
                    return (float)(var + quantity);
                case 1:
                    return (float)(var - quantity);
                case 2:
                    return (float)(var * quantity);
                case 3:
                    if (quantity == 0)
                        return -1;
                    return (float)(var / quantity);
                case 4:
                    return (float)(var % quantity);
                default:
                    break;
            }
            return -1;
        }

        public bool applyEffect(bool var, effects x)
        {
            if ((int)x == 5)
            {
                if (var)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }





    }
}








