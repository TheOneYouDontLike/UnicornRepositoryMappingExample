namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Domain;

    public class UnicornRepository
    {
        private readonly ICollection<DbUnicorn> _unicornList;

        public UnicornRepository()
        {
            _unicornList = new List<DbUnicorn>();
        }

        public void AddNewUnicorn(DomainUnicorn domainUnicorn)
        {
            var dbUnicorn = new DbUnicorn
            {
                Name = domainUnicorn.Name,
                Power = domainUnicorn.Power
            };

            _unicornList.Add(dbUnicorn);
        }

        public DomainUnicorn GetSingleUnicornByName(string name)
        {
            var domainUnicorn = _unicornList
                .Where(dbUnicorn => dbUnicorn.Name == name)
                .Select(MapDbToDomainUnicorn())
                .FirstOrDefault();

            return domainUnicorn;
        }

        public ICollection<DomainUnicorn> GetAllUnicorns()
        {
            var domainUnicorns = _unicornList
                .Select(MapDbToDomainUnicorn())
                .ToList();

            return domainUnicorns;
        }

        private static Func<DbUnicorn, DomainUnicorn> MapDbToDomainUnicorn()
        {
            return dbUnicorn =>
                new DomainUnicorn { Name = dbUnicorn.Name, Power = dbUnicorn.Power };
        }
    }
}