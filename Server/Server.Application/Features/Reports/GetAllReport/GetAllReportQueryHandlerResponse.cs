namespace Server.Application.Features.Reports.GetAllReport
{
    public sealed class GetAllReportQueryHandlerResponse
    {
        public int ProductCount { get; set; }
        public int DepotCount { get; set; }
        public int CustomerCount { get; set; }
        public int PurchaseInvoicesCount { get; set; }
        public int SaleInvoicesCount { get; set; }
        public int OrderCount { get; set; }

    }
}
