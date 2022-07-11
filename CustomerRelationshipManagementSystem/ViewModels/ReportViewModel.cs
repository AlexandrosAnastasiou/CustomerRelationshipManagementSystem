namespace CustomerRelationshipManagementSystem.ViewModels
{
    public class ReportViewModel
    {
        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }
       
        public string CustomerSurname { get; set; }
    
        public string CustomerAddress { get; set; }
       
        public string CustomerCountry { get; set; }
       
        public DateTime CustomerDoB { get; set; }
        public int CallId { get; set; }
      
        public DateTime DateTimeOfCall { get; set; }
      
        public string Subject { get; set; }
      
        public string Description { get; set; }

        public int CustomerRefId { get; set; }
    }
}
