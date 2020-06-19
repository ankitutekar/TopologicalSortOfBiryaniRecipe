namespace TopologicalSortOfBiryaniRecipe
{
    using System.Collections.Generic;
    public class StepNode
    {
        private string StepDescription { get; set; } 
        public List<StepNode> NextSteps { get; set; }
        private int InDegree { get; set; }

        public StepNode(string description)
        {
            StepDescription = description;
            NextSteps = new List<StepNode>();
        }

        public string GetDescription()
        {
            return StepDescription;
        }

        public int GetInDegree()
        {
            return InDegree;
        }

        public void DecrementInDegree()
        {
            --InDegree;
        }

        public void SetInitialIndegreeForNextStep()
        {
            foreach (var item in NextSteps)
            {
              item.InDegree++;  
            }
        }
    }
}