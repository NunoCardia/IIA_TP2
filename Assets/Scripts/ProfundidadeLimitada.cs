using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProfundidadeLimitada : SearchAlgorithm
{

	private Stack<SearchNode> openStack = new Stack<SearchNode> (); 	    //stack
	//private Queue<SearchNode> openQueue = new Queue<SearchNode> (); 		//queue
	private HashSet<object> closedSet = new HashSet<object> ();

	// Limite da pesquisa em profundidade

	public int limite;




	protected override void Begin ()
	{ 
		//problem = GameObject.Find ("Map").GetComponent<Map>().GetProblem(); // não precisa de buscar problema, ja esta implementado
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openStack.Push (start);
		//openQueue.Enqueue (start);
	}

	protected override void Step ()
	{
		if (openStack.Count > 0) { // queueu changed to stack
			SearchNode cur_node = openStack.Pop (); // Stack Pop 
			//SearchNode cur_node = openQueue.Dequeue(); // Pop Queue
			closedSet.Add (cur_node.state); //adds the currente node to the stack

			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
			} else if (cur_node.depth < limite) {   // define um limite 
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);



				foreach (Successor suc in sucessors) {
					// precisa saber o estado e a profundidade a que se encontra
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node); // cur_node.f deleted 

						openStack.Push (new_node); //Pushes the node to the Stack
						//openQueue.Enqueue (new_node); // Push Queue

				}
			}

		
		} else {         
			finished = true;
			running = false;
		}
	
	}
}

// Foi mudado o Queueu para Stack, pois queu é firstin first out.
// While Stack is last in, first out

// o else para devolver o boolean "finished = true" teve que ser movido para fora do ciclo 



