using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Business_logic
{
    class Modules
    {
        private string moduleCode;
        private string moduleName;
        private string moduleDescription;
        private string resourceLinks;

        public Modules(string moduleCode, string moduleName, string moduleDescription, string resourceLinks)
        {
            this.moduleCode = moduleCode;
            this.moduleName = moduleName;
            this.moduleDescription = moduleDescription;
            this.resourceLinks = resourceLinks;
        }

        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public string ModuleDescription { get => moduleDescription; set => moduleDescription = value; }
        public string ResourceLinks { get => resourceLinks; set => resourceLinks = value; }
    }
}
