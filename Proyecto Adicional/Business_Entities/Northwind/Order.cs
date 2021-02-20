using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities.Northwind
{
	public class Order : DetailOrder
	{
		public int Id { get; set; }
		public string CustomerID { get; set; }
		public int EmployeeID { get; set; }
		public string FirstName { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public string ShipCity { get; set; }
		public decimal Freight { get; set; }
	}
}
