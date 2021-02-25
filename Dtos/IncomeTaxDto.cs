using System.Collections.Generic;

namespace TaxComputationSoftware.Dtos
{
    public class IncomeTaxDto
    {

     
        public string Description { get; set; }

        public string ColumnOne { get; set; }

        public string ColumnTwo { get; set; }

        public int Id {get;set;}

        public bool CanDelete   {get;set;}

        public bool CanBolden {get;set;}

        public bool CanUnderline {get;set;}

    }
}