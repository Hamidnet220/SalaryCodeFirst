using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.DataLayer.Core
{
    public class AttendanceEngin
    {
        private Logsheet logsheet;

        public AttendanceEngin(Logsheet logsheet)
        {
            this.logsheet = logsheet;
        }

        private void AnalyzeAttendance()
        {
        }
    }
}