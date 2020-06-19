namespace TopologicalSortOfBiryaniRecipe
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            /*****Setup input for program*******/
            List<StepNode> InputGraph = new List<StepNode>()
            {
                new StepNode("Buy Ingredients"),
                new StepNode("Soak Rice"),
                new StepNode("Prepare Layering"),
                new StepNode("Marinate Chicken"),
                new StepNode("Cook Chicken"),
                new StepNode("Cook Rice"),
                new StepNode("Add Layering"),
                new StepNode("Add Rice"),
                new StepNode("Serve")
            };

            InputGraph[0].NextSteps.AddRange(new List<StepNode>() { InputGraph[1], InputGraph[2], InputGraph[3]});
            InputGraph[1].NextSteps.AddRange(new List<StepNode>() { InputGraph[5] });
            InputGraph[2].NextSteps.AddRange(new List<StepNode>() { InputGraph[6] });
            InputGraph[3].NextSteps.AddRange(new List<StepNode>() { InputGraph[4] });
            InputGraph[4].NextSteps.AddRange(new List<StepNode>() { InputGraph[6] });
            InputGraph[5].NextSteps.AddRange(new List<StepNode>() { InputGraph[7] });
            InputGraph[6].NextSteps.AddRange(new List<StepNode>() { InputGraph[7] });
            InputGraph[7].NextSteps.AddRange(new List<StepNode>() { InputGraph[8] });

            /*****Calculate in-degree of each node*******/
            foreach (var item in InputGraph)
            {
                item.SetInitialIndegreeForNextStep();   
            }

            /*****Run the topological sort algorithm*******/
            var result = TopologicalSortHelper.TopologicalSort(InputGraph);

            Console.WriteLine("*********Result********");

            if(result != null)
            {
                int stepNumber = 1;
                foreach (var item in result)
                {
                    Console.WriteLine($"Step {stepNumber}: {item.GetDescription()}");
                    stepNumber++;
                }
            }
            else
            {
                Console.WriteLine("The input graph is not a directed acyclic graph!!");
            }
        }
    }
}
