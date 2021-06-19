using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maverick.Xrm.DI.DataObjects
{
    public class DependencyReport
    {
        public DependencyReport()
        {
            SkipAdding = false;
        }

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
        [Browsable(false)]
        public bool SkipAdding { get; set; }

    }
}
