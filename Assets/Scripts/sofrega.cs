using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sofrega : SearchAlgorithm {



	private Stack<SearchNode> openQueue = new Stack<SearchNode> (); 	    //stack
	private HashSet<object> closedSet = new HashSet<object> ();
	private bool cicloN; // boolean para o ciclo infnito 

	protected override void Begin () 
	{
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openQueue.Push (start); // tudo para queue
		cicloN = false; // começa false porque não encontrou a solução
	}
	
	protected override void Step ()
	{
		int n = 0;

		while (!cicloN) {  // Ciclo de n= 0 até infinito faz
			funcPesquisa (n);
			n++;

		}
	}

	protected void funcPesquisa(int nLimite)
	{
		openQueue.Clear(); //clear do queue
		closedSet.Clear(); // clear do set
		while (openQueue.Count > 0) { // while, para ser continuo 
			SearchNode cur_node = openQueue.Pop (); 
			closedSet.Add (cur_node.state); 

			if (problem.IsGoal (cur_node.state) && cur_node.depth <= nLimite) { // acrecentado o limite de n 
				solution = cur_node;
				finished = true;
				running = false;
				cicloN = true; // termina o ciclo de n

			} else if (cur_node.depth < nLimite) {   // define um limite "nLimite"
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				foreach (Successor suc in sucessors) {
					if (!closedSet.Contains (suc.state)) { // modificar
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node); // cur_node.f deleted 

						openQueue.Push (new_node); //Pushes the node to the Stack
					}
				}
			}
		}
		// ciclo while, logo não precisa do else
		finished = true;
		running = false;

	}
}//class