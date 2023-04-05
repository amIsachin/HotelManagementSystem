namespace Application.Methods;

/// <summary>
/// this class is singleton class which helps the application related to time management.
/// </summary>
public class TimeManagement
{
    #region Singleton
    private TimeManagement() { }

    private static TimeManagement instance = null;

    public static TimeManagement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimeManagement();
            }

            return instance;
        }
    } 
    #endregion

    public DateTime DateTimeNow()
    {
        return DateTime.Now;
    }
}
