using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerBob : MonoBehaviour
{

    public float FatigueLevel { get { return fatigueLevel; } set { fatigueLevel = value; } }
    public float ThirstLevel { get { return thirstLevel; } set { thirstLevel = value; } }
    public float CurrentGold { get { return currentGold; } set { currentGold = value; } }
    public float Health { get { return health; } set { health = value; } }

    public float maxCarryNuggets = 30.0f;
	public float thirstThreshold = 50.0f;
	public float tirednessThreshold = 50.0f;
	public float health = 100;

    public float currentGold;
	public float bankAccount;
	public float thirstLevel;
	public float fatigueLevel;

	public void TakeDamage(float amount)
	{
		health -= amount * Time.deltaTime;
		if (health < 0)
		{
			health = 0;
		}
	}

	public void Sleep(float _restSpeed)
	{
		fatigueLevel += _restSpeed * Time.deltaTime;
		if (fatigueLevel <= 0.0f)
		{
			fatigueLevel = 0.0f;
		}
	}

	public void Drink(float _consumption, float _cost)
	{
		thirstLevel += _consumption * Time.deltaTime;
		currentGold -= _cost * Time.deltaTime;
	}

	public void Mine(float _amount, float _fatigue, float _thirst)
	{
		currentGold += _amount * Time.deltaTime;
		fatigueLevel += _fatigue * Time.deltaTime;
		thirstLevel += _thirst * Time.deltaTime;
	}

	public void Deposit(float _amount)
	{
		currentGold -= _amount;
		bankAccount += _amount;
	}
}
