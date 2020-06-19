namespace TopologicalSortOfBiryaniRecipe
{
    using System;
    using System.Collections.Generic;

    public static class TopologicalSortHelper
    {
        public static List<StepNode> TopologicalSort(List<StepNode> inputGraph)
        {
            /*****Initialize storage needed for calculations*******/
            Queue<StepNode> ProcessingQueue = new Queue<StepNode>();
            List<StepNode> Result = new List<StepNode>();

            /*********************************************************
            Find a node to start with, i.e. a node with in-degree zero. 
            If multiple such nodes found or no node found, it means the graph is not DAG
            and it won't have valid topological ordering.
            ***************************************************************/
            var firstStep = inputGraph.FindAll(x => x.GetInDegree() == 0);
            if(firstStep == null || firstStep.Count != 1)
                return null;

            /***Begin the processing from first step***/
            ProcessingQueue.Enqueue(firstStep[0]);
            Console.WriteLine($"Enqueued first node - {firstStep[0].GetDescription()}");
            while(ProcessingQueue.Count > 0)
            {
                /*************************************************************
                At each step, a node will be removed from processing queue, and added
                to result
                Its edges will be removed from graph by decrementing in-degree
                of its neighbours.
                *************************************************************/
                var current = ProcessingQueue.Dequeue();
                Console.WriteLine($"Dequeued node - {current.GetDescription()}, adding to result.");
                foreach(var nextStep in current.NextSteps)
                {
                    nextStep.DecrementInDegree();

                    if(nextStep.GetInDegree() == 0)
                    {
                        ProcessingQueue.Enqueue(nextStep);
                        Console.WriteLine($"Enqueued node - {nextStep.GetDescription()}");
                    }
                }

                Result.Add(current);
            }
            /************************************************************
            If queue is empty but still there are nodes present in graph(i.e. nodes
            with in-degree > 0), it indicates that there is a cycle.
            ************************************************************/
            var remainingNode = inputGraph.Find(x => x.GetInDegree() != 0);

            if(remainingNode != null)
                return null;
                
            return Result;
        }       
    }
}