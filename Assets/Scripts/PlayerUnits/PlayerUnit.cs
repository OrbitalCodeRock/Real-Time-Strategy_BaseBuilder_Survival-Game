using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{

    // Skill Levels
    public int miningLvl;
    public int woodcuttingLvl;

    // Weapon Proficencies
    public int spearLvl;
    public int swordLvl;


    // Unit State Machine
    private UnitBaseState _currentState;
    private P_UnitStateFactory _states;
    public UnitBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    void Awake(){
        _states = new P_UnitStateFactory(this);
        _currentState = _states.Standby();
        _currentState.EnterState();
    }
    
     // Update is called once per frame
    void Update()
    {
        _currentState.CallUpdateStates();        
    }

    private void FixedUpdate()
    {
        _currentState.CallFixedUpdateStates();
    }

    public void IssueCommand(){
        _currentState.CalculateAction();
    }

}
