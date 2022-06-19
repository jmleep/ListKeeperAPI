namespace ListKeeperAPI.Models
{
    public class LKTask : LKCompletable
    {
        public int ID { get; set; }
        public int SubListID { get; set; }
        public virtual LKSubList SubList { get; set; }
    }
}
