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

    public Condition con;
    public Effect eff;



    /*
    public NewRules(List<Variable> varList)
    {

        this.varList = varList;

        //possible list with the new rules? ??


    }*/


    public List<Variable> getRandomRule(List<Variable> varList)
    {

        Variable toModify;
        List<Variable> NewVar = varList;
        Conditions theCondition = new Conditions();

        int rd = Random.Range(0, varList.Count - 1);
        float rdm;
        toModify = varList[2];  // vamos a hardcodear esto para probar con movimiento rd seria el defauld
        // se modifica una de esas variables  verificando sus condiciones.
        rd = Random.Range(0, 100);
        rdm = Random.Range(0f, 100f);
        if (toModify.isINT())
        {


            if (toModify.valueInt < rd)
            {
                toModify.valueInt = 325;

                //more than 1 modifications?

                // se hace update a la lista 
                //NewVar[2] = toModify;
            }


        }

        if (toModify.isFLOAT())
        {

            if (rdm < toModify.valueFloat) // esta entrando siempre... por que random menor a valores
            {

                toModify.valueFloat = 30f;



                //more than 1 modifications?

                // se hace update a la lista 
                // NewVar[2] = toModify;
            }

        }

        if (toModify.isBOOL())
        {

        }

        NewVar[2] = toModify;

        Debug.Log(NewVar[2].valueFloat);
        return NewVar; // I never modify the list that is returned how it will change!!!! 
    }


    void getNeighbors()
    {
        // como defino los vecinos? misma clase?
    }



    /* we can do a function that updates all the variables inside the walk each time there is a change...*/




    public class Condition {

        public int numberOfConditions = 5;


        public enum conditions
        {
            biggerThan,
            lessThan,
            equalThan,
            isTrue,
            isFalse
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








