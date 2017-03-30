using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sofrega : SearchAlgorithm {



	private List<SearchNode> openQueue = new List<SearchNode> (); 	    //stack
	private HashSet<object> closedSet = new HashSet<object> ();

	protected override void Begin () 
	{
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		problem = GameObject.Find("Map").GetComponent<Map>().GetProblem();
		openQueue.Push (start); // tudo para queue
	}
	
	protected override void Step ()
	{
		if (openQueue.Count > 0) {
			SearchNode cur_node = openQueue [0];
			openQueue.RemoveAt (0);
			closedSet.Add (cur_node.state);

			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
			} else {
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				foreach (Successor suc in sucessors) {
					if (!closedSet.Contains (suc.state)) {
						SearchNode new_node;
						if (heuristica == 1) {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.HeuristicObjectivos (suc.state), suc.action, cur_node);
						} else if (heuristica == 2) {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.HeuristicBoxDistObjective (suc.state), suc.action, cur_node);
						} else if (heuristica == 3) {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.HeuristicBoxGoalManhattan (suc.state), suc.action, cur_node);
						} else if (heuristica == 4) {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.HeuristicCharToCrate (suc.state), suc.action, cur_node);
						} else if (heuristica == 5) {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.Heurística5 (suc.state), suc.action, cur_node);
						} else {
							new_node = new SearchNode (suc.state, cur_node.g + suc.cost, problem.GetGoals (suc.state), suc.action, cur_node);
						}
						openQueue.Add (new_node);
					}
				}
			}
		} else {
			finished = true;
			running = false;
		}
	}
}//class