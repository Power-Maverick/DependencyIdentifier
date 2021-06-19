using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Maverick.Xrm.DependencyIdentifier
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Dependency Identifier"),
        ExportMetadata("Description", "An XrmToolBox tool to generate all the dependencies in one shot"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#D9D9D9"),
        ExportMetadata("PrimaryFontColor", "Blue"),
        ExportMetadata("SecondaryFontColor", "Blue")]
    public class DependencyIdentifier : PluginBase, IPayPalPlugin
    {
        public string DonationDescription => "Keeps the ball rolling and motivates in making awesome tools. You will get free stickers; I will need your mailing address.";
        public string EmailAccount => "danz@techgeek.co.in";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DependencyIdentifierControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public DependencyIdentifier()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}