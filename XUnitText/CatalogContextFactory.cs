using Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitText
{
    public class CatalogContextFactory
    {
        public readonly IProcessPixels ProcessPixels;
        public CatalogContextFactory()
        {
           ProcessPixels = new ProcessPixels();
        }
    }
}
