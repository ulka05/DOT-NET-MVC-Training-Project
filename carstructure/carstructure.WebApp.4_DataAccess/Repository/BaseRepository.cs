namespace carstructure.WebApp._4_DataAccess.DataAccessClass
{
    public class BaseRepository
    {
        public Context context { get; set; }

        public BaseRepository(Context _context)
        {
            context = _context;
        }
    }
}