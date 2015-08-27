using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Cowell_GuestBook.Models
{   
	public  class ARTICLEREPLYRepository : EFRepository<ARTICLEREPLY>, IARTICLEREPLYRepository
	{

	}

	public  interface IARTICLEREPLYRepository : IRepository<ARTICLEREPLY>
	{

	}
}