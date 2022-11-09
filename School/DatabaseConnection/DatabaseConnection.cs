namespace School.DatabaseConnection
{
    public static class Database
    {
        public static SchoolServicesEntities Entities { get; }

        static Database() => Entities = new SchoolServicesEntities();
    }
}
