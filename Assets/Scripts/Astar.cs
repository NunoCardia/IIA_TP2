  using UnityEngine;
  using System.Collections;
  using System.Collections.Generic;
  
  public class Astar : SearchAlgorithm
  {
  
	  private List<SearchNode> queue = new List<SearchNode>(); 	   
  	  //private Queue<SearchNode> openQueue = new Queue<SearchNode> (); 		
      //private HashSet<object> openSet = new HashSet<object> ();     // open set & close set 
      private HashSet<object> closedSet = new HashSet<object> ();
	  private int heuristica;
  	   //Limite da pesquisa em profundidade
  
  
  
  
  	protected override void Begin ()
  	{ 
  		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		problem = GameObject.Find("Map").GetComponent<Map>().GetProblem();
		queue.Add (start);
  	   // openQueue.Enqueue (start);
  	   // openSet.Add (start.state);   // Define o Set
  	}
  
  	protected override void Step ()
  	{
  		
  
  	}
  }
  
     //  Foi mudado o Queueu para Stack, pois queu é firstin first out.
     //   While Stack is last in, first out
  
     // o else para devolver o boolean "finished = true" teve que ser movido para fora do ciclo 
  
  
  
  
