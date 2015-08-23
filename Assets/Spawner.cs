using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public Field field;
	public uint numPrey = 5;
	public uint numRobots = 4;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < numRobots; i++)
		{
			GameObject robot = new GameObject();
			robot.AddComponent<Robot>();
		}

		for (int i = 0; i < numPrey; i++)
		{
			GameObject robot = new GameObject();
			robot.AddComponent<Prey>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
