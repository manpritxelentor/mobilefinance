using System.Collections.Generic;

namespace MobileFinanceErp.Models
{
    public class CustomerModel : BaseAuditableEntity
    {
        public CustomerModel()
        {
            Finances = new List<FinanceModel>();
        }

        public int Id { get; set; }
        public string CustomerIdentificationNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string WhatsappNumber { get; set; }
        public int? PictureId { get; set; }
        public string AdhaarNumber { get; set; }


        public virtual PictureModel CustomerImage { get; set; }
        public virtual ICollection<FinanceModel> Finances { get; set; }

    }
}