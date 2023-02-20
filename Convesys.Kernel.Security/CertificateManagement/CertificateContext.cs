﻿using System.Collections.Generic;

namespace Twilight.Kernel.Security.CertificateManagement
{
    public class CertificateContext
    {
        public CertificateContext()
        {
            this.SearchCriteria = new List<CertificateSearchCriteria>();
        }
        public ICollection<CertificateSearchCriteria> SearchCriteria { get; }
        public bool ValidOnly { get; set; }
    }
}