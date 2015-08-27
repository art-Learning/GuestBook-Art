using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Cowell_GuestBook.Models
{   
	public  class ForumRepository : EFRepository<Forum>, IForumRepository
	{

	}

	public  interface IForumRepository : IRepository<Forum>
	{

	}
}