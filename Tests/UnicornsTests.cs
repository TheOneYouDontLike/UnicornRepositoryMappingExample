namespace Tests
{
    using System.Collections.Generic;
    using Core.Domain;
    using Core.Infrastructure;
    using NUnit.Framework;

    [TestFixture]
    public class UnicornsTests
    {
        private UnicornRepository _unicornRepository;

        [SetUp]
        public void Setup()
        {
            _unicornRepository = new UnicornRepository();
        }

        [Test]
        public void Should_add_and_get_domain_unicorn_by_mapping_it_to_db_unicorn()
        {
            // given
            var domainUnicorn = new DomainUnicorn
            {
                Name = "Fluffy",
                Power = "Killing by piercing the enemy"
            };

            // when
            _unicornRepository.AddNewUnicorn(domainUnicorn);
            DomainUnicorn unicorn = _unicornRepository.GetSingleUnicornByName(domainUnicorn.Name);

            // then
            Assert.That(unicorn.Power, Is.EqualTo(domainUnicorn.Power));
        }

        [Test]
        public void Should_get_list_of_domain_unicorns()
        {
            // given
            var domainUnicornNumberOne = new DomainUnicorn
            {
                Name = "Fluffy",
                Power = "Killing by piercing the enemy"
            };

            var domainUnicornNumberTwo = new DomainUnicorn
            {
                Name = "Olaf",
                Power = "Killing by eating the enemy"
            };

            _unicornRepository.AddNewUnicorn(domainUnicornNumberOne);
            _unicornRepository.AddNewUnicorn(domainUnicornNumberTwo);

            // when
            ICollection<DomainUnicorn> domainUnicorns = _unicornRepository.GetAllUnicorns();

            // then
            Assert.That(domainUnicorns.Count, Is.EqualTo(2));
        }
    }
}