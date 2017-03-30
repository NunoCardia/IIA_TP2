using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class aproProgre : SearchAlgorithm
{

	private Stack<SearchNode> openStack = new Stack<SearchNode> (); 	    //stack
//	private Stack<SearchNode> closedStack = new Stack<SearchNode> (); 

//	private HashSet<object> openSet = new HashSet<object> ();
	private HashSet<object> closedSet = new HashSet<object> ();

	// boolean para o ciclo infnito 
	private int prof = 0;
	private SearchNode start;



	protected override void Begin ()
	{ 
		start = new SearchNode (problem.GetStartState (), 0);
		openStack.Push (start); // tudo para queue
		problem = GameObject.Find("Map").GetComponent<Map>().GetProblem();
	}

	protected override void Step ()
	{
		if (openStack.Count > 0) { // while, para ser continuo 
			SearchNode cur_node = openStack.Pop (); 
			closedSet.Add (cur_node.state); 

			if (problem.IsGoal (cur_node.state)) { // infinito
				solution = cur_node;
				finished = true;
				running = false;

			} else {   // infinito
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				if (cur_node.depth < prof) {
					foreach (Successor suc in sucessors) {
						if (!closedSet.Contains (suc.state)) { // modificar
							SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node); // cur_node.f deleted 

							openStack.Push (new_node); //Pushes the node to the Stack
						}
					}
				}
			}
		} else {
			prof++;
			openStack.Clear (); //clear do stack
			closedSet.Clear ();
			openStack.Push (start);
		}
	}
}//class



