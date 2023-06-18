using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2KnowledgeCheck1
{
    internal class Construction
    {
        //make CreateApartment generic class; will need to rename
        public void CreateBuilding<T>(T building, List<Building> buildings) where T : Building
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            var buildingWasMade = ConstructBuilding<T>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

            if (buildingWasMade)
            {
                buildings.Add(building);
            }
        }

        public bool ConstructBuilding<T>(List<Material> materials, bool permit, bool zoning) where T : Building
        {
            if (permit && zoning)
            {
                foreach (var material in materials)
                {
                    //writes step for each material with a first step
                    var firstStep = material.MaterialConstructionFirstStep();
                    Console.WriteLine(firstStep);
                    //if (material == "concrete")
                    //{
                    //    // start laying foundation
                    //}
                    //else if (material == "Steel")
                    //{
                    //    // Start building structure
                    //}
                    // etc etc...

                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
