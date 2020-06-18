namespace TopologicalSortOfBiryaniRecipe
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<StepNode> InputGraph = new List<StepNode>()
            {
                new StepNode("Buy Ingredients", "BI"),
                new StepNode("Soak Rice", "SR"),
                new StepNode("Marinate Chicken", "MC"),
                new StepNode("Prepare Layering", "PL"),
                new StepNode("Cook Chicken", "CCH"),
                new StepNode("Cook Rice", "CRC"),
                new StepNode("Add Layering", "AL"),
                new StepNode("Add Rice", "AR"),
                new StepNode("Serve", "SV")
            };

            InputGraph[0].NextSteps.AddRange(new List<StepNode>() { InputGraph[1], InputGraph[2], InputGraph[3]});
            InputGraph[1].NextSteps.AddRange(new List<StepNode>() { InputGraph[5] });
            InputGraph[2].NextSteps.AddRange(new List<StepNode>() { InputGraph[4] });
            InputGraph[3].NextSteps.AddRange(new List<StepNode>() { InputGraph[6] });
            InputGraph[4].NextSteps.AddRange(new List<StepNode>() { InputGraph[6] });
            InputGraph[5].NextSteps.AddRange(new List<StepNode>() { InputGraph[7] });
            InputGraph[6].NextSteps.AddRange(new List<StepNode>() { InputGraph[7] });
            InputGraph[7].NextSteps.AddRange(new List<StepNode>() { InputGraph[8] });

            foreach (var item in InputGraph)
            {
                item.SetInitialIndegreeForNextStep();   
            }
            foreach (var item in InputGraph)
            {
                Console.WriteLine($"Step: {item.GetDescription()} -> ");
                foreach (var nextStep in item.NextSteps)
                {
                    Console.Write($"{nextStep.GetDescription()} ");      
                }
                Console.WriteLine($"Indegree: {item.GetInDegree()}");
            }

            TopologicalSort(InputGraph);
        }

        static void TopologicalSort(List<StepNode> inputGraph)
        {
            List<StepNode> ProcessingQueue = new List<StepNode>();
            List<StepNode> Result = new List<StepNode>();

            

        }
    }
}
