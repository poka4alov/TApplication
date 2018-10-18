using System;

namespace DataLayer
{
	public class UnitOfWork : IDisposable
	{
		private ItsmDataContext _dataContext;
		private Repository.UrgencyRepository _urgencyRepository;
		private Repository.ImpactRepository _impactRepository;
		private Repository.IncidentPriorityRepository _incidentPriorytyRepository;
		private Repository.MethodOfNotificationRepository _methodOfNotificationRepository;
		private Repository.IncidentRepository _incidentRepository;
		private Repository.ClosureData.ClosureDataRepository _closureDataRepository;
		private Repository.ClosureData.ResolutionTypeRepository _resolutionTypeRepository;
		private Repository.CategoryRecordRepository _categoryRecordRepository;


		public Repository.UrgencyRepository Urgency
		{
			get
			{
				if (_urgencyRepository == null)
					_urgencyRepository = new Repository.UrgencyRepository(_dataContext);
				return _urgencyRepository;
			}
		}

		public Repository.ImpactRepository Impact
		{
			get
			{
				if (_impactRepository == null)
					_impactRepository = new Repository.ImpactRepository(_dataContext);
				return _impactRepository;
			}
		

		}
		
		public Repository.IncidentPriorityRepository IncidentPriority
		{
			get
			{
				if (_incidentPriorytyRepository == null)
					_incidentPriorytyRepository = new Repository.IncidentPriorityRepository(_dataContext);
				return _incidentPriorytyRepository;
			}
		}

		public Repository.MethodOfNotificationRepository MethodOfNotification
		{
			get
			{
				if (_methodOfNotificationRepository == null)
					_methodOfNotificationRepository = new Repository.MethodOfNotificationRepository(_dataContext);
				return _methodOfNotificationRepository;
			}
		}

		public Repository.IncidentRepository Incident
		{
			get
			{
				if (_incidentRepository == null)
					_incidentRepository = new Repository.IncidentRepository(_dataContext);
				return _incidentRepository;
			}
		}

		public Repository.ClosureData.ClosureDataRepository ClosureData
		{
			get
			{
				if (_closureDataRepository == null)
					_closureDataRepository = new Repository.ClosureData.ClosureDataRepository(_dataContext);
				return _closureDataRepository;
			}
		}

		public Repository.ClosureData.ResolutionTypeRepository ResolutionType{
			get
			{
				if (_resolutionTypeRepository == null)
					_resolutionTypeRepository = new Repository.ClosureData.ResolutionTypeRepository(_dataContext);
				return _resolutionTypeRepository;
			}
		}

		public Repository.CategoryRecordRepository CategoryRecord
		{
			get
			{
				if (_categoryRecordRepository == null)
					_categoryRecordRepository = new Repository.CategoryRecordRepository(_dataContext);
				return _categoryRecordRepository;
			}
		}



		public UnitOfWork()
		{
			_dataContext = new ItsmDataContext();
		}

		public void Save()
		{
			_dataContext.SaveChanges();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dataContext.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
