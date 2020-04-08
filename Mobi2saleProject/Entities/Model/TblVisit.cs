using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblVisit
    {
        public Guid Id { get; set; }
        public Guid FkSalesmanVisitSalesmanId { get; set; }
        public Guid FkClientsVisitClientId { get; set; }
        public DateTime VisitDate { get; set; }
        public string SerialNo { get; set; }
        public string VisitImage { get; set; }
        public string FeedBack { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public TblClient FkClientsVisitClient { get; set; }
        public TblSalesmen FkSalesmanVisitSalesman { get; set; }
    }
}
