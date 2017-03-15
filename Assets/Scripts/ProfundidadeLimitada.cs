using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProfundidadeLimitada : SearchAlgorithm {

	private Stack<SearchNode> openStack = new Stack<SearchNode> (); 		//stack 
	//private Queue<SearchNode> openQueue = new Queue<SearchNode> (); 		//queue
	private HashSet<object> closedSet = new HashSet<object> ();
	private int limitDepth = 10; // Limite da pesquisa em profundidade




	protected override void Begin () 
	{
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openStack.Push(start);
		//openQueue.Enqueue (start);
	}

	protected override void Step()
	{
		if (openStack.Count > 0) // queueu changed to stack
		{
			SearchNode cur_node = openStack.Pop(); // Stack Pop 
			//SearchNode cur_node = openQueue.Dequeue(); // Pop Queue
			closedSet.Add (cur_node.state); //adds the currente node to the stack

			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
			} else if ( cur_node.depth <= limitDepth){
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);



					foreach (Successor suc in sucessors) {
						if (!closedSet.Contains (suc.state)) {
							SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.f, suc.cost + cur_node.g, suc.action, cur_node);

							openStack.Push (new_node); //Pushes the node to the Stack
							//openQueue.Enqueue (new_node); // Push Queue

						} else {
							finished = true;
							running = false;
						}
					}
				}
			}
		}
	}
}

// Foi mudado o Queueu para Stack, pois queu é firstin first out.
// While Stack is last in, first out



