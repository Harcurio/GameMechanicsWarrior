﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//[RequireComponent(typeof(Conditions))]
[RequireComponent(typeof(Variable))]



public class NewRules : MonoBehaviour {


    //Conditions condition;
    Variable var;

    // LISTA DE VARIABLES
    public List<Variable> varList = new List<Variable>();

    public Conditions condition;



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

        int rd = Random.Range(0, varList.Count -1);
        float rdm;
        toModify = varList[2];  // vamos a hardcodear esto para probar con movimiento rd seria el defauld
        // se modifica una de esas variables  verificando sus condiciones.
        rd = Random.Range(0,100);
        rdm = Random.Range(0f, 100f);
        if (toModify.isINT())
        {

            if(theCondition.leesThan(toModify.valueInt, rd))
            {
                toModify.valueInt = 325;

                //more than 1 modifications?

                // se hace update a la lista 
                NewVar[2] = toModify;
            }

        }

        if (toModify.isFLOAT())
        {
          
            if (theCondition.leesThan(rdm, toModify.valueFloat)) // esta entrando siempre... por que random menor a valores
            {
                toModify.valueFloat = 30f;

                //more than 1 modifications?

                // se hace update a la lista 
                NewVar[2] = toModify;
            }

        }

        if (toModify.isBOOL())
        {

        }


        //Debug.Log(NewVar[2].valueFloat);
        return NewVar;
    }


    void getNeighbors()
    {
        // como defino los vecinos? misma clase?
    }







    public class Conditions
    {

        Variable x;
        public bool leesThan(float a, float b) //this is as an example right now...
        {
            if (a < b)
            {
                return true;
            }
            return false;
        }

        public bool leesThan(Variable a, Variable b)
        {

            if (a.isINT() && b.isINT())
            {
                if (a.valueInt < b.valueInt)
                {
                    return true;
                }


            }
            else if (a.isFLOAT() && b.isFLOAT())
            {
                if(a.valueFloat < b.valueFloat)
                {
                    return true;
                }


            }
            else if (a.isBOOL() && b.isBOOL())
            {




            }//we can add more comparisons here 

            return false;
        }


        public bool bigerThan(Variable a, Variable b)
        {

            if (a.isINT() && b.isINT())
            {
                if (a.valueInt > b.valueInt)
                {
                    return true;
                }


            }
            else if (a.isFLOAT() && b.isFLOAT())
            {
                if (a.valueFloat > b.valueFloat)
                {
                    return true;
                }


            }
            else if (a.isBOOL() && b.isBOOL())
            {




            }//we can add more comparisons here 

            return false;

        }



        public bool equalThan(Variable a, Variable b)
        {

            if (a.isINT() && b.isINT())
            {
                if (a.valueInt == b.valueInt)
                {
                    return true;
                }


            }
            else if (a.isFLOAT() && b.isFLOAT())
            {
                if (a.valueFloat == b.valueFloat)
                {
                    return true;
                }


            }
            else if (a.isBOOL() && b.isBOOL())
            {

                //direct change here.


            }//we can add more comparisons here 

            return false;
        }

        public bool equalToFalse()
        {

            return true;
        }

        public bool equalToTrue()
        {

            return true;
        }

        public bool isActive()
        {

            return true;
        }


        /* que es lo importante en condicion? revisar que una tecla se active o que el valor
         * de una variable sea mayor o menor que su previo valor?
         * 
         * por ejemplo podemos generar una regla y ejecutarla cada que precionamos un boton 
         * pero esta regla sólo sería temporal, dado que no se guardaría la regla para un uso futuro.
         * 
         * dado que tenemos que generar reglas manualmente cómo apolicamos  las condiciones??}
         * 
         * creo que en condiciones aun hay dudas hay que ver el video nuevamente para ver cómo se aplicaria
         * aunque creo que no fue discutido en la junta.
         * 
         * tengo que pensar en cómo aplicar la condicion...

         */


    }

    public class Effect
    {

        public int addingValue()
        {
                //call variable inside in the future
            return 1;
        }

        public int restValue()
        {

            return -1;
        }

        public int doubleValue()
        {
            return 2;
        }


        public float addingValueF()
        {

            return 0.5f;
        }

        public float restValueF()
        {

            return -0.5f;
        }




    }



}



