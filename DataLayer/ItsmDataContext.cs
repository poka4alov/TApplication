namespace DataLayer
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using System.Linq;
	using DataLayer.Model;

	class ItsmDataContextInitializer : DropCreateDatabaseAlways<ItsmDataContext>
	{
		protected override void Seed(ItsmDataContext db)
		{
			db.Urgencies.Add (new Urgency { Title = "High", Description = "я тут по русски вам говорю" });
			db.Urgencies.Add(new Urgency { Title = "Medium", Description = "я тут по русски вам говорю" });
			db.Urgencies.Add(new Urgency { Title = "Low", Description = "я тут по русски вам говорю" });

			db.Impacts.Add(new Impact { Title = "Low", Description = "я тут по русски вам говорю" });
			db.Impacts.Add(new Impact { Title = "Medium", Description = "я тут по русски вам говорю" });
			db.Impacts.Add(new Impact { Title = "High", Description = "я тут по русски вам говорю" });
			db.SaveChanges();

			Urgency urg = db.Urgencies.First(u => u.Title == "Medium");
			Impact imp = db.Impacts.First(i=>i.Title == "Low");
			IncidentPriority priority = new IncidentPriority() { Title = "Incident", Description = "Description", Impact = imp, Urgency = urg, ResolutionTime = "60", ResponceTime = "3000" };
			db.IncidentPriorities.Add(priority);
			db.SaveChanges();

			db.MethodOfNotifications.Add(new MethodOfNotification() { Title = "Phone", Description = "Phone phone" });
			db.MethodOfNotifications.Add(new MethodOfNotification() { Title = "email", Description = "email email" });
			db.SaveChanges();

			db.ResolutionTypes.Add(new ResolutionType() { Title = "close", Description = "Closed" });
			db.ResolutionTypes.Add(new ResolutionType() { Title = "registered", Description = "REGistatetd" });
			db.SaveChanges();

			db.CategoryRecords.Add(new CategoryRecord() { Title = "network", Description="" });
			
			db.SaveChanges();
			CategoryRecord categoryRecord = db.CategoryRecords.First(c => c.Title == "network");
			db.CategoryRecords.Add(new CategoryRecord() { Title = "switch",PearentCategory=categoryRecord });
			db.SaveChanges();


			List<CategoryRecord> categoryRecords = new List<CategoryRecord>();
			categoryRecords.Add(db.CategoryRecords.Find(1));

			List<MethodOfNotification> methodOfNotifications = new List<MethodOfNotification>();
			methodOfNotifications.Add(db.MethodOfNotifications.Find(1));
			methodOfNotifications.Add(db.MethodOfNotifications.Find(2));

			ClosureData closure = new ClosureData() {
				ResolutionType = db.ResolutionTypes.Find(2),
				CustomerFeedback = "feedback",
				ClosureCategories = categoryRecords, 
			
			};
			db.ClosureDatas.Add(closure);
			db.SaveChanges();
			Incident incident = new Incident()
			{
				Title = "incident 1",
				Description = "не работае сеть в отделе снабжения. не горят лампочки на свиче.",
				MethodOfNotification = db.MethodOfNotifications.Find(1),
				MethodOfCallback = methodOfNotifications,
				IncidentPriority = db.IncidentPriorities.Find(1),
				Owner = "Admininstartor",
				ServiceDescAgent = "Operator",
				OrderDate = DateTime.Now,
				Closure = db.ClosureDatas.Find(1)
			};
			db.Incidents.Add(incident);
			db.SaveChanges();


		}
	}


	public class ItsmDataContext : DbContext
	{
		static ItsmDataContext()
		{
			Database.SetInitializer<ItsmDataContext>(new ItsmDataContextInitializer());
		}
		
		public ItsmDataContext()
			: base("name=ItsmDataContext")
		{
		}

		
		public virtual DbSet<Urgency> Urgencies { get; set; }
		public virtual DbSet<Impact> Impacts { get; set; }
		public virtual DbSet<IncidentPriority> IncidentPriorities {get;set;}
		public virtual DbSet<MethodOfNotification> MethodOfNotifications { get; set; }
		public virtual DbSet<Incident> Incidents { get; set; }
		public virtual DbSet<ResolutionType> ResolutionTypes { get; set; }
		public virtual DbSet<ClosureData> ClosureDatas { get; set; }
		public virtual DbSet<CategoryRecord> CategoryRecords { get; set; }
		//х.з как правильно
		//public virtual DbSet<UserProfile> ClientProfiles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// использование Fluent API
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		
		}
	}
}