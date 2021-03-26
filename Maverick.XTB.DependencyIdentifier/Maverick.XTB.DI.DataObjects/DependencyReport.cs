using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maverick.XTB.DI.DataObjects
{
    public class DependencyReport
    {
        [DisplayName("Entity Schema Name")]
        public string EntitySchemaName { get; set; }
        [DisplayName("Dependent Component")]
        public string DependentComponentName { get; set; }
        [DisplayName("Dependent Component Type")]
        public string DependentComponentType { get; set; }
        [DisplayName("Required Component")]
        public string RequiredComponentName { get; set; }
        [DisplayName("Required Component Type")]
        public string RequiredComponentType { get; set; }

    }
}
