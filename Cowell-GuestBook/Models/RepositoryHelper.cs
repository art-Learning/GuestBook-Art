namespace Cowell_GuestBook.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static ARTICLERepository GetARTICLERepository()
		{
			var repository = new ARTICLERepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ARTICLERepository GetARTICLERepository(IUnitOfWork unitOfWork)
		{
			var repository = new ARTICLERepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ARTICLEREPLYRepository GetARTICLEREPLYRepository()
		{
			var repository = new ARTICLEREPLYRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ARTICLEREPLYRepository GetARTICLEREPLYRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ARTICLEREPLYRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ForumRepository GetForumRepository()
		{
			var repository = new ForumRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ForumRepository GetForumRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ForumRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}