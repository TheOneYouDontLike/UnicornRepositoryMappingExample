namespace Tests
{
    using Core.Domain;
    using Core.Infrastructure;
    using NUnit.Framework;

    [TestFixture]
    public class UnicornsTests
    {
        [Test]
        public void Should_add_and_get_domain_unicorn_by_mapping_it_to_db_unicorn()
        {
            // given
            var unicornRepository = new UnicornRepository();

            // when
            var domainUnicorn = new DomainUnicorn
            {
                Name = "Fluffy",
                Power = "Killing by piercing the enemy"
            };

            unicornRepository.AddNewUnicorn(domainUnicorn);

            // then
            var unicorn = unicornRepository.GetSingleUnicornByName(domainUnicorn.Name);
            Assert.That(unicorn.Power, Is.EqualTo(domainUnicorn.Power));
        }
    }
}