namespace Repository.Core
{
    public interface IBaseRepository
    {
        /*
         * Class that implemnts this should hold all the code that does the work with interacting with the chosen repository framework.
         */

        void Save();
        void ResetRepo();
    }
}
