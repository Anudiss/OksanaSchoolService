namespace SchoolService.Database
{
    public static class DatabaseConnection
    {
        public static SchoolServicesEntities Database { get; }

        static DatabaseConnection() => Database = new SchoolServicesEntities();
    }
}
