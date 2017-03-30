//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class Astar : SearchAlgorithm
//{
//
//	//private Stack<SearchNode> openStack = new Stack<SearchNode> (); 	   
//	//private Queue<SearchNode> openQueue = new Queue<SearchNode> (); 		
//	private HashSet<object> openSet = new HashSet<object> ();  //  open set & close set 
//	private HashSet<object> closedSet = new HashSet<object> ();
//
//	// Limite da pesquisa em profundidade
//
//
//
//
//	protected override void Begin ()
//	{ 
//		SearchNode start = new SearchNode (problem.GetStartState (), 0);
//		//openStack.Push (start);
//		//openQueue.Enqueue (start);
//		openSet.Add (start.state); // Define o Set
//	}
//
//	protected override void Step ()
//	{
//		if (openSet.Count > 0) { // queueu changed to Set
//			
//				SearchNode cur_node = openSet<0>;
//
//			for (int i = 1; i < openSet<c>; i++) { // ciclo comeca em 1 
//				if (openSet<i>f.cost < cur_node.f.cost || openSet [i].f.cost == cur_node.f.cost && openSet [i].h.cost < cur_node.h + suc) {  
//					cur_node = openSet<i>; 
//				}
//			}
//				
//
//			if (problem.IsGoal (cur_node.state)) {
//				solution = cur_node;
//				finished = true;
//				running = false;
//			} else if (cur_node.depth < limite) {   // define um limite 
//				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
//
//
//
//				foreach (Successor suc in sucessors) {
//					// precisa saber o estado e a profundidade a que se encontra
//					SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node); // cur_node.f deleted 
//
//					//openStack.Push (new_node); //Pushes the node to the Stack
//					//openQueue.Enqueue (new_node); // Push Queue
//
//				}
//			}
//
//
//		} else {         
//			finished = true;
//			running = false;
//		}
//
//	}
//}
//
//// Foi mudado o Queueu para Stack, pois queu é firstin first out.
//// While Stack is last in, first out
//
//// o else para devolver o boolean "finished = true" teve que ser movido para fora do ciclo 
//
//
//
//
