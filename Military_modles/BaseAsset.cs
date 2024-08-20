namespace Military_Asset_Management_System.Military_modles
{
    public abstract class BaseAsset
    {
        public int Id { get; set; } // מזההייחודילכלנכס
        public string? Name { get; set; } // שםהנכס
        public string? AssetType { get; set; } //- סוגהנכס)לדוגמה : "Vehicle", "Weapon", "Personnel")
        public string? Status { get; set; } // מצבהנכס)לדוגמה : "Active", "Inactive", "Maintenance")       
    }
    public class Vehicle : BaseAsset
    {
        public string? Model { get; set; } // - דגםהרכב
        public string? LicensePlate { get; set; } // - מספררישוי
        public string? OperationalStatus { get; set; } // - מצבתפעולי)לדוגמה : "Operational", "Under ,Repair")
    }
    public class Weapon : BaseAsset // inherits from BaseAsset
    {
        public string? Caliber { get; set; } // - קוטרהנשק
        public string? SerialNumber { get; set; }// - מספרסידורי
        public int? AmmunitionCount { get; set; }// - כמותתחמושת

    }
    public class Personnel : BaseAsset // inherits from BaseAsset
    {
        public string? Rank { get; set;} // - דרגהצבאית
        public string? ServiceNumber { get; set; }// - מספראישי
        public string? AssignedUnit { get; set; } // - יחידהשאליהמשויךהחייל

    }
    





}
