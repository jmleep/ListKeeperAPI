namespace ListKeeperAPI.Models
{
    public class LKSubList: LKCompletable
    {
        public int ID { get; set; }
        public int ParentListID { get; set; }
        public virtual LKParentList ParentList { get; set; }
        public virtual List<LKTask> Tasks { get; set; }
    }
}
