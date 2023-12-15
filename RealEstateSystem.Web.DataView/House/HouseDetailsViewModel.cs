using RealEstateSystem.Models.ViewModels.Agents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.House
{
    public class HouseDetailsViewModel:HouseServiceModel
    {

        public string Description { get; set; } = null!;

        public string CategoryName { get; set; }=null!;

        public AgentServiceViewModel AgentName { get; set; } = null!;   


    }
}
