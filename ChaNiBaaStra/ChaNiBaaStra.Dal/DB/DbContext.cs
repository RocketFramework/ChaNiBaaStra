
using System.Data.Entity;
using Nido.Common.BackEnd;
using ChaNiBaaStra.Dal.Models;

namespace ChaNiBaaStra.Dal.DB
{
    public class AstroDatabaseDBContext : BaseObjectConext
    {
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<MovemenType> MovemenTypes { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<PlanetRelation> PlanetRelations { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<ThithiType> ThithiTypes { get; set; }
        public DbSet<ThithiMonth> ThithiMonths { get; set; }
        public DbSet<NakathThithiWeekDay> NakathThithiWeekDays { get; set; }
        public DbSet<BeneficCondition> BeneficConditions { get; set; }
        public DbSet<NakathThithi> NakathThithis { get; set; }
        public DbSet<Nakath> Nakaths { get; set; }
        public DbSet<NakathWeekDay> NakathWeekDays { get; set; }
        public DbSet<PlanetaryGenderType> PlanetaryGenderTypes { get; set; }
        public DbSet<Yoga> Yogas { get; set; }
        public DbSet<NakathPlanet> NakathPlanets { get; set; }
        public DbSet<NakathMonth> NakathMonths { get; set; }
        public DbSet<ThithiSagna> ThithiSagnas { get; set; }
        public DbSet<RashiMonth> RashiMonths { get; set; }
        public DbSet<NakathRelation> NakathRelations { get; set; }
        public DbSet<PakshaType> PakshaTypes { get; set; }
        public DbSet<Thithi> Thithis { get; set; }
        public DbSet<RashiThithi> RashiThithis { get; set; }

        public DbSet<GoodThithi> GoodThithis { get; set; }
        public DbSet<PlanetRelativeView> PlanetRelativeViews { get; set; }
        public DbSet<PlanetAstroPosition> PlanetAstroPositions { get; set; }
        public DbSet<AstroPosition> AstroPositions { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<PlanetRashiRelation> PlanetRashiRelations { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<ButhaType> ButhaTypes { get; set; }
        public DbSet<WorkForThithi> WorkForThithis { get; set; }
        public DbSet<ThithiWeekDay> ThithiWeekDays { get; set; }
        public DbSet<Rashi> Rashis { get; set; }
    }
}
