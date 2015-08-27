using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Cowell_GuestBook.Models
{   
	public  class ARTICLERepository : EFRepository<ARTICLE>, IARTICLERepository
	{

	}

	public  interface IARTICLERepository : IRepository<ARTICLE>
	{

	}
}